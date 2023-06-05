namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of routes for method Get
/// </summary>
public class RouteGetDto
{
    /// <summary>
    /// Id of route
    /// </summary>
    public int RouteId { get; set; } = 0;
    /// <summary>
    /// Date of route
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// Time when transport drive out of route
    /// </summary>
    public double TimeTo { get; set; } = 0;
    /// <summary>
    /// Time when transport drive in of route
    /// </summary>
    public double TimeFrom { get; set; } = 0;
    /// <summary>
    /// TransportInRoute - Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Driver - Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
}