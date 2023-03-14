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
    public DateTime DepartureDate { get; set; } = new DateTime();
    /// <summary>
    /// Arrival date
    /// </summary>
    public DateTime ArrivalDate { get; set; } = new DateTime();
    /// <summary>
    /// List of tickets on this flight
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket> { };
    public Flight() { }
    public Flight(int numberOfFlight, string departureCity, string arrivalCity, DateTime departureDate, DateTime arrivalDate)
    {
        NumberOfFlight = numberOfFlight;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
    }
}