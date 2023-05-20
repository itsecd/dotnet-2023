namespace AirplaneBookingSystem.Server.Dto;
public class FlightGetDto
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
    public DateTimeOffset DepartureDate { get; set; } = new DateTimeOffset();
    /// <summary>
    /// Arrival date
    /// </summary>
    public DateTimeOffset ArrivalDate { get; set; } = new DateTimeOffset();
    /// <summary>
    /// Airplane`s id of flight
    /// </summary>
    public int AirplaneId { get; set; }
}