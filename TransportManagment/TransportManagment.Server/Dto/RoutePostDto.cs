using TransportManagment.Classes;
namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of routes for method Post
/// </summary>
public class RoutePostDto
{
    /// <summary>
    /// Date of route
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// Time when transport drive out of route
    /// </summary>
    public TimeSpan TimeTo { get; set; } = new TimeSpan();
    /// <summary>
    /// Time when transport drive in of route
    /// </summary>
    public TimeSpan TimeFrom { get; set; } = new TimeSpan();
    /// <summary>
    /// TransportInRoute - Unique key of transport
    /// </summary>
    public Transport TransportInRoute { get; set; } = new();
    /// <summary>
    /// Driver - Unique key of driver
    /// </summary>
    public Driver DriverInRoute { get; set; } = new();
}