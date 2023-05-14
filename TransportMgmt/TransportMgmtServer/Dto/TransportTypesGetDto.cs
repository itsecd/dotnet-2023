namespace TransportMgmtServer.Dto;

public class TransportTypesGetDto
{
    /// <summary>
    /// Unique key of transport type
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Name type of trasport
    /// </summary>
    public string TypeName { get; set; } = string.Empty;
}
