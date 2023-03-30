namespace RentalService.Domain;

/// <summary>
///     class VehicleModel contains all the information about the car model
/// </summary>
public class VehicleModel
{
    /// <summary>
    ///     Id - unique Model identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Model - car model
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Brand - car brand
    /// </summary>
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    ///     Vehicles - all cars with this model
    /// </summary>
    public List<Vehicle> Vehicles { get; set; } = new();
}