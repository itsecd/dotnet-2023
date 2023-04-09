namespace AirplaneBookingSystem.Domain;
/// <summary>
/// Сlass describing an airplane
/// </summary>
public class Airplane
{
    /// <summary>
    /// Unique Id of Airplane 
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    ///  Model of Airplane 
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// A flights   
    /// </summary>
    public List<Flight> Flights { get; set; } = new List<Flight>();
    public Airplane() { }
    public Airplane(int id, string model)
    {
        Id = id;
        Model = model;
    }
}
