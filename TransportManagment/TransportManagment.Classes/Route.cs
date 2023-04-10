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
    public DateTime TimeTo { get; set; } = new DateTime();
    /// <summary>
    /// Time when transport drive in of route
    /// </summary>
    public DateTime TimeFrom { get; set; } = new DateTime();
    /// <summary>
    /// Transport - transport
    /// </summary>
    public Transport Transport { get; set; } = new Transport();
    /// <summary>
    /// Driver - driver
    /// </summary>
    public Driver Driver { get; set; } = new Driver();
    /// <summary>
    /// TransportId - Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Driver - Unique key of driver
    /// </summary>
    public int DriverId { get; set; } = 0;
    public Route() { }
    public Route(int routeId, DateTime date, DateTime timeTo, DateTime timeFrom, Transport transport, Driver driver, int transpotrId, int driverId)
    {
        RouteId = routeId;
        Date = date;
        TimeTo = timeTo;
        TimeFrom = timeFrom;
        Transport = transport;
        Driver = driver;
        TransportId = transpotrId;
        DriverId = driverId;
    }
}