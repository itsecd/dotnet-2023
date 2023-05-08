using System.ComponentModel.DataAnnotations;

namespace TransportMgmt.Domain;
/// <summary>
/// Class Driver is used to store information about drivers
/// </summary>
public class Driver
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// First name of driver
    /// </summary>
    [Required]
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    [Required]
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Middle name of driver
    /// </summary>
    [Required] 
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Driver's passport number
    /// </summary>
    [Required]
    public int Passport { get; set; } = 0;
    /// <summary>
    /// Driver's license number
    /// </summary>
    [Required]
    public int DriverLicense { get; set; } = 0;
    /// <summary>
    /// Driver's address
    /// </summary>
    [Required] 
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Driver's phone number
    /// </summary>
    [Required] 
    public string PhoneNumber { get; set; } = string.Empty;
    public Driver() { }
    public Driver(int driverId, string firstName, string lastName, string middleName, int passport, int driverLicense, string address, string phoneNumber)
    {
        Id = driverId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Passport = passport;
        DriverLicense = driverLicense;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}
