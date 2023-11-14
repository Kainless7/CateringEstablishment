using ManagementCateringEstablishment.Entity;

namespace ManagementCateringEstablishment.Interface;

public interface ICateringEstablishment
{
    public void AddTable(int tableNumber, int maxNumberOfSeats);
    public void HireCashier(Cashier cashier);
}