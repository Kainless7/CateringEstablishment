using ManagementCateringEstablishment.Entity;

namespace ManagementCateringEstablishment.Documents;

public class Check : FinancialDocuments
{
    private readonly string _cashier;
    private readonly string _waiter;
    private readonly Order _order;
    private readonly List<MenuItem> _menu;
    
    public Check(Worker cashier, Worker waiter, Order order, string name, List<MenuItem> menu) 
        : base("Check", DateTime.Now, name)
    {
        NameOfTheInstitution = name;
        _cashier = $"{cashier.FirstName} {cashier.LastName}";
        _waiter = $"{waiter.FirstName} {waiter.LastName}";
        _order = order;
        _menu = menu;
        OrderSum = _order.OrderItems.Sum(item => _menu.First(menuItem => menuItem.DishName == item).Prise);
        Vta = OrderSum * 0.14f;
        Total = OrderSum + Vta;
    }

    public void GetCheck()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"{NameOfTheInstitution}\n" +
                          $"Cashier: {_cashier}\n" +
                          $"Waiter: {_waiter}");
        foreach (var item in _order.OrderItems)
        {
            Console.WriteLine($"{item} {_menu.First(menuItem => menuItem.DishName == item).Prise}");
        }
        Console.WriteLine($"Sum: {OrderSum}\n" +
                          $"VTA: {Vta}\n" +
                          $"Data: {Data}\n" +
                          $"Total: {Total}\n" +
                          $"Fiscal check");
        Console.WriteLine("--------------------------");
    }
}