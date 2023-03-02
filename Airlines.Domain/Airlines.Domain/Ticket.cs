namespace Airlines.Domain;

/// <summary>
/// Class describing a ticket
/// </summary>
public class TicketClass
{
    /// <summary>
    /// Represent a unique Id of ticket
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Represent a number of ticket
    /// </summary>
    public int TicketNumber { get; set; } = 0;
    /// <summary>
    /// Represent a seatnumber of ticket
    /// </summary>
    public string SeatNumber { get; set; } = string.Empty;
    /// <summary>
    /// Represent a baggage weight, which passanger can move
    /// </summary>
    public int BaggageWeight { get; set; } = 0;
    public TicketClass() { }
    public TicketClass(int ticketNumber, string seatNumber, int baggageWeight)
    {
        TicketNumber = ticketNumber;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
    }
}
