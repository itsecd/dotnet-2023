namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of routes for method Get
/// </summary>
public class RouteGetDto
{
    /// <summary>
    /// Date of route
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// Time when transport drive out of route
    /// </summary>
    public DateTime TimeTo { get; set; } = new DateTime();
    /// <summary>
    /// Time when transport drive in of route
    /// </summary>
    public DateTime TimeFrom { get; set; } = new DateTime();
    /// <summary>
    /// TransportId - Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Driver - Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
}