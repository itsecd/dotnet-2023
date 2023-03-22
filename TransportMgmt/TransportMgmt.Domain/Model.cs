namespace TransportMgmt.Domain;

public class Model
{
    public int ModelId { get; set; } = 0;
    public string ModelName { get; set; } = string.Empty;
    public string FloorLevel { get; set; } = string.Empty;
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
