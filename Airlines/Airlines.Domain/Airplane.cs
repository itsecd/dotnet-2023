namespace Airlines.Domain;

/// <summary>
/// Сlass describing an airplane
/// </summary>
public class AirplaneClass
{
    /// <summary>
    /// Represent an unique Id of Airplane 
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Represent a model of Airplane 
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Represent a max value of carrying capacity
    /// </summary>
    public int CarryingCapacity { get; set; } = 0;
    /// <summary>
    /// Represent a max value of capability
    /// </summary>
    public int Capability { get; set; } = 0;
    /// <summary>
    /// Represent a max count of seats
    /// </summary>
    public int SeatingCapacity { get; set; } = 0;
    /// <summary>
    /// Represent a flights   
    /// </summary>
    public List<FlightCLass> Flights { get; set; } = new List<FlightCLass>();
    public AirplaneClass() { }
    public AirplaneClass(string model, int carryingCapacity, int capability, int seatingCapacity)
    {
        Model = model;
        CarryingCapacity = carryingCapacity;
        Capability = capability;
        SeatingCapacity = seatingCapacity;
        Flights = new List<FlightCLass>();
    }
}
