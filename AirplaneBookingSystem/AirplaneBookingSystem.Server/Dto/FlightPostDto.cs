namespace AirplaneBookingSystem.Server.Dto;
public class FlightPostDto
{
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
    /// Airplane`s id of flight
    /// </summary>
    public int AirplaneId { get; set; }
}