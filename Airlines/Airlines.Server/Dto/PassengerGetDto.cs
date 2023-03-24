namespace Airlines.Server.Dto;

/// <summary>
/// Class for get method of passenger table
/// </summary>
public class PassengerGetDto
{
    /// <summary>
    /// Represent a unique Id of passanger
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
