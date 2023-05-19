namespace Taxi.Server.Dto;

public class VehicleClassificationSetDto
{
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