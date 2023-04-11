namespace TransportMgmt.Domain;
/// <summary>
/// Class Trip is used to store information about transport trips
/// </summary>
public class Trip
{
    /// <summary>
    /// Unique key of trip
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Trip date
    /// </summary>  
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// Trip start time
    /// </summary>
    public DateTime TimeOn { get; set; } = new DateTime();
    /// <summary>
    /// Trip end time
    /// </summary>
    public DateTime TimeOff { get; set; } = new DateTime();
    /// <summary>
    /// Trip route
    /// </summary>
    public Routes Route { get; set; } = null!;
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
    public Trip(int tripId, DateTime date, DateTime timeOn, DateTime timeOff, Routes route, Transport transport, Driver driver)
    {
        Id = tripId;
        Date = date;
        TimeOn = timeOn;
        TimeOff = timeOff;
        Route = route;
        Transport = transport;
        Driver = driver;
    }
}
