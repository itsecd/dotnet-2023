namespace TransportManagment.Server.Dto;
/// <summary>
/// Class for method GetTotalTimeTravelEveryTypeAndModel
/// </summary>
public class TransportTimeModelDto
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// type of transport
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Model of transport
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// the time when the transport was on the trip
    /// </summary>
    public long Time { get; set; } = 0;
}
