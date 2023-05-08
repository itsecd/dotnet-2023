using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportMgmt.Domain;
/// <summary>
/// Class Transport is used to store information about transport
/// </summary>
public class Transport
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Transport state number
    /// </summary>
    [Required] 
    public string StateNumber { get; set; } = string.Empty;
    /// <summary>
    /// Transport type id
    /// </summary>
    [ForeignKey("TransportTypeId")]
    public int TypeId { get; set; }
    /// <summary>
    /// Transport type
    /// </summary>
    public TransportType Type { get; set; } = null!;
    /// <summary>
    /// Transport model id
    /// </summary>
    [ForeignKey("ModelId")]
    public int ModelId { get; set; }
    /// <summary>
    /// Transport model
    /// </summary>
    [Required]
    public Model Model { get; set; } = new Model();
    /// <summary>
    /// Transport production date
    /// </summary>
    [Required] 
    public DateTime DateMake { get; set; } = new DateTime();
    public Transport() { }
    public Transport(int transportId, string stateNumber,int typeId, TransportType type, int modelId, Model model, DateTime dateMake)
    {
        Id = transportId;
        StateNumber = stateNumber;
        TypeId= typeId;
        Type = type;
        ModelId = modelId;
        Model = model;
        DateMake = dateMake;
    }
}
