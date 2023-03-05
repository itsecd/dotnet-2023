namespace TaxiDomain;

public class Vehicle
{
    public Guid Id { get; set; } = Guid.Empty;

    public string RegistrationCarPlate { get; set; } = String.Empty;

    public string Colour { get; set; } = String.Empty;

    public VehicleClassification VehicleClassification { get; set; } = new VehicleClassification();

    public Driver Driver { get; set; } = new Driver();

    public List<Ride> Rides { get; set; } = new List<Ride>();
}