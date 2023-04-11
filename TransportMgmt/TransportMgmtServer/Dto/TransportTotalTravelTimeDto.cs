namespace TransportMgmtServer.Dto;

public class TransportTotalTravelTimeDto
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Transport state number
    /// </summary>
    public string StateNumber { get; set; } = string.Empty;
    /// <summary>
    /// Transport type
    /// </summary>
    public string TypeName { get; set; } = string.Empty;
    /// <summary>
    /// Transport model id
    /// </summary>
    public string ModelName { get; set; } = string.Empty;
    /// <summary>
    /// Transport Total travel time
    /// </summary>
    public double TotalTravelTime { get; set; } = 0;
}
