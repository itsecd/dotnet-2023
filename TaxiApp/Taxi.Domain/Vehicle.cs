using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain;

/// <summary>
///     Vehicle - a class that stores information about the particular vehicle used in the taxi
/// </summary>
public class Vehicle
{
    /// <summary>
    ///     Id - unique identifier of the vehicle
    /// </summary>
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     RegistrationCarPlate - a sequence of letters and numbers used to identify the vehicle in real life
    /// </summary>
    [Required]
    [MaxLength(9)]
    public string RegistrationCarPlate { get; set; } = string.Empty;

    /// <summary>
    ///     Colour - property that stores the colour of the vehicle
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Colour { get; set; } = string.Empty;

    /// <summary>
    ///     VehicleClassificationId - id of the vehicle class to which the car belongs
    /// </summary>
    public ulong VehicleClassificationId { get; set; }

    /// <summary>
    ///     DriverId - id of the driver who drives this vehicle
    /// </summary>
    public ulong DriverId { get; set; }
    [ForeignKey("DriverId")]
    public Driver Driver { get; set; } = null!;

    /// <summary>
    ///     Rides - a list of the current vehicle`s rides
    /// </summary>
    public List<Ride> Rides { get; set; } = new();
}