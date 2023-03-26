namespace Taxi.Server.Dto;

public class VehicleGetDto
{
    /// <summary>
    ///     Id - unique identifier of the vehicle
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     RegistrationCarPlate - a sequence of letters and numbers used to identify the vehicle in real life
    /// </summary>
    public string RegistrationCarPlate { get; set; } = string.Empty;

    /// <summary>
    ///     Colour - property that stores the colour of the vehicle
    /// </summary>
    public string Colour { get; set; } = string.Empty;

    /// <summary>
    ///     VehicleClassificationId - id of the vehicle class to which the car belongs
    /// </summary>
    public ulong VehicleClassificationId { get; set; }

    /// <summary>
    ///     DriverId - id of the driver who drives this vehicle
    /// </summary>
    public ulong DriverId { get; set; }
}