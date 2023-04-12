namespace Airline.Server.Dto;

/// <summary>
/// Class for get passengers
/// </summary>
public class PassengerGetDto
{
    /// <summary>
    /// Represent id of passanger
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represent a passport number 
    /// </summary>
    public string? PassportNumber { get; set; }
    /// <summary>
    /// Represent a passenger name
    /// </summary>
    public string? Name { get; set; }
}