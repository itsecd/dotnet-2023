using Taxi.Domain;
using System.Linq;
using System.Threading.Channels;
using Xunit.Abstractions;

namespace Taxi.Tests;

public class TaxiTests : IClassFixture<TaxiFixture>
{
    private readonly TaxiFixture _fixture;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public TaxiTests(TaxiFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _fixture = fixture;
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void InfoAboutVehiclesAndDrivers()
    {
        
        var query = (from vehicle in _fixture.FixtureVehicles
            from vehicleClassification in _fixture.FixtureVehicleClassifications
            from driver in _fixture.FixtureDrivers
            where vehicleClassification.Id == vehicle.VehicleClassificationId &&
                  driver.Id == vehicle.DriverId && driver.LastName == "Логинов"
            select new
            {
                vehicle.RegistrationCarPlate,
                vehicle.Colour,
                driver.FirstName,
                driver.LastName,
                driver.Patronymic,
                driver.PhoneNumber,
                driver.Passport,
                vehicleClassification.Brand,
                vehicleClassification.Model,
                vehicleClassification.Class
            }).ToList();
        
        Assert.Contains(query, elem => elem.RegistrationCarPlate == "Х243КХ163");
        Assert.Contains(query, elem => elem.FirstName == "Алексей");
        Assert.Contains(query, elem => elem.Model == "Octavia");
        Assert.DoesNotContain(query, elem => elem.Passport == "3616039857");
        
        
        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
        
    }

    [Fact]
    public void PassengersOverGivenPeriod()
    {
        var passengers = _fixture.FixturePassengers;
        var rides = _fixture.FixtureRides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }
        
        var minDate = new DateTime(2023, 2, 3);
        var maxDate = new DateTime(2023, 2, 4);
        
        var query = (from p in passengers
            from r in p.Rides
            where  r.RideDate <= maxDate && r.RideDate >= minDate
            orderby p.LastName, p.FirstName, p.Patronymic
            select new
            {
                p.LastName,
                p.FirstName,
                p.Patronymic,
                r.RideDate
            }).Distinct().ToList();
        
        Assert.Equal(4, query.Count);
        Assert.Contains(query, elem => elem.LastName == "Рыжова");
        Assert.Contains(query, elem => elem.LastName == "Котов");
        Assert.DoesNotContain(query, elem => elem.LastName == "Беляева");
        Assert.DoesNotContain(query, elem => elem.LastName == "Кулешов");
        

        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
    }

    [Fact]
    public void CountPassengerRides()
    {
        var passengers = _fixture.FixturePassengers;
        var rides = _fixture.FixtureRides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }

        var query = (from p in passengers
            select new
            {
                p.LastName,
                p.FirstName,
                p.Patronymic,
                p.Rides.Count
            }).ToList();
        
        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
    }

    [Fact]
    public void CountTopDriverRides()
    {
        var vehicles  = _fixture.FixtureVehicles;
        var rides = _fixture.FixtureRides;
        var drivers = _fixture.FixtureDrivers;
        foreach (var ride in rides)
        {
            vehicles[(int)ride.VehicleId - 1].Rides.Add(ride);
        }

        var query = (from v in vehicles
            from d in drivers
            where v.DriverId == d.Id
            orderby v.Rides.Count
            select new
            {
                d.LastName,
                d.FirstName,
                d.Patronymic,
                v.Rides.Count
            }).Take(2).ToList();

        Assert.Contains(query, elem => elem.Count == 4);
        Assert.DoesNotContain(query, elem => elem.Count == 5 || elem.Count == 3);
        
        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
        
    }
    
    [Fact]
    public void InfosAboutRides()
    {
        var vehicles  = _fixture.FixtureVehicles;
        var rides = _fixture.FixtureRides;
        var drivers = _fixture.FixtureDrivers;
        foreach (var ride in rides)
        {
            vehicles[(int)ride.VehicleId - 1].Rides.Add(ride);
        }
        
        
    }
}