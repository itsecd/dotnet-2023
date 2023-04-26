using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain;

/// <summary>
///     Ride - a class that contains information about the rides made by passengers
/// </summary>
public class Ride
{
    /// <summary>
    ///     Id - unique identifier of the ride
    /// </summary>
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     DeparturePoint - a address where the ride starts
    /// </summary>
    [Required]
    public string DeparturePoint { get; set; } = string.Empty;

    /// <summary>
    ///     DestinationPoint - a address where the ride ends
    /// </summary>
    [Required]
    public string DestinationPoint { get; set; } = string.Empty;

    /// <summary>
    ///     RideDate - date and time when the ride started
    /// </summary>
    [Required]
    public DateTime RideDate { get; set; } = new();

    /// <summary>
    ///     RideTime - duration of the ride
    /// </summary>
    [Required]
    public TimeSpan RideTime { get; set; } = new();

    /// <summary>
    ///     Cost - cost of ride
    /// </summary>
    [Required]
    public uint Cost { get; set; } = 0;

    /// <summary>
    ///     PassengerId - passenger's unique identifier
    /// </summary>
    public ulong PassengerId { get; set; }
    [ForeignKey("PassengerId")]
    public Passenger Passenger { get; set; } = null!;

    /// <summary>
    ///     VehicleId - vehicle's unique identifier
    /// </summary>
    public ulong VehicleId { get; set; }
    [ForeignKey("VehicleId")]
    public Vehicle Vehicle { get; set; } = null!;
}