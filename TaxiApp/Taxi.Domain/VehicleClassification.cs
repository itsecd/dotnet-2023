namespace Taxi.Domain;

public class VehicleClassification
{
    public UInt64 Id { get; set; }
    
    public string Brand { get; set; } = String.Empty;
    
    public string Model { get; set; } = String.Empty;

    public string Class { get; set; } = String.Empty;
    
}