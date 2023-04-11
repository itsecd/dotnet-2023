namespace TransportMgmtServer.Dto;

public class ModelPostDto
{
    /// <summary>
    /// Transport model name
    /// </summary>
    public string ModelName { get; set; } = string.Empty;
    /// <summary>
    /// Transport model floor level
    /// </summary>
    public string FloorLevel { get; set; } = string.Empty;
    /// <summary>
    /// Maximum capacity of transport model
    /// </summary>
    public int MaxCapacity { get; set; } = 0;
}
