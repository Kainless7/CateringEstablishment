namespace ManagementCateringEstablishment;

public abstract class FinancialDocuments
{
    protected string NameOfTheInstitution { get; set; }
    protected string Type { get; }
    protected float Vta { get; init; }
    protected float OrderSum { get; init; }
    protected float Total { get; init; } 
    protected DateTime Data { get; }
    
    protected FinancialDocuments(string type, DateTime data, string nameOfTheInstitution)
    {
        Type = type;
        Data = data;
        NameOfTheInstitution = nameOfTheInstitution;
    }
}