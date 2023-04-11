namespace TransportMgmtServer.Dto;

public class TripGetDto
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
    public int RouteId { get; set; } = 0;
    /// <summary>
    /// Transport for the trip
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Driver for a trip
    /// </summary>
    public int DriverId { get; set; } = 0;
}
