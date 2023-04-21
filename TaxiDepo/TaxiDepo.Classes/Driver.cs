namespace TaxiDepo.Domain;

/// <summary>
/// Driver class
/// </summary>
public class Driver
{
    /// <summary>
    /// Driver id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Driver surname
    /// </summary>
    public string DriverSurname { get; set; } = string.Empty;
    /// <summary>
    /// Driver name
    /// </summary>
    public string DriverName { get; set; } = string.Empty;
    /// <summary>
    /// Driver patronymic
    /// </summary>
    public string DriverPatronymic { get; set; } = string.Empty;
    /// <summary>
    /// Driver passport ID
    /// </summary>
    public int DriverPassportId { get; set; } = 0;
    /// <summary>
    /// Driver address
    /// </summary>
    public string DriverAddress { get; set; } = string.Empty;
    /// <summary>
    /// Driver phone number
    /// </summary>
    public string DriverPhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// Indicator that the driver is assigned to the car
    /// </summary>
    public bool DriverIsAssigned { get; set; } = false;
    /// <summary>
    /// Assigned car info
    /// </summary>
    public Car? AssignedCar { get; set; }
    /// <summary>
    /// Constructor without parameters to instantiate the class Driver
    /// </summary>
    public Driver() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class Driver
    /// </summary>
    /// <param name="id">Driver id</param>
    /// <param name="surname">Driver surname</param>
    /// <param name="name">Driver name</param>
    /// <param name="patronymic">Driver patronymic</param>
    /// <param name="passportId">Driver passport ID</param>
    /// <param name="address">Driver address</param>
    /// <param name="phoneNumber">Driver phone number</param>
    /// <param name="car">Driver assigned car</param>
    public Driver(int id, string surname, string name, string patronymic, int passportId, string address, string phoneNumber, Car? car)
    {
        Id = id; 
        DriverSurname = surname;
        DriverName = name;
        DriverPatronymic = patronymic;
        DriverPassportId = passportId;
        DriverAddress = address;
        DriverPhoneNumber = phoneNumber;
        AssignedCar = car;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="driverObj">Driver class object</param>
    /// <returns>True - equal or false - not equal</returns>
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
    /// <param name="driverObj1">Driver class object</param>
    /// <param name="driverObj2">Driver class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator==(Driver driverObj1, Driver driverObj2)        
    {            
        return Object.Equals(driverObj1, driverObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="driverObj1">Driver class object</param>
    /// <param name="driverObj2">Driver class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator!=(Driver driverObj1, Driver driverObj2)        
    {            
        return !Object.Equals(driverObj1, driverObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj">Driver class object</param>
    public void PrintDriverData(Driver obj)
    {
        Console.WriteLine(
            $"Driver: {obj.DriverSurname} {obj.DriverName} {obj.DriverPatronymic}, passport ID - {obj.DriverPassportId}, living in {obj.DriverAddress}, phone number - {obj.DriverPhoneNumber}, his car - {obj.AssignedCar}");
    }
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns>Integer hash code</returns>
    public override int GetHashCode()
    {
        return DriverPassportId.GetHashCode();
    }
}

