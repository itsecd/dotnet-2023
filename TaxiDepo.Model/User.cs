using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiDepo.Model;

/// <summary>
/// User class
/// </summary>
[Table("Users")]
public class User
{
    /// <summary>
    /// User id
    /// </summary>
    [Column("Id")]
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// User surname
    /// </summary>
    [Column("UserSurname")]
    [Required]
    [MaxLength(45)]
    public string UserSurname { get; set; } = string.Empty;

    /// <summary>
    /// User name
    /// </summary>
    [Column("UserName")]
    [Required]
    [MaxLength(45)]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// User patronymic
    /// </summary>
    [Column("UserPatronymic")]
    [Required]
    [MaxLength(45)]
    public string UserPatronymic { get; set; } = string.Empty;

    /// <summary>
    /// User phonenumber
    /// </summary>
    [Column("UserPhoneNumber")]
    [Required]
    [MaxLength(45)]
    public string UserPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// User ride collection
    /// </summary>
    public Ride? UserRide { get; set; }

    /// <summary>
    /// Constructor without parameters to instantiate the class User
    /// </summary>
    public User()
    {
    }

    /// <summary>
    /// Constructor with parameters to instantiate the class User
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="surname">User surname</param>
    /// <param name="name">User name</param>
    /// <param name="patronymic">User patronymic</param>
    /// <param name="phoneNumber">User phone number</param>
    public User(int id, string surname, string name, string patronymic, string phoneNumber)
    {
        Id = id;
        UserSurname = surname;
        UserName = name;
        UserPatronymic = patronymic;
        UserPhoneNumber = phoneNumber;
    }

    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="userObj">User class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? userObj)
    {
        if (userObj is not User param || GetType() != userObj.GetType()) return false;

        return UserSurname == param.UserSurname && UserName == param.UserName &&
               UserPatronymic == param.UserPatronymic && UserPhoneNumber == param.UserPhoneNumber;
    }

    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="userObj1">User class object</param>
    /// <param name="userObj2">User class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator ==(User userObj1, User userObj2)
    {
        return Object.Equals(userObj1, userObj2);
    }

    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="userObj1">User class object</param>
    /// <param name="userObj2">User class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator !=(User userObj1, User userObj2)
    {
        return !Object.Equals(userObj1, userObj2);
    }


    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns>Integer hash code</returns>
    public override int GetHashCode()
    {
        return UserSurname.GetHashCode();
    }
}

