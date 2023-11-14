using ManagementCateringEstablishment.Entity;

namespace ManagementCateringEstablishment;
public class Table
{
    private int _tableNumber;
    private int _maxNumberOfSeats;
    public bool Reservation { get; set; }
    public readonly List<Visitor> VisitorsAtTheTable;
    internal int TimeSpentMinutes;
    internal int NumberPeopleForAllTime;
    internal float Revenue { get; set; }
    public int AverageTimeSpent { get; set; }

    internal Table(int tableNumber, int maxNumberOfSeats)
    {
        TableNumber = tableNumber;
        MaxNumberOfSeats = maxNumberOfSeats;
        Reservation = false;
        VisitorsAtTheTable = new List<Visitor>();
    }
    
    public int TableNumber
    {
        get => _tableNumber;
        private set
        {
            if (value >= 1)
            {
                _tableNumber = value;
            }
            else
            {
                throw new Exception("Table number must be greater than or equal to 1");
            }
        }
    }
    
    public int MaxNumberOfSeats
    {
        get => _maxNumberOfSeats;
        private set
        {
            if (value is >= 1 and < 10)
            {
                _maxNumberOfSeats = value;
            }
            else
            {
                throw new Exception("The number of seats at the table must " +
                                    "be greater than or equal to 1 and no more than 10");
            }
        }
    }
}
