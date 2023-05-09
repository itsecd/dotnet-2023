namespace Airline.Server.Dto;

/// <summary>
/// Class for post airplane
/// </summary>
public class AirplanePostDto
{
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