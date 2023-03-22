
namespace TransportMgmt.Domain;

public class Route
{
    public int RouteId { get; set; } = 0;
    public DateOnly Date { get; set; } = new DateOnly();
    public DateTime TimeON { get; set; } = new DateTime();
    public DateTime TimeOFF { get; set; } = new DateTime();
    public Transport Transport { get; set; } = new Transport();
    public Driver Driver { get; set; } = new Driver();
    public Route() { }
    public Route(int routeId, DateOnly date, DateTime timeON, DateTime timeOFF, Transport transport, Driver driver)
    {
        RouteId = routeId;
        Date = date;
        TimeON = timeON;
        TimeOFF = timeOFF;
        Transport = transport;
        Driver = driver;
    }
}
