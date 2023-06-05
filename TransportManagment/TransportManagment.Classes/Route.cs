using System.ComponentModel.DataAnnotations.Schema;

namespace TransportManagment.Model;
/// <summary>
/// Class of routes
/// </summary>
public class Route
{
    /// <summary>
    /// Unique key of route
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
    /// TransportId - Unique key of transport
    /// </summary>
    [ForeignKey("Transport")]
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Transport - transport
    /// </summary>
    public Transport? Transport { get; set; } = null!;
    /// <summary>
    /// Driver - Unique key of driver
    /// </summary>
    [ForeignKey("Driver")]
    public int DriverId { get; set; } = 0;
    /// <summary>
    /// Driver - driver
    /// </summary>
    public Driver? Driver { get; set; } = null!;
    public Route() { }
    public Route(int routeId, DateTime date, double timeTo, double timeFrom, int transportId, int driverId)
    {
        RouteId = routeId;
        Date = date;
        TimeTo = timeTo;
        TimeFrom = timeFrom;
        TransportId = transportId;
        DriverId = driverId;
    }
}