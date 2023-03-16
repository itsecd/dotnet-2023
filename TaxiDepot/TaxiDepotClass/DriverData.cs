namespace TaxiDepotClass;

public class Driver
{
    /// <summary>
    /// Driver surname - field
    /// </summary>
    public string DriverSurname { get; set; } = string.Empty;
    /// <summary>
    /// Driver name - field
    /// </summary>
    public string DriverName { get; set; } = string.Empty;
    /// <summary>
    /// Driver patronymic - field
    /// </summary>
    public string DriverPatronymic { get; set; } = string.Empty;
    /// <summary>
    /// Driver passport ID - field
    /// </summary>
    public int DriverPassportId { get; set; } = 0;
    /// <summary>
    /// Driver address - field
    /// </summary>
    public string DriverAddress { get; set; } = string.Empty;
    /// <summary>
    /// Driver phone number  - field
    /// </summary>
    public string DriverPhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// Indicator that the driver is assigned to the car - field
    /// </summary>
    public bool DriverAssigned { get; set; } = false;
    /// <summary>
    /// Constructor without parameters to instantiate the class - Driver
    /// </summary>
    public Driver() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class - Driver
    /// </summary>
    /// <param name="surname"></param>
    /// <param name="name"></param>
    /// <param name="patronymic"></param>
    /// <param name="passportId"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    public Driver(string surname, string name, string patronymic, int passportId, string address, string phoneNumber)
    {
        DriverSurname = surname;
        DriverName = name;
        DriverPatronymic = patronymic;
        DriverPassportId = passportId;
        DriverAddress = address;
        DriverPhoneNumber = phoneNumber;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="driverObj"></param>
    /// <returns></returns>
    public override bool Equals(object? driverObj)
    {
        if (driverObj is not Driver param || GetType() != driverObj.GetType())
            return false;
        
        return DriverSurname == param.DriverSurname &&
               DriverName == param.DriverName &&
               DriverPatronymic == param.DriverPatronymic &&
               DriverPassportId == param.DriverPassportId && 
               DriverAddress == param.DriverAddress &&
               DriverPhoneNumber == param.DriverPhoneNumber;
    }
    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="driverObj1"></param>
    /// <param name="driverObj2"></param>
    /// <returns></returns>
    public static bool operator==(Driver driverObj1, Driver driverObj2)        
    {            
        return Object.Equals(driverObj1, driverObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="driverObj1"></param>
    /// <param name="driverObj2"></param>
    /// <returns></returns>
    public static bool operator!=(Driver driverObj1, Driver driverObj2)        
    {            
        return !Object.Equals(driverObj1, driverObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj"></param>
    public void PrintDriverData(Driver obj)
    {
        Console.WriteLine(
            $"Driver: {obj.DriverSurname} {obj.DriverName} {obj.DriverPatronymic}, passport ID - {obj.DriverPassportId}, living in {obj.DriverAddress}, phone number - {obj.DriverPhoneNumber}");
    }
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return DriverPassportId.GetHashCode();
    }
}

