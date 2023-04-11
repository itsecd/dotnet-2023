namespace TransportMgmtServer.Dto;

public class DriverPropertiesRouteDto
{
    /// <summary>
    /// Last name of driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// First name of driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Middle name of driver
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Trips amount
    /// </summary>
    public int TripsAmount { get; set; } = 0;
    /// <summary>
    /// Average time in routes
    /// </summary>
    public double AvgTime { get; set; } = 0;
    /// <summary>
    /// Max time in route
    /// </summary>
    public double MaxTime { get; set; } = 0;
}
