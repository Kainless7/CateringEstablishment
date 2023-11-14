namespace ManagementCateringEstablishment.EventArgs;

public class VisitorArrivalEventArgs : System.EventArgs
{
    public Table Table { get; }
    
    public VisitorArrivalEventArgs(Table table)
    {
        Table = table;
    }
}