namespace Taxi.Domain;

/// <summary>
///     VehicleClassification - a class that stores information about the class of vehicles that can be used in taxi
/// </summary>
public class VehicleClassification
{
    /// <summary>
    ///     Id - a unique identifier of vehicle class
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Brand - a name of the company that makes the vehicle
    /// </summary>
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    ///     Model - a name that manufacturers use to identify and sell cars
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Class - a vehicle belonging to a certain type of vehicle.
    /// </summary>
    public string Class { get; set; } = string.Empty;
}