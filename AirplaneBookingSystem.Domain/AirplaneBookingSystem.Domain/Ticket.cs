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
    public Client Client { get; set; }
    public Flight Flight { get; set; }

    public Ticket() { }

    public Ticket(int ticketNumber, Client client, Flight flight)
    {
        TicketNumber = ticketNumber;
        Client = client;
        Flight = flight;
    }
}