namespace ManagementCateringEstablishment.Documents;

public class Bill : FinancialDocuments
{
    private int TableNumber { get; }
    private int NumberOfPeople { get; }
    private readonly Order _order;
    private readonly List<MenuItem> _menu;

    public Bill(Table table, Order order, string name, List<MenuItem> menu) 
        : base("Bill", DateTime.Today, name)
    {
        TableNumber = table.TableNumber;
        NumberOfPeople = table.VisitorsAtTheTable.Count;
        _order = order;
        _menu = menu;
        OrderSum = _order.OrderItems.Sum(item => _menu.First(menuItem => menuItem.DishName == item).Prise);
        Vta = OrderSum * 0.14f;
        Total = OrderSum + Vta;
        NameOfTheInstitution = name;
    }

    public void GetBill()
    {
        Console.WriteLine("=====================");
        Console.WriteLine(Type);
        Console.WriteLine($"Data: {Data}\n" +
                          $"Table number: {TableNumber}\n" +
                          $"Number of people: {NumberOfPeople}");
        foreach (var item in _order.OrderItems)
        {
            Console.WriteLine($"{item} {_menu.First(menuItem => menuItem.DishName == item).Prise}");
        }
        Console.WriteLine($"Sum: {OrderSum}\n" +
                          $"VTA: {Vta}\n" +
                          $"Total: {Total}");
        Console.WriteLine("=====================");
    }
}