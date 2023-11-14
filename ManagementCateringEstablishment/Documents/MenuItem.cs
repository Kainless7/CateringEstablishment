namespace ManagementCateringEstablishment.Documents;

public class MenuItem
{
    internal readonly string DishName;
    internal float Prise;
    internal float CostPrice;
    internal int CookingTime;

    public MenuItem(string dishName, float prise, float costPrice, int cookingTime)
    {
        DishName = dishName;
        Prise = prise;
        CostPrice = costPrice;
        CookingTime = cookingTime;
    }
}