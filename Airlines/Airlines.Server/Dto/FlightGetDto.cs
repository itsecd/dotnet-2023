namespace Airlines.Server.Dto;

/// <summary>
/// Class for get method of flight table
/// </summary>
public class FlightGetDto
{
    /// <summary>
    /// Represent a unique Id of flight
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a unique Id of airplane
    /// </summary>
    public int AirplaneId { get; set; }
    /// <summary>
    /// Represent a number of flight
    /// </summary>
    public string? FlightCode { get; set; }
    /// <summary>
    /// Represent a point of departure
    /// </summary>
    public string? Source { get; set; }
    /// <summary>
    /// Represent a point of arrival
    /// </summary>
    public string? Destination { get; set; }
    /// <summary>
    /// Represent a departure date
    /// </summary>
    public DateTime DepartureDate { get; set; }
    /// <summary>
    /// Represent a arrival date
    /// </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary>
    /// Represent a flight duration
    /// </summary>
    public double FlightDuration { get; set; }
    /// <summary>
    /// Represent a type of airplane
    /// </summary>
    public string? AirplaneType { get; set; }
}