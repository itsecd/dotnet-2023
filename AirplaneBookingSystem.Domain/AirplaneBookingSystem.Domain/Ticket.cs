namespace AirplaneBookingSystem.Domain;

/// <summary>
/// Class describing a ticket
/// </summary>
public class Ticket
{
    /// <summary>
    /// Unique Id of ticket
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Number of ticket
    /// </summary>
    public int TicketNumber { get; set; } = 0;
    /// <summary>
    /// Сlient who owns the ticket
    /// </summary>
    public Client Client { get; set; }
    /// <summary>
    /// Client`s id of ticket
    /// </summary>
    public int ClientId { get; set; }
    /// <summary>
    /// Flight for which the ticket is registered
    /// </summary>
    public Flight Flight { get; set; }
    /// <summary>
    /// Flight`s id of ticket
    /// </summary>
    public int FlightId { get; set; }
    public Ticket() { }
    public Ticket(int id, int ticketNumber, Client client, Flight flight)
    {
        Id = id;
        TicketNumber = ticketNumber;
        Client = client;
        Flight = flight;
    }
}