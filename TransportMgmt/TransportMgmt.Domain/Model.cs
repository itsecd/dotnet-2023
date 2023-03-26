namespace TransportMgmt.Domain;
/// <summary>
/// Class Model is used to store information about transport models
/// </summary>
public class Model
{
    /// <summary>
    /// Unique key of model
    /// </summary>
    public int ModelId { get; set; } = 0;
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
    public Model() { }
    public Model(int modelId, string modelName, string floorLevel, int maxCapacity)
    {
        ModelId = modelId;
        ModelName = modelName;
        FloorLevel = floorLevel;
        MaxCapacity = maxCapacity;
    }
}
