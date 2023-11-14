namespace ManagementCateringEstablishment.Entity;

public class Cashier : Worker
{
    public Cashier(string firstName, string lastName, double salary)
        : base(firstName, lastName, salary) { }

    internal Cashier(string firstName, string lastName, double salary, CateringEstablishment establishment)
        : base(firstName, lastName, salary, establishment) { }
    
    public void HandleOrderAccepted()
    {
        Establishment?.ProcessOrders(Establishment.CashDesk.OrderQueue.Dequeue());
    }
}