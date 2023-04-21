namespace Airlines.Domain;

/// <summary>
/// Class describing a ticket
/// </summary>
public class Ticket
{
    /// <summary>
    /// Represent a unique Id of ticket
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a unique Id of passenger
    /// </summary>
    public int PassengerId { get; set; }
    /// <summary>
    /// Represent a unique Id of flight
    /// </summary>
    public int FlightId { get; set; }
    /// <summary>
    /// Represent a number of ticket
    /// </summary>
    public int TicketNumber { get; set; }
    /// <summary>
    /// Represent a seatnumber of ticket
    /// </summary>
    public string? SeatNumber { get; set; }
    /// <summary>
    /// Represent a baggage weight, which passanger can move
    /// </summary>
    public int BaggageWeight { get; set; } = 0;
    public Ticket() { }
    public Ticket(int ticketNumber, string seatNumber, int baggageWeight)
    {
        TicketNumber = ticketNumber;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
    }
}