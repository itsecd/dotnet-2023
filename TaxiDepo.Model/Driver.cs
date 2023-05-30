using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDepo.Model;

/// <summary>
/// Driver class
/// </summary>
[Table("Drivers")]
public class Driver
{
    /// <summary>
    /// Driver id
    /// </summary>
    [Column("Id")]
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// Driver surname
    /// </summary>
    [Column("DriverSurname")]
    [Required]
    [MaxLength(45)]
    public string DriverSurname { get; set; } = string.Empty;

    /// <summary>
    /// Driver name
    /// </summary>
    [Column("DriverName")]
    [Required]
    [MaxLength(45)]
    public string DriverName { get; set; } = string.Empty;

    /// <summary>
    /// Driver patronymic
    /// </summary>
    [Column("DriverPatronymic")]
    [Required]
    [MaxLength(45)]
    public string DriverPatronymic { get; set; } = string.Empty;

    /// <summary>
    /// Driver passport Id
    /// </summary>
    [Column("DriverPassportId")]
    [Required]
    public int DriverPassportId { get; set; } = 0;

    /// <summary>
    /// Driver address
    /// </summary>
    [Column("DriverAddress")]
    [Required]
    [MaxLength(45)]
    public string DriverAddress { get; set; } = string.Empty;

    /// <summary>
    /// Driver phone number
    /// </summary>
    [Column("DriverPhoneNumber")]
    [Required]
    public string DriverPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Constructor without parameters to instantiate the class Driver
    /// </summary>
    public Driver()
    {
    }

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
    public Driver(int id, string surname, string name, string patronymic, int passportId, string address,
        string phoneNumber)
    {
        Id = id;
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
    /// <param name="driverObj">Driver class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? driverObj)
    {
        if (driverObj is not Driver param || GetType() != driverObj.GetType()) return false;

        return DriverSurname == param.DriverSurname && DriverName == param.DriverName &&
               DriverPatronymic == param.DriverPatronymic && DriverPassportId == param.DriverPassportId &&
               DriverAddress == param.DriverAddress && DriverPhoneNumber == param.DriverPhoneNumber;
    }

    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="driverObj1">Driver class object</param>
    /// <param name="driverObj2">Driver class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator ==(Driver? driverObj1, Driver? driverObj2)
    {
        return Object.Equals(driverObj1, driverObj2);
    }

    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="driverObj1">Driver class object</param>
    /// <param name="driverObj2">Driver class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator !=(Driver driverObj1, Driver driverObj2)
    {
        return !Object.Equals(driverObj1, driverObj2);
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
