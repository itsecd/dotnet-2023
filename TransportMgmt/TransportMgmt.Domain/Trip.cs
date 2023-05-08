using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportMgmt.Domain;
/// <summary>
/// Class Trip is used to store information about transport trips
/// </summary>
public class Trip
{
    /// <summary>
    /// Unique key of trip
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Trip date
    /// </summary>  
    [Required] 
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// Trip start time
    /// </summary>
    [Required] 
    public DateTime TimeOn { get; set; } = new DateTime();
    /// <summary>
    /// Trip end time
    /// </summary>
    [Required] 
    public DateTime TimeOff { get; set; } = new DateTime();
    /// <summary>
    /// Trip route id
    /// </summary>
    [ForeignKey("RouteId")]
    public int RouteId { get; set; }
    /// <summary>
    /// Trip route
    /// </summary>
    public Routes Route { get; set; } = null!;
    /// <summary>
    /// Transport id for the trip
    /// </summary>
    [ForeignKey("TransportId")]
    public int TransportId { get; set; }
    /// <summary>
    /// Transport for the trip
    /// </summary>
    public Transport Transport { get; set; } = new Transport();
    /// <summary>
    /// Driver id for a trip
    /// </summary>
    [ForeignKey("DriverId")]
    public int DriverId { get; set; }
    /// <summary>
    /// Driver for a trip
    /// </summary>
    public Driver Driver { get; set; } = new Driver();
    public Trip() { }
    public Trip(int id, DateTime date, DateTime timeOn, DateTime timeOff, int routeId, Routes route, int transportId, Transport transport, int driverId, Driver driver)
    {
        Id = id;
        Date = date;
        TimeOn = timeOn;
        TimeOff = timeOff;
        RouteId = routeId;
        Route = route;
        TransportId = transportId;
        Transport = transport;
        DriverId = driverId;
        Driver = driver;
    }
}
