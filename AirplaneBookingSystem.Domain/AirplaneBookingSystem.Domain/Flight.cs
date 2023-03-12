namespace AirplaneBookingSystem.Domain;

/// <summary>
/// Сlass describing the flight of an airplane
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique Id of flight
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Number of flight
    /// </summary>
    public int NumberOfFlight { get; set; } = 0;
    /// <summary>
    /// Departure city
    /// </summary>
    public string DepartureCity { get; set; } = string.Empty;
    /// <summary>
    /// Arrival city
    /// </summary>
    public string ArrivalCity { get; set; } = string.Empty;
    /// <summary>
    /// Departure date
    /// </summary>
    public DateOnly DepartureDate { get; set; } = new DateOnly();
    /// <summary>
    /// Arrival date
    /// </summary>
    public DateOnly ArrivalDate { get; set; } = new DateOnly();
    /// <summary>
    /// List of tickets on this flight
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket> { };
    public Flight() { }
    public Flight(int numberOfFlight, string departureCity, string arrivalCity, DateOnly departureDate, DateOnly arrivalDate)
    {
        NumberOfFlight = numberOfFlight;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        Tickets = new List<Ticket>();
    }
}