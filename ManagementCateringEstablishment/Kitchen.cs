using ManagementCateringEstablishment.Entity;
namespace ManagementCateringEstablishment;

public class Kitchen
{
    
    private readonly CateringEstablishment _establishment;
    
    internal Kitchen(CateringEstablishment establishment)
    {
        _establishment = establishment;
    }
}