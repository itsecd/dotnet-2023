namespace Airlines.Server.Dto;

/// <summary>
/// Class for post method of ticket table
/// </summary>
public class TicketPostDto
{
    /// <summary>
    /// Represent a number of ticket
    /// </summary>
    public int? TicketNumber { get; set; }
    /// <summary>
    /// Represent a seat number of ticket
    /// </summary>
    public string? SeatNumber { get; set; }
    /// <summary>
    /// Represent a baggage weight, which passenger can move
    /// </summary>
    public int BaggageWeight { get; set; }
}