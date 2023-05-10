using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     the Client class stores information about the client
/// </summary>
[Table("client")]
public class Client
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     LastName - information about the client's last name
    /// </summary>
    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     FirstName - information about the client's first name
    /// </summary>
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - information about the client's patronymic
    /// </summary>
    [Column("patronymic")]
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    ///     BirthDate - date and time of birth
    /// </summary>
    [Column("birth_date")]
    public DateTime BirthDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     Passport - passport series and number
    /// </summary>
    [Column("passport")]
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    ///     RentedCars stores all records of rented cars
    /// </summary>
    public List<IssuedCar> RentedCars { get; set; } = new();
}