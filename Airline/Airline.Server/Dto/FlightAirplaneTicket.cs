namespace Airline.Server.Dto;

/// <summary>
/// Class for post ticket
/// </summary>
public class FlightAirplaneTicketPostDto
{
    /// <summary>
    /// Represent ticket number
    /// </summary>
    public int? Number { get; set; }
    /// <summary>
    /// Represent seat number
    /// </summary>
    public string SeatNumber { get; set; }
    /// <summary>
    /// Represent baggage weight
    /// </summary>
    public double BaggageWeight { get; set; }
}
