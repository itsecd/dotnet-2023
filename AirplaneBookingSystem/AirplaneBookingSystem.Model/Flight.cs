using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneBookingSystem.Model;

/// <summary>
/// Сlass describing the flight of an airplane
/// </summary>
public class Flight
{
    /// <summary>
    /// Unique Id of flight
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Number of flight
    /// </summary>
    [Column("numberOfFlight")]
    public int NumberOfFlight { get; set; } = 0;
    /// <summary>
    /// Departure city
    /// </summary>
    [Column("departureCity")]
    public string DepartureCity { get; set; } = string.Empty;
    /// <summary>
    /// Arrival city
    /// </summary>
    [Column("arrivalCity")]
    public string ArrivalCity { get; set; } = string.Empty;
    /// <summary>
    /// Departure date
    /// </summary>
    [Column("departureDate")]
    public DateTime DepartureDate { get; set; } = new DateTime();
    /// <summary>
    /// Arrival date
    /// </summary>
    [Column("arrivalDate")]
    public DateTime ArrivalDate { get; set; } = new DateTime();
    /// <summary>
    /// List of tickets on this flight
    /// </summary>
    public List<Ticket> Tickets { get; set; } = new List<Ticket> { };
    /// <summary>
    /// Airplane of flight
    /// </summary>
    public Airplane Airplane { get; set; }
    [ForeignKey("Airplane")]
    [Column("airplaneId")]
    public int AirplaneId { get; set; }
    public Flight() { }
    public Flight(int id, int numberOfFlight, string departureCity, string arrivalCity, DateTime departureDate, DateTime arrivalDate, Airplane airplane)
    {
        Id = id;
        NumberOfFlight = numberOfFlight;
        DepartureCity = departureCity;
        ArrivalCity = arrivalCity;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        Airplane = airplane;
    }
}