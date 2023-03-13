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

    public Ticket() { }
    public Ticket(int ticketNumber)
    {
        TicketNumber = ticketNumber;
    }
}