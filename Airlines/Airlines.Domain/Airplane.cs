namespace Airlines.Domain;

/// <summary>
/// Сlass describing an airplane
/// </summary>
public class Airplane
{
    /// <summary>
    /// Represent an unique Id of Airplane 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a model of Airplane 
    /// </summary>
    public string? Model { get; set; }
    /// <summary>
    /// Represent a max value of carrying capacity
    /// </summary>
    public int CarryingCapacity { get; set; }
    /// <summary>
    /// Represent a max value of capability
    /// </summary>
    public int Capability { get; set; }
    /// <summary>
    /// Represent a max count of seats
    /// </summary>
    public int SeatingCapacity { get; set; }
    /// <summary>
    /// Represent a flights   
    /// </summary>
    public List<Flight> Flights { get; set; } = new List<Flight>();
    public Airplane() { }
}