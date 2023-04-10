namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of transports for method Post
/// </summary>
public class TransportPostDto
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
}