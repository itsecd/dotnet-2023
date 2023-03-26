namespace TransportMgmt.Domain;
/// <summary>
/// Class Trip is used to store information about transport trips
/// </summary>
public class Trip
{
    /// <summary>
    /// Unique key of trip
    /// </summary>
    public int TripId { get; set; } = 0;
    /// <summary>
    /// Trip date
    /// </summary> 
    public DateOnly Date { get; set; } = new DateOnly();
    /// <summary>
    /// Trip start time
    /// </summary>
    public DateTime TimeON { get; set; } = new DateTime();
    /// <summary>
    /// Trip end time
    /// </summary>
    public DateTime TimeOFF { get; set; } = new DateTime();
    /// <summary>
    /// Trip route
    /// </summary>
    public Route Route { get; set; } = null!;
    /// <summary>
    /// Transport for the trip
    /// </summary>
    public Transport Transport { get; set; } = new Transport();
    /// <summary>
    /// 
    /// </summary>
    public Driver Driver { get; set; } = new Driver();
    /// <summary>
    /// Driver for a trip
    /// </summary>
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
