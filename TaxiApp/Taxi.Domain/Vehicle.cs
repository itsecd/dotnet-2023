namespace Taxi.Domain;

/// <summary>
///     Vehicle - a class that stores information about the particular vehicle used in the taxi
/// </summary>
public class Vehicle
{
    /// <summary>
    ///     Id - unique identifier of the vehicle
    /// </summary>
    public UInt64 Id { get; set; }

    /// <summary>
    ///     RegistrationCarPlate - a sequence of letters and numbers used to identify the vehicle in real life
    /// </summary>
    public string RegistrationCarPlate { get; set; } = String.Empty;

    /// <summary>
    ///     Colour - property that stores the colour of the vehicle
    /// </summary>
    public string Colour { get; set; } = String.Empty;

    /// <summary>
    ///     VehicleClassificationId - id of the vehicle class to which the car belongs
    /// </summary>
    public UInt64 VehicleClassificationId { get; set; }

    /// <summary>
    ///     DriverId - id of the driver who drives this vehicle
    /// </summary>
    public UInt64 DriverId { get; set; }

    /// <summary>
    ///     Rides - a list of the current vehicle`s rides
    /// </summary>
    public List<Ride> Rides { get; set; } = new();
}