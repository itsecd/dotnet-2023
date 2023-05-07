using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxi.Domain;

/// <summary>
///     Ride - a class that contains information about the rides made by passengers
/// </summary>
[Table("ride")]
public class Ride
{
    /// <summary>
    ///     Id - unique identifier of the ride
    /// </summary>
    [Column("id")]
    [Key]
    public ulong Id { get; set; }

    /// <summary>
    ///     DeparturePoint - a address where the ride starts
    /// </summary>
    [Column("departure_point")]
    [Required]
    public string DeparturePoint { get; set; } = string.Empty;

    /// <summary>
    ///     DestinationPoint - a address where the ride ends
    /// </summary>
    [Column("destination_point")]
    [Required]
    public string DestinationPoint { get; set; } = string.Empty;

    /// <summary>
    ///     RideDate - date and time when the ride started
    /// </summary>
    [Column("ride_date")]
    [Required]
    public DateTime RideDate { get; set; }

    /// <summary>
    ///     RideTime - duration of the ride
    /// </summary>
    [Column("ride_time")]
    [Required]
    public TimeSpan RideTime { get; set; }

    /// <summary>
    ///     Cost - cost of ride
    /// </summary>
    [Column("cost")]
    [Required]
    public uint Cost { get; set; } = 0;

    /// <summary>
    ///     PassengerId - passenger's unique identifier
    /// </summary>
    [Column("passenger_id")]
    [ForeignKey("Passenger")]
    public ulong PassengerId { get; set; }

    /// <summary>
    ///     Passenger - the navigation property is a link to the Passenger object
    /// </summary>
    public Passenger Passenger { get; set; } = null!;

    /// <summary>
    ///     VehicleId - vehicle's unique identifier
    /// </summary>
    [Column("vehicle_id")]
    [ForeignKey("VehicleId")]
    public ulong VehicleId { get; set; }

    /// <summary>
    ///     Vehicle - the navigation property is a link to the Vehicle object
    /// </summary>
    public Vehicle Vehicle { get; set; } = null!;
}