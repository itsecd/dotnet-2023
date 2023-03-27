namespace RentalService.Domain;

/// <summary>
/// class VehicleModel contains all the information about the car model
/// </summary>
public class VehicleModel
{
    /// <summary>
    /// Id - unique Model ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// Model - car model
    /// </summary>
    public string Model{ get; set; } = string.Empty;

    /// <summary>
    /// Brand - car brand
    /// </summary>
    public string Brand { get; set; } = string.Empty;
}