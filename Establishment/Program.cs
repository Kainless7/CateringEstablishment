using ManagementCateringEstablishment.Entity;

namespace Establishment;

using ManagementCateringEstablishment;

internal abstract class Program
{
    public static void Main(string[] args) 
    {
        var cashier = new Cashier("Ivan", "Roshal", 2400);
        var waiter = new Waiter("Ron", "Wisely", 2400);
        
        var myEstablishment = new CateringEstablishment("It`s my life", 10);
        
        myEstablishment.HireCashier(cashier);
        
        myEstablishment.HireWaiter(waiter);
        myEstablishment.HireWaiter("Don", "Wise");
        myEstablishment.HireWaiter("Kol", "Doll");
        myEstablishment.HireWaiter("Zac", "Bryant");
        
        myEstablishment.HireCook("Israel", " Washington");
        myEstablishment.HireCook("Milo", "Wood");
        myEstablishment.HireCook("Ron", "Wisely");
        
        myEstablishment.AddTable(1, 2);
        myEstablishment.AddTable(2, 5);
        myEstablishment.AddTable(3, 5);
        myEstablishment.AddTable(4, 1);
        myEstablishment.AddTable(5, 2);
        myEstablishment.AddTable(6, 3);
        
        myEstablishment.AddVisitor(2);
        myEstablishment.AddVisitor(4);
        myEstablishment.AddVisitor(4);
        myEstablishment.AddVisitor(1);
        myEstablishment.AddVisitor(2);
    }
}