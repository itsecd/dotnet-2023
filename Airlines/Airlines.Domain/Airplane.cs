using System.ComponentModel.DataAnnotations;

namespace Airlines.Domain;

/// <summary>
/// Сlass describing an airplane
/// </summary>
public class Airplane
{
    /// <summary>
    /// Represent an unique Id of Airplane 
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Represent a model of Airplane 
    /// </summary>
    [Required]
    public string? Model { get; set; }
    /// <summary>
    /// Represent a max value of carrying capacity
    /// </summary>
    [Required]
    public int CarryingCapacity { get; set; }
    /// <summary>
    /// Represent a max value of capability
    /// </summary>
    [Required]
    public int Capability { get; set; }
    /// <summary>
    /// Represent a max count of seats
    /// </summary>
    [Required]
    public int SeatingCapacity { get; set; }
    /// <summary>
    /// Represent a flights   
    /// </summary>
    public List<Flight> Flights { get; set; } = new List<Flight>();
    public Airplane() { }
}