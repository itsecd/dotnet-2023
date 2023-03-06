using Taxi.Domain;

namespace Taxi.Tests;

public class TaxiFixture
{
    public List<VehicleClassification> FixtureVehicleClassifications
    {
        get
        {
            var vehicleClassB = new VehicleClassification(1, "Lada", "Granta", "B");
            var vehicleClassC = new VehicleClassification(2, "Skoda", "Octavia", "C");
            var vehicleClassD = new VehicleClassification(3, "Audi", "A4", "D");
            
            return new List<VehicleClassification>() {vehicleClassB, vehicleClassC, vehicleClassD};
        }
    }

    public List<Vehicle> FixtureVehicles
    {
        get
        {
            return new List<Vehicle>();
        }
    }

}