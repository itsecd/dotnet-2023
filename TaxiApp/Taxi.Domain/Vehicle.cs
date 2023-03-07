namespace Taxi.Domain;

public class Vehicle
{
    public UInt64 Id { get; set; }

    public string RegistrationCarPlate { get; set; } = String.Empty;

    public string Colour { get; set; } = String.Empty;

    public UInt64 VehicleClassificationId { get; set; }

    public UInt64 Driver { get; set; }

    public List<Ride> Rides { get; set; } = new List<Ride>();
    
    public Vehicle() { }

    public Vehicle(UInt64 id, string registrationCarPlate, string colour, UInt64 vehicleClassificationId, UInt64 driver, List<Ride>? rides = null)
    {
        Id = id;
        RegistrationCarPlate = registrationCarPlate;
        Colour = colour;
        VehicleClassificationId = vehicleClassificationId;
        Driver = driver;
        Rides = rides;
    }
}