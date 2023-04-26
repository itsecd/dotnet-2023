using System.ComponentModel.DataAnnotations;

namespace Taxi.Domain;

/// <summary>
///     Passenger - a class that stores information about passenger
/// </summary>
public class Passenger
{
    /// <summary>
    ///     Id - unique identifier of the passenger
    /// </summary>
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     FirstName - first name of the passenger
    /// </summary>
    [Required]
    [MaxLength(45)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the passenger
    /// </summary>
    [Required]
    [MaxLength(45)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the passenger
    /// </summary>
    [MaxLength(45)]
    public string? Patronymic { get; set; }

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the passenger
    /// </summary>
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Rides - a list of the current passenger's rides
    /// </summary>
    public List<Ride> Rides { get; set; } = new();
}