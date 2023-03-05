namespace TaxiDomain;

public class VehicleClassification
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public string Brand { get; set; } = String.Empty;
    
    public string Model { get; set; } = String.Empty;

    public string Class { get; set; } = String.Empty;
}