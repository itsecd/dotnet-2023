using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlines.Domain;

/// <summary>
/// Class describing a ticket
/// </summary>
public class Ticket
{
    /// <summary>
    /// Represent a unique Id of ticket
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Represent a unique Id of passenger
    /// </summary>
    [ForeignKey("Passenger")]
    public int PassengerId { get; set; }
    /// <summary>
    /// Represent a unique Id of flight
    /// </summary>
    [ForeignKey("Flight")]
    public int FlightId { get; set; }
    /// <summary>
    /// Represent a number of ticket
    /// </summary>
    [Required]
    public int TicketNumber { get; set; }
    /// <summary>
    /// Represent a seatnumber of ticket
    /// </summary>
    [Required]
    public string? SeatNumber { get; set; }
    /// <summary>
    /// Represent a baggage weight, which passanger can move
    /// </summary>
    [Required]
    public int BaggageWeight { get; set; }
    public Ticket() { }
    public Ticket(int ticketNumber, string seatNumber, int baggageWeight)
    {
        TicketNumber = ticketNumber;
        SeatNumber = seatNumber;
        BaggageWeight = baggageWeight;
    }
}