namespace Taxi.Domain;

public class Vehicle
{
    public UInt64 Id { get; set; }

    public string RegistrationCarPlate { get; set; } = String.Empty;

    public string Colour { get; set; } = String.Empty;

    public UInt64 VehicleClassificationId { get; set; }

    public UInt64 DriverId { get; set; }

    public List<Ride> Rides { get; set; } = new List<Ride>();
    
}