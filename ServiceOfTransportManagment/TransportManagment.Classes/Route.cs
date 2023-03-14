namespace TransManagment.Domain;
public class Route
{
    /// <summary>
    /// Unique key of route
    /// </summary>
    public int RouteId { get; set; } = 0;
    /// <summary>
    /// Date of route
    /// </summary>
    public DateOnly Date { get; set; } = new DateOnly();
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
    public Route() { }
    public Route(int routeId, DateOnly date, DateTime timeTo, DateTime timeFrom, Transport transport, Driver driver)
    {
        RouteId = routeId;
        Date = date;
        TimeTo = timeTo;
        TimeFrom = timeFrom;
        Transport = transport;
        Driver = driver;
    }
}