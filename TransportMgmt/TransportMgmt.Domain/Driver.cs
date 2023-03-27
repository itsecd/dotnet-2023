namespace TransportMgmt.Domain;
/// <summary>
/// Class Driver is used to store information about drivers
/// </summary>
public class Driver
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Middle name of driver
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Driver's passport number
    /// </summary>
    public int Passport { get; set; } = 0;
    /// <summary>
    /// Driver's license number
    /// </summary>
    public int DriverLicense { get; set; } = 0;
    /// <summary>
    /// Driver's address
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Driver's phone number
    /// </summary>
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
