using ManagementCateringEstablishment.EventArgs;

namespace ManagementCateringEstablishment.Entity;

public class Cook : Worker
{
    internal readonly Queue<Order> OrderQueue = new();
    
    public Cook(string firstName, string lastName, double salary) 
        : base(firstName, lastName, salary) {}

    public Cook(string firstName, string lastName, double salary, CateringEstablishment establishment) 
        : base(firstName, lastName, salary, establishment) {}
    
    public void HandleOrderProcessed(OrderProcessedEventArgs e, Cook selectedCook)
    {
        if (this != selectedCook || Establishment == null) return;

        e.Order.Status = OrderStatus.Done;
        
        Console.WriteLine($"{FirstName} {LastName}: The order is ready");
    }
}
