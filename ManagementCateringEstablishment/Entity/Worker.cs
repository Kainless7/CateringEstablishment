namespace ManagementCateringEstablishment.Entity;

public abstract class Worker
{
    public string FirstName { get; }
    public string LastName { get; }
    protected double Salary { get; set; }
    public CateringEstablishment? Establishment { get; set; }

    protected Worker(string firstName, string lastName, double salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
    }

    internal Worker(string firstName, string lastName, double salary, CateringEstablishment establishment)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        Establishment = establishment;
    }
}