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
    public int Id { get; set; }
    /// <summary> 
    /// Trip date
    /// </summary>  
    [Required]
    public DateTime Date { get; set; }
    /// <summary>
    /// Trip start time
    /// </summary>
    [Required]
    public DateTime TimeOn { get; set; }
    /// <summary>
    /// Trip end time
    /// </summary>
    [Required]
    public DateTime TimeOff { get; set; }
    /// <summary>
    /// Trip route id
    /// </summary>
    [ForeignKey("Route")]
    public int RouteId { get; set; }
    /// <summary>
    /// Trip route
    /// </summary>
    public Routes? Route { get; set; }
    /// <summary>
    /// Transport id for the trip
    /// </summary>
    [ForeignKey("Transport")]
    public int TransportId { get; set; } 
    /// <summary>
    /// Transport for the trip
    /// </summary>
    public Transport? Transport { get; set; }
    /// <summary>
    /// Driver id for a trip
    /// </summary>
    [ForeignKey("Driver")]
    public int DriverId { get; set; }
    /// <summary>
    /// Driver for a trip
    /// </summary>
    public Driver? Driver { get; set; }
    public Trip() { }
    public Trip(int id, DateTime date, DateTime timeOn, DateTime timeOff, Routes route, Transport transport, Driver driver)
    {
        Id = id;
        Date = date;
        TimeOn = timeOn;
        TimeOff = timeOff;
        Route = route;
        Transport = transport;
        Driver = driver;
    }
    public Trip(int id, DateTime date, DateTime timeOn, DateTime timeOff, int routeId, int transportId, int driverId)
    {
        Id = id;
        Date = date;
        TimeOn = timeOn;
        TimeOff = timeOff;
        RouteId = routeId;
        TransportId = transportId;
        DriverId = driverId;
    }
}
