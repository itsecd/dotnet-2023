using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain;

/// <summary>
///     Driver - a class that stores information about the driver of the vehicle
/// </summary>
public class Driver
{
    /// <summary>
    ///     Id - unique identifier of the driver
    /// </summary>
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     FirstName - first name of the driver
    /// </summary>
    [Required]
    [MaxLength(45)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the driver
    /// </summary>
    [Required]
    [MaxLength(45)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the driver
    /// </summary>
    [MaxLength(45)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Passport - a unique sequence of digits that are the series and number of the passport
    /// </summary>
    [Required]
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the driver
    /// </summary>
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
}