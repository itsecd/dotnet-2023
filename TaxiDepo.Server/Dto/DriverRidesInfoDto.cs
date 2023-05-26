using TaxiDepo.Model;

namespace TaxiDepo.Server.Dto;

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
    public TimeSpan AverageTime { get; set; } = new();

    /// <summary>
    /// Max trip time
    /// </summary>
    public TimeSpan MaxTime { get; set; } = new();
}