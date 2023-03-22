namespace TransportMgmt.Domain;
/// <summary>
/// Class Driver is used to store information about drivers
/// </summary>
public class Driver
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FistName { get; set; } = string.Empty;
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Midle name of driver
    /// </summary>
    public string MidleName { get; set; } = string.Empty;
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
    public int PhoneNumber { get; set; } = 0;
    public Driver() { }
    public Driver(int driverId, string fistName, string lastName, string midleName, int passport, int driverLicense, string address, int phoneNumber)
    {
        DriverId = driverId;
        FistName = fistName;
        LastName = lastName;
        MidleName = midleName;
        Passport = passport;
        DriverLicense = driverLicense;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}
