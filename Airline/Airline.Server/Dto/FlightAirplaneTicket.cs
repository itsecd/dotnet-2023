namespace Airline.Server.Dto;

/// <summary>
/// Class for post ticket
/// </summary>
public class FlightAirplaneTicketPostDto
{
    /// <summary>
    /// Represent id
    /// </summary>
    public int? Id { get; set; }
    /// <summary>
    /// Represent Flight id
    /// </summary>
    public string FlightId { get; set; }
    /// <summary>
    /// Represent Airplane id
    /// </summary>
    public double AirplaneId { get; set; }
    /// <summary>
    /// Represent Ticket id
    /// </summary>
    public double TicketId { get; set; }
}
