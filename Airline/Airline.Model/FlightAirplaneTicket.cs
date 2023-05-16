using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineModel;
public class FlightAirplaneTicket
{   /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Flight id
    /// </summary>
    [ForeignKey("Flight")]
    [Required]
    public int FlightId { get; set; } = 0;
    /// <summary>
    /// Airplane id
    /// </summary>
    [ForeignKey("Airplane")]
    [Required]
    public int AirplaneId { get; set; } = 0;
    /// <summary>
    /// Ticket id
    /// </summary>
    [ForeignKey("Ticket")]
    [Required]
    public int TicketId { get; set; } = 0;
    public FlightAirplaneTicket(int id, int flightId, int airplaneId, int ticketId)
    {
        Id = id;
        FlightId = flightId;
        AirplaneId = airplaneId;
        TicketId = ticketId;
    }
}
