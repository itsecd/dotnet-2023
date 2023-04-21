namespace TaxiDepo.Server.Dto;

/// <summary>
/// Dto car class
/// </summary>
public class CarDto
{
    /// <summary>
    /// Car id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Car government number
    /// </summary>
    public string CarNumber { get; set; } = string.Empty;
    /// <summary>
    /// Car model
    /// </summary>
    public string CarModel { get; set; } = string.Empty;
    /// <summary>
    /// Car color
    /// </summary>
    public string CarColor { get; set; } = string.Empty;
    /// <summary>
    /// Indicator that the driver is assigned to the car
    /// </summary>
    public bool CarIsAssigned { get; set; } = false;
    /// <summary>
    /// Car amount rides
    /// </summary>
    public int AmountRides { get; set; } = 0;
}