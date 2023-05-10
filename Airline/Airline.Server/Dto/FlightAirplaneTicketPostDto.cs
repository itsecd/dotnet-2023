namespace Airline.Server.Dto;

/// <summary>
/// Class for post flightAirplaneTicket
/// </summary>
public class FlightAirplaneTicketPostDto
{
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
