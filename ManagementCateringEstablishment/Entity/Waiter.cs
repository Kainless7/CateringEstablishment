using ManagementCateringEstablishment.EventArgs;

namespace ManagementCateringEstablishment.Entity;

public class Waiter : Worker
{
    public double TotalAmountOfTips { get; set; }
    public double AverageAmountOfTips { get; set; }
    public readonly Queue<Table> TableQueue = new ();
    
    public Waiter(string firstName, string lastName, double salary)
        : base(firstName, lastName, salary) { }

    internal Waiter(string firstName, string lastName, double salary, CateringEstablishment establishment)
        : base(firstName, lastName, salary, establishment) { }
    
    public void HandleVisitorArrival(VisitorArrivalEventArgs e, Waiter selectedWaiter)
    {
        if (this != selectedWaiter || Establishment == null) return;
        var wishList = new List<string>();

        foreach (var visitor in e.Table.VisitorsAtTheTable)
        {
            visitor.WishList(Establishment.CashDesk.Menu);
            wishList.AddRange(visitor.PreferredOrder);
        }

        Establishment.CreateOrder(e.Table, this, wishList);
        Console.WriteLine($"{FirstName} {LastName}: The order has been placed");
        Establishment.OnOrderAccepted();
    }
}