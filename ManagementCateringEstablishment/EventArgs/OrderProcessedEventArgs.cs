namespace ManagementCateringEstablishment.EventArgs;

public class OrderProcessedEventArgs : System.EventArgs
{
    public Order Order { get; }
    
    public OrderProcessedEventArgs(Order order)
    {
        Order = order;
    }
}