namespace TransportManagment.Classes;
public class Driver
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Patronymic of driver
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// Number of passport driver
    /// </summary>
    public int Passport { get; set; } = 0;
    /// <summary>
    /// Number of driver's card
    /// </summary>
    public int DriverCard { get; set; } = 0;
    /// <summary>
    /// Telephon number of driver
    /// </summary>
    public int Number { get; set; } = 0;
    /// <summary>
    /// List of routes for this driver
    /// </summary>
    public List<int> Routes { get; set; } = new List<int>();
    public Driver() { }
    public Driver(int driverId, string firstName, string lastName, string patronymic, int passport, int driverCard, int number, List<int> routes)
    {
        DriverId = driverId;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Passport = passport;
        DriverCard = driverCard;
        Number = number;
        Routes = routes;
    }
}