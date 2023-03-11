namespace Taxi.Domain;

/// <summary>
///     Ride - a class that contains information about the rides made by passengers
/// </summary>
public class Ride
{
    /// <summary>
    ///     Id - unique identifier of the ride
    /// </summary>
    public UInt64 Id { get; set; }

    /// <summary>
    ///     DeparturePoint - a address where the ride starts
    /// </summary>
    public string DeparturePoint { get; set; } = String.Empty;

    /// <summary>
    ///     DestinationPoint - a address where the ride ends
    /// </summary>
    public string DestinationPoint { get; set; } = String.Empty;

    /// <summary>
    ///     RideDate - date and time when the ride started
    /// </summary>
    public DateTime RideDate { get; set; } = new();

    /// <summary>
    ///     RideTime - duration of the ride
    /// </summary>
    public TimeOnly RideTime { get; set; } = new();

    /// <summary>
    ///     Cost - cost of ride
    /// </summary>
    public UInt32 Cost { get; set; } = 0;

    /// <summary>
    ///     PassengerId - passenger's unique identifier
    /// </summary>
    public UInt64 PassengerId { get; set; }

    /// <summary>
    ///     VehicleId - vehicle's unique identifier
    /// </summary>
    public UInt64 VehicleId { get; set; }
}