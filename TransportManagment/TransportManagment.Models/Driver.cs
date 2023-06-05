using System.ComponentModel.DataAnnotations;

namespace TransportManagment.Models;
/// <summary>
/// Class of drivers
/// </summary>
public class Driver
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    [Key]
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
    public List<Route> Routes { get; set; } = new List<Route>();
    public Driver() { }
    public Driver(int driverId, string firstName, string lastName, string patronymic, int passport, int driverCard, int number)
    {
        DriverId = driverId;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Passport = passport;
        DriverCard = driverCard;
        Number = number;
    }
}