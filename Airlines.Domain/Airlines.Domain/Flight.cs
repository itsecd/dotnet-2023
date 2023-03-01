namespace Airlines.Domain;

/// <summary>
/// Сlass describing the flight of an airplane
/// </summary>
public class FlightCLass
{
    /// <summary>
    /// Represent a unique Id of flight
    /// </summary>
    public int Id { get; set; } = 0;
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
    public string Source { get; set; } = string.Empty;
    /// <summary>
    /// Represent a point of arrival
    /// </summary>
    public string Destination { get; set; } = string.Empty;
    /// <summary>
    /// Represent a departure date
    /// </summary>
    public DateOnly DepartureDate { get; set; } = new DateOnly();
    /// <summary>
    /// Represent a arrival date
    /// </summary>
    public DateOnly ArrivalDate { get; set; } = new DateOnly();
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
    public List<TicketClass> Tickets { get; set; } = new List<TicketClass> { };
    public FlightCLass() { }
    public FlightCLass(int number, string flightCode, string source,
        string destination, DateOnly departureDate,
        DateOnly arrivalDate, double flightDuration, string airplaneType)
    {
        Number = number;
        FlightCode = flightCode;
        Source = source;
        Destination = destination;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        FlightDuration = flightDuration;
        AirplaneType = airplaneType;
        Tickets = new List<TicketClass>();
    }
}
