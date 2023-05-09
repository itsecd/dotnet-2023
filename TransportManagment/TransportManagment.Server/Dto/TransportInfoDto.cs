namespace TransportManagment.Server.Dto;
/// <summary>
/// Class for more info about transport
/// </summary>
public class TransportInfoDto
{
    /// <summary>
    /// type of transport
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Model of transport
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Date when make transport
    /// </summary>
    public DateTime DateMake { get; set; } = new DateTime();
    /// <summary>
    /// Count of routes for this transport
    /// </summary>
    public int Count { get; set; } = 0;
}