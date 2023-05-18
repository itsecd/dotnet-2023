using System.ComponentModel.DataAnnotations;

namespace TransportMgmt.Domain;
/// <summary>
/// Class Model is used to store information about transport models
/// </summary>
public class Model
{
    /// <summary>
    /// Unique key of model
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Transport model name
    /// </summary>
    [Required]
    public string ModelName { get; set; } = string.Empty;
    /// <summary>
    /// Transport model floor level
    /// </summary>
    [Required]
    public string FloorLevel { get; set; } = string.Empty;
    /// <summary>
    /// Maximum capacity of transport model
    /// </summary>
    [Required]
    public int MaxCapacity { get; set; }
    public Model() { }
    public Model(int modelId, string modelName, string floorLevel, int maxCapacity)
    {
        Id = modelId;
        ModelName = modelName;
        FloorLevel = floorLevel;
        MaxCapacity = maxCapacity;
    }
}
