using TaxiDepo.Domain;

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
    /// Assigned driver Id
    /// </summary>
    public int DriverId { get; set; }
    /// <summary>
    /// Assigned driver
    /// </summary>
    public Driver? AssignedDriver { get; set; }
}