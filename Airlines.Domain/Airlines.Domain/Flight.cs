namespace Airlines.Domain;

/// <summary>
/// Сlass describing the flight of an airplane
/// </summary>
public class FlightCLass
{
    /// <summary>
    /// Represent a unique ID of flight
    /// </summary>
    public int ID { get; set; } = 0;
    /// <summary>
    /// Represent a number of flight
    /// </summary>
    public int Number { get; set; } = 0;
    /// <summary>
    /// represent a flight code of flight
    /// </summary>
    public string FlightCode { get; set; } = string.Empty;
    /// <summary>
    /// Represent a point of departure
    /// </summary>
    public string Source { get; set; }= string.Empty;
    /// <summary>
    /// Represent a point of arrival
    /// </summary>
    public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// Represent a depature date
    /// </summary>
    public DateOnly DepartureDate { get; set; } = new DateOnly();
    /// <summary>
    /// Represent a arrival date
    /// </summary>
    public DateOnly ArrivalDate { get; set; }= new DateOnly();
    /// <summary>
    /// Represent a flight duration
    /// </summary>
    public double FlightDuration { get; set; } = 0;
    /// <summary>
    /// Represent a type of airplane
    /// </summary>
    public string AirplaneType { get; set; } = string.Empty;
    /// <summary>
    /// Represent a list of tickets on this flight
    /// </summary>
    public List<TicketClass> Tickets { get; set; }= new List<TicketClass> { };
    public FlightCLass() { }
    public FlightCLass(int number,string flightcode,string source,
        string destination,DateOnly departuredate,
        DateOnly arrivaldate,double flightduration,string airplanetype){
        Number = number;
        FlightCode = flightcode;
        Source = source;
        Destination = destination;
        DepartureDate = departuredate;
        ArrivalDate = arrivaldate;
        FlightDuration = flightduration;
        AirplaneType = airplanetype;
        Tickets = new List<TicketClass>();
    }
}
