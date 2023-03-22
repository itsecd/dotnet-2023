namespace TransportMgmt.Domain;

public class Trip
{
    public int TripId { get; set; } = 0;
    public DateOnly Date { get; set; } = new DateOnly();
    public DateTime TimeON { get; set; } = new DateTime();
    public DateTime TimeOFF { get; set; } = new DateTime();
    public Route Route { get; set; } = null!;
    public Transport Transport { get; set; } = new Transport();
    public Driver Driver { get; set; } = new Driver();
    public Trip() { }
    public Trip(int tripId, DateOnly date, DateTime timeON, DateTime timeOFF, Route route, Transport transport, Driver driver)
    {
        TripId = tripId;
        Date = date;
        TimeON = timeON;
        TimeOFF = timeOFF;
        Route = route;
        Transport = transport;
        Driver = driver;
    }
}
