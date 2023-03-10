using Taxi.Domain;
using System.Linq;
using System.Threading.Channels;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        Assert.DoesNotContain(query, elem => elem.Count == 3);
        
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

        var query = (from ridesInfo in (from r in rides
                group r by r.VehicleId
                into grp
                select new
                {
                    vehicleId = grp.Key,
                    count = grp.Count(),
                    avg = grp.Average(ride =>
                        ride.RideTime.Second + 60 * ride.RideTime.Minute + 3600 * ride.RideTime.Hour),
                    max = grp.Max(ride => ride.RideTime.Second + 60 * ride.RideTime.Minute + 3600 * ride.RideTime.Hour)
                })
            from d in drivers
            where d.Id == ridesInfo.vehicleId
            select new
            {
                d.LastName,
                d.FirstName,
                d.Patronymic,
                ridesInfo.count,
                ridesInfo.avg,
                ridesInfo.max
            }).ToList();
        
        Assert.Equal(5, query.Count());
        Assert.Equal(1980, query[4].avg);
        Assert.Equal(2400, query[0].max);
        Assert.Equal(4, query[2].count);

        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
    }
    
    [Fact]
    public void MaxRidesOfPassenger()
    {
        var passengers = _fixture.FixturePassengers;
        var rides = _fixture.FixtureRides;
        foreach (var ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }

        var minDate = new DateTime(2023, 2, 3);
        var maxDate = new DateTime(2023, 2, 6);

        var subquery = (from p in passengers
            from r in p.Rides
            where r.RideDate < maxDate && r.RideDate > minDate
            group p.Id by p
            into grp
            select new
            {
                grp.Key.LastName,
                grp.Key.FirstName,
                grp.Key.Patronymic,
                count = grp.Count()

            });

        var max = subquery.Max(elem => elem.count);
        
        var query = (from sq in subquery
            where sq.count == max
            select sq).ToList();
        
        foreach (var elem in query)
        {
            _testOutputHelper.WriteLine(elem.ToString());
        }
    }
    
}