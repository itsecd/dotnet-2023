namespace AirplaneBookingSystem.Server.Dto;
public class TicketPostDto
{
    /// <summary>
    /// Number of ticket
    /// </summary>
    public int TicketNumber { get; set; } = 0;
    /// <summary>
    /// Сlient who owns the ticket
    /// </summary>
    public int ClientId { get; set; }
    /// <summary>
    /// Flight for which the ticket is registered
    /// </summary>
    public int FlightId { get; set; }
}
