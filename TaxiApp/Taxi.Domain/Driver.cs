using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain;

/// <summary>
///     Driver - a class that stores information about the driver of the vehicle
/// </summary>
[Table("driver")]
public class Driver
{
    /// <summary>
    ///     Id - unique identifier of the driver
    /// </summary>
    [Column("id")]
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     FirstName - first name of the driver
    /// </summary>
    [Column("first_name")]
    [Required]
    [MaxLength(45)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the driver
    /// </summary>
    [Column("last_name")]
    [Required]
    [MaxLength(45)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the driver
    /// </summary>
    [Column("patronymic")]
    [MaxLength(45)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Passport - a unique sequence of digits that are the series and number of the passport
    /// </summary>
    [Column("passport")]
    [Required]
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the driver
    /// </summary>
    [Column("phone_number")]
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
}