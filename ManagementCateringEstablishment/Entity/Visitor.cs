using ManagementCateringEstablishment.Documents;

namespace ManagementCateringEstablishment.Entity;

public class Visitor
{
   internal List<string> PreferredOrder = new ();

   public void WishList(IEnumerable<MenuItem> menu)
   {
      var menuItems = menu.Select(menuItem => menuItem.DishName).ToList();

      var random = new Random();

      var numberOfItems = random.Next(1, 4);

      PreferredOrder = Enumerable.Range(1, numberOfItems)
         .Select(_ => menuItems[random.Next(menuItems.Count)])
         .ToList();
   }

}