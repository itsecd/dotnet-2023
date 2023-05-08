using System.ComponentModel.DataAnnotations;

namespace TransportMgmt.Domain;
/// <summary>
/// Class TransportType is used to store information about type of transport
/// </summary>
public class TransportType
{
    /// <summary>
    /// Unique key of transport type
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Name type of trasport
    /// </summary>
    [Required]
    public string TypeName { get; set; } = string.Empty;
    public TransportType() { }
    public TransportType(int typeId, string typeName)
    {
        Id = typeId;
        TypeName = typeName;
    }
}
