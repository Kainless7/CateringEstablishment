using ManagementCateringEstablishment.Documents;
using ManagementCateringEstablishment.Entity;

namespace ManagementCateringEstablishment;
public class CashDesk
{
    internal readonly Queue<Order> OrderQueue = new();
    internal Cashier? Cashier;
    private readonly CateringEstablishment _establishment;

    internal readonly List<MenuItem> Menu = new List<MenuItem>
    {
        new("Burger", 44.99f, 27, 3),
        new("Pizza", 120f, 90, 20),
        new("Pasta", 89.99f, 70, 12),
        new("Salad", 40.55f, 25, 6),
        new("Steak", 200f, 150, 27),
        new("Sushi", 299.99f, 240, 20),
        new("Ice Cream", 29.50f, 20, 1)
    };

    internal CashDesk(CateringEstablishment establishment)
    {
        _establishment = establishment;
    }
    
    internal void AddMenuItems(string dishName, float price, float costPrice, int cookingTime)
    {
        var existingMenuItem = Menu.FirstOrDefault(menuItem => menuItem.DishName == dishName);

        if (existingMenuItem != null)
        {
            existingMenuItem.Prise = price;
            existingMenuItem.CostPrice = costPrice;
            existingMenuItem.CookingTime = cookingTime;
        }
        else
        {
            Menu.Add(new MenuItem(dishName, price, costPrice, cookingTime));
        }
    }
}