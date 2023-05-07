using System.ComponentModel.DataAnnotations.Schema;
namespace TransportManagment.Classes;
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
    public TimeSpan TimeTo { get; set; } = new TimeSpan();
    /// <summary>
    /// Time when transport drive in of route
    /// </summary>
    public TimeSpan TimeFrom { get; set; } = new TimeSpan();
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
    public Route(int routeId, DateTime date, TimeSpan timeTo, TimeSpan timeFrom, int transportId, int driverId)//, Transport transport, Driver driver
    {
        RouteId = routeId;
        Date = date;
        TimeTo = timeTo;
        TimeFrom = timeFrom;
        //Transport = transport;
        //Driver = driver;
        TransportId = transportId;
        DriverId = driverId;
    }
}