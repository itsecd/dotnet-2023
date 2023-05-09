namespace Airline.Server.Dto;

/// <summary>
/// Class for get airplane
/// </summary>
public class AirplaneGetDto
{
    public int Id { get; set; }
    /// <summary>
    /// Airplane model
    /// </summary>
    public string Model { get; set; }
    /// <summary>
    /// Airplane load capacity
    /// </summary>
    public int LoadCapacity { get; set; }
    /// <summary>
    /// Airplane perfomance
    /// </summary>
    public int Perfomance { get; set; }
    /// <summary>
    /// Airplane passengers capacity
    /// </summary>
    public int PassengerCapacity { get; set; }
}