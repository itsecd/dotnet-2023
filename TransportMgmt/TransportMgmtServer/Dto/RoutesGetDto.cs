namespace TransportMgmtServer.Dto;

public class RoutesGetDto
{
    /// <summary>
    /// Unique key of route
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Route number
    /// </summary>
    public string RouteNumber { get; set; } = string.Empty;
}
