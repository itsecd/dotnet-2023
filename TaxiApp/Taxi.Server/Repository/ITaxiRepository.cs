using Taxi.Domain;

namespace Taxi.Server.Repository;

public interface ITaxiRepository
{
    List<VehicleClassification> VehicleClassifications { get; }
    
    List<Driver> Drivers { get; }
    
    List<Vehicle> Vehicles { get; }
    
    List<Passenger> Passengers { get; }
    
    List<Ride> Rides { get; }
}