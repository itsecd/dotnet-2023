using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharingDomain;
/// <summary>
/// describes a person who rented a car 
/// </summary>
public class Client
{
    /// <summary>
    /// client's passport number
    /// </summary>
    [Column("passport")]
    public string Passport { set; get; } = string.Empty;
    /// <summary>
    /// client's birthday date
    /// </summary>
    [Column("birthDate")]
    public DateTime BirthDate { set; get; } = DateTime.MinValue;
    /// <summary>
    /// client's fist name
    /// </summary>
    [Column("firstName")]
    public string FirstName { set; get; } = string.Empty;
    /// <summary>
    /// client's last name
    /// </summary>
    [Column("lastName")]
    public string LastName { set; get; } = string.Empty;
    /// <summary>
    /// client's id
    /// </summary>
    [Key]
    [Column("id")]
    public uint Id { set; get; }
    /// <summary>
    /// 
    /// </summary>
    //public List<RentedCar> RentedCars { get; set; } = new List<RentedCar>();
    /// <summary>
    /// Default constructor
    /// </summary>
    public Client() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="passport"></param>
    /// <param name="birthDate"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public Client(uint id, string passport, DateTime birthDate, string firstName, string lastName)
    {
        Id = id;
        Passport = passport;
        BirthDate = birthDate;
        FirstName = firstName;
        LastName = lastName;
    }
}