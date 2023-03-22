namespace TransportMgmt.Domain;

public class Driver
{
    public int DriverId { get; set; } = 0;

    public string FistName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string MidleName { get; set; } = string.Empty;

    public int Passport { get; set; } = 0;

    public int DriverLicense { get; set; } = 0;

    public string Address { get; set; } = string.Empty;

    public int PhoneNumber { get; set; } = 0;

    public List<int> Routes { get; set; } = new List<int>();

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
