using AirLine.Domain;
namespace Airline.Server.Dto;

/// <summary>
/// Class for post flight
/// </summary>
public class FlightPostDto
{
    /// <summary>
    /// Cipher of flight
    /// </summary>
    public string Cipher { get; set; }
    /// <summary>
    /// Field departure place 
    /// </summary>
    public string DeparturePlace { get; set; }
    /// <summary>
    /// Field destination
    /// </summary>
    public string Destination { get; set; }
    /// <summary>
    /// Field date of departure
    /// </summary>
    public DateTime? DepartureDate { get; set; }
    /// <summary>
    /// Field date of arrival
    /// </summary>
    public DateTime? ArrivalDate { get; set; }
    /// <summary>
    /// Flight time
    /// </summary>
    public TimeSpan FlightTime { get; set; }
    /// <summary>
    /// type airplane on flight
    /// </summary>
    public Airplane? Airplane { get; set; }
    /// <summary>
    /// List of tickets on flight
    /// </summary>
    public List<Ticket>? Tickets { get; set; }
}