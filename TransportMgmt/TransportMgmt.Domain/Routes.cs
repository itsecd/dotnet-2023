namespace TransportMgmt.Domain;
/// <summary>
/// Class Route is used to store information about routes
/// </summary>
public class Routes
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
