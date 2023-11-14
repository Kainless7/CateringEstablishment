using ManagementCateringEstablishment.Documents;
using ManagementCateringEstablishment.Entity;
using ManagementCateringEstablishment.EventArgs;
using ManagementCateringEstablishment.Interface;

namespace ManagementCateringEstablishment;

public delegate void VisitorArrivalHandler(VisitorArrivalEventArgs e, Waiter selectedWaiter);
public delegate void OrderProcessedHandler(OrderProcessedEventArgs e, Cook selectedCook);

public sealed class CateringEstablishment : ICateringEstablishment
{
    private readonly string _name = string.Empty;
    private int _tableLimit;
    private Cashier? _cashier;
    internal readonly CashDesk CashDesk;
    internal readonly Kitchen Kitchen;
    private readonly List<Table> _tables;
    private readonly List<Waiter> _waiters;
    private readonly List<Cook> _cooks;
    
    public event VisitorArrivalHandler VisitorArrival = null!;
    public event Action OrderAccepted = null!;
    public event OrderProcessedHandler OrderProcessed = null!;

    
    public CateringEstablishment() : this("Catering Establishment") {}
    public CateringEstablishment(string name, int limit = 5)
    {
        Name = name;
        TableLimit = limit;
        CashDesk = new CashDesk(this);
        Kitchen = new Kitchen(this);
        _tables = new List<Table>(limit);
        _waiters = new List<Waiter>((int)Math.Ceiling((double)limit / 3));
        _cooks = new List<Cook>((int)Math.Ceiling((double)limit / 3));
    }

    private string Name
    {
        get => _name;
        init
        {
            if (value.Length is >= 3 and < 30)
            {
                _name = value;
            }
            else
            {
                throw new Exception("The name of the institution must be greater " +
                                    "than or equal to 3 and less than or equal to 30");
            }
        }
    }
    
    public int TableLimit
    {
        get => _tableLimit;
        private set
        {
            if (value is >= 3 and <= 15)
            {
                _tableLimit = value;
            }
            else
            {
                throw new Exception("The table limit must be greater than or equal to 3 and less than or equal to 15");
            }
        }
    }

    public void AddTable(int tableNumber, int maxNumberOfSeats)
    {
        if (_tables.Any(table => table.TableNumber == tableNumber))
        {
            throw new Exception($"Table number {tableNumber} is already taken");
        }
        _tables.Add(new Table(tableNumber, maxNumberOfSeats));
    }
    
    public void HireCashier(Cashier cashier)
    {
        if (_cashier != null) throw new Exception("A cashier has already been hired");
        cashier.Establishment = this;
        _cashier = cashier;
        CashDesk.Cashier = cashier;
        OrderAccepted += _cashier.HandleOrderAccepted;
    
    }
    
    public void HireCook(string firstName, string lastName)
    {
        if (_cooks.Count == _cooks.Capacity) throw new Exception("The limit of cooks has been reached");

        var newCooks = new Cook(firstName, lastName, 3000, this);
        _cooks.Add(newCooks);
        OrderProcessed += newCooks.HandleOrderProcessed;
    }
    
    public void HireWaiter(string firstName, string lastName)
    {
        if (_waiters.Count == _waiters.Capacity) throw new Exception("The limit of waiters has been reached");

        var newWaiter = new Waiter(firstName, lastName, 3000, this);
        _waiters.Add(newWaiter);
        VisitorArrival += newWaiter.HandleVisitorArrival;
    }
    
    public void HireWaiter(Waiter waiter)
    {
        if (_waiters.Count == _waiters.Capacity) throw new Exception("The limit of waiters has been reached");
        _waiters.Add(waiter);
        waiter.Establishment = this;
        VisitorArrival += waiter.HandleVisitorArrival;
    }
    
    public void AddVisitor(int number)
    {
        var suitableTable = _tables
            .Where(table => !table.Reservation && table.MaxNumberOfSeats >= number)
            .MinBy(table => table.MaxNumberOfSeats);

        if (suitableTable == null) throw new Exception("No tables available!");

        for (var i = 0; i < number; i++)
        {
            suitableTable.VisitorsAtTheTable.Add(new Visitor());
            suitableTable.NumberPeopleForAllTime++;
        }

        suitableTable.Reservation = true;
        Console.WriteLine("Visitors added successfully");
        NotifyWaiters(suitableTable);
    }
    
    private void NotifyWaiters(Table table)
    {
        var availableWaiter = _waiters.MinBy(waiter => waiter.TableQueue.Count);

        if (availableWaiter != null)
        {
            availableWaiter.TableQueue.Enqueue(table);
            OnGuestArrival(new VisitorArrivalEventArgs(table), availableWaiter);
        }
        else
        {
            throw new Exception("No waiters available!");
        }
    }

    private void OnGuestArrival(VisitorArrivalEventArgs e, Waiter selectedWaiter)
    {
        VisitorArrival(e, selectedWaiter);
    }

    internal void CreateOrder(Table table, Waiter waiter, List<string> wishList)
    {
        var order = new Order(table, waiter, wishList);
        CashDesk.OrderQueue.Enqueue(order);
    }
    
    internal void ProcessOrders(Order order)
    {
        Console.WriteLine($"Processing order for {order.OrderItems.Count} items.");
        
        order.Status = OrderStatus.Processing;
        const int delayMilliseconds = 2000;
        Thread.Sleep(delayMilliseconds);
        var table = _tables.FirstOrDefault(t => t.TableNumber == order.TableNumber);
        if (table == null) return;
        
        var bill = new Bill(table, order, Name, CashDesk.Menu);
        bill.GetBill();
        NotifyCooks(order);

    }

    internal void OnOrderAccepted()
    {
        OrderAccepted.Invoke();
    }
                                                                                    
    private void NotifyCooks(Order order)
    {
        var availableCook = _cooks.MinBy(cook => cook.OrderQueue.Count);

        if (availableCook != null)
        {
            availableCook.OrderQueue.Enqueue(order);
            OnOrderProcessed(new OrderProcessedEventArgs(order), availableCook);
        }
        else
        {
            throw new Exception("No cooks available!");
        }
    }

    private void OnOrderProcessed(OrderProcessedEventArgs e, Cook selectedCook)
    {
        OrderProcessed.Invoke(e, selectedCook);
    }
}