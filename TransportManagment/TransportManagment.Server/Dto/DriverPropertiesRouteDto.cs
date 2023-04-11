namespace TransportManagment.Server.Dto;
/// <summary>
/// Class for method GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravel
/// </summary>
public class DriverPropertiesRouteDto
{
    /// <summary>
    /// Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
    /// <summary>
    /// Average time in routes
    /// </summary>
    public double AvgTime { get; set; } = 0;
    /// <summary>
    /// Total time in routes
    /// </summary>
    public long SumTime { get; set; } = 0;
    /// <summary>
    /// Maximum time in route
    /// </summary>
    public long MaxTime { get; set; } = 0;
}
