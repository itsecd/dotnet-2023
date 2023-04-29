using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain;

/// <summary>
///     VehicleClassification - a class that stores information about the class of vehicles that can be used in taxi
/// </summary>
[Table("vehicle_classification")]
public class VehicleClassification
{
    /// <summary>
    ///     Id - a unique identifier of vehicle class
    /// </summary>
    [Column("id")]
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     Brand - a name of the company that makes the vehicle
    /// </summary>
    [Column("brand")]
    [Required]
    [MaxLength(45)]
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    ///     Model - a name that manufacturers use to identify and sell cars
    /// </summary>
    [Column("model")]
    [Required]
    [MaxLength(45)]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Class - a vehicle belonging to a certain type of vehicle.
    /// </summary>
    [Column("class")]
    [Required]
    [MaxLength(5)]
    public string Class { get; set; } = string.Empty;
}