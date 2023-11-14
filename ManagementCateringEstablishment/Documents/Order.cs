using ManagementCateringEstablishment.Entity;

namespace ManagementCateringEstablishment;

public class Order
{
    internal OrderStatus Status = OrderStatus.Accepted;
    internal readonly Waiter WaiterWhoTookOrder;
    public readonly int TableNumber;
    public readonly List<string> OrderItems;
    
    public Order(Table table, Waiter waiter, List<string> wishList)
    {
        TableNumber = table.TableNumber;
        WaiterWhoTookOrder = waiter;
        OrderItems = wishList;
    }
}