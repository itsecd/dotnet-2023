namespace Taxi.Server.Dto;

public class RidePostDto
{
    /// <summary>
    ///     DeparturePoint - a address where the ride starts
    /// </summary>
    public string DeparturePoint { get; set; } = string.Empty;

    /// <summary>
    ///     DestinationPoint - a address where the ride ends
    /// </summary>
    public string DestinationPoint { get; set; } = string.Empty;

    /// <summary>
    ///     RideDate - date and time when the ride started
    /// </summary>
    public DateTime RideDate { get; set; } = new();

    /// <summary>
    ///     RideTime - duration of the ride in seconds
    /// </summary>
    public uint RideTime { get; set; }

    /// <summary>
    ///     Cost - cost of ride
    /// </summary>
    public uint Cost { get; set; } = 0;

    /// <summary>
    ///     PassengerId - passenger's unique identifier
    /// </summary>
    public ulong PassengerId { get; set; }

    /// <summary>
    ///     VehicleId - vehicle's unique identifier
    /// </summary>
    public ulong VehicleId { get; set; }
}