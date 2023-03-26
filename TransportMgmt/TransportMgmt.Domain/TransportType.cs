namespace TransportMgmt.Domain;
/// <summary>
/// Class TransportType is used to store information about type of transport
/// </summary>
public class TransportType
{
    /// <summary>
    /// Unique key of transport type
    /// </summary>
    public int TypeId { get; set; }
    /// <summary>
    /// Name type of trasport
    /// </summary>
    public string TypeName { get; set; } = string.Empty;
    public TransportType() { }
    public TransportType(int typeId, string typeName)
    {
        TypeId = typeId;
        TypeName = typeName;
    }
}
