using TaxiDepo.Model;

namespace TaxiDepo.Server.Dto;

/// <summary>
/// Driver rides dto
/// </summary>
public class DriverRidesInfoDto
{
    /// <summary>
    /// Driver surname
    /// </summary>
    public string DriverSurname { get; set; } = string.Empty;

    /// <summary>
    /// Driver name
    /// </summary>
    public string DriverName { get; set; } = string.Empty;

    /// <summary>
    /// Driver patronymic
    /// </summary>
    public string? DriverPatronymic { get; set; }

    /// <summary>
    /// Amount rides
    /// </summary>
    public int AmountRides { get; set; }

    /// <summary>
    /// Average trip time
    /// </summary>
    public double AverageTime { get; set; } = new();

    /// <summary>
    /// Max trip time
    /// </summary>
    public double MaxTime { get; set; } = new();
}