using Taxi.Domain;
using System.Linq;
using System.Threading.Channels;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Taxi.Tests;

public class TaxiTests : IClassFixture<TaxiFixture>
{
    private readonly TaxiFixture _fixture;
    
    public TaxiTests(TaxiFixture fixture)
    {
        _fixture = fixture;
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
        
        var query = (from passenger in passengers
            from ride in passenger.Rides
            where  ride.RideDate <= maxDate && ride.RideDate >= minDate
            orderby passenger.LastName, passenger.FirstName, passenger.Patronymic
            select new
            {
                passenger.LastName,
                passenger.FirstName,
                passenger.Patronymic,
                ride.RideDate
            }).Distinct().ToList();
        
        Assert.Equal(4, query.Count);
        Assert.Contains(query, elem => elem.LastName == "Рыжова");
        Assert.Contains(query, elem => elem.LastName == "Котов");
        Assert.DoesNotContain(query, elem => elem.LastName == "Беляева");
        Assert.DoesNotContain(query, elem => elem.LastName == "Кулешов");
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

        var query = (from passenger in passengers
            select new
            {
                passenger.LastName,
                passenger.FirstName,
                passenger.Patronymic,
                passenger.Rides.Count
            }).ToList();

        Assert.Equal(7, query.Count);
        Assert.Contains(query, elem => elem.LastName == "Котов" && elem.Count == 3);
        Assert.DoesNotContain(query, elem=> elem.LastName == "Белый" && elem.Count == 1);
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

        var query = (from vehicle in vehicles
            from driver in drivers
            where vehicle.DriverId == driver.Id
            orderby vehicle.Rides.Count
            select new
            {
                driver.LastName,
                driver.FirstName,
                driver.Patronymic,
                vehicle.Rides.Count
            }).Take(2).ToList();

        Assert.Contains(query, elem => elem.Count == 4);
        Assert.DoesNotContain(query, elem => elem.Count == 3);
        Assert.Equal(2, query.Count);
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

        var query = (from ridesInfo in (from ride in rides
                group ride by ride.VehicleId
                into grp
                select new
                {
                    vehicleId = grp.Key,
                    count = grp.Count(),
                    avg = grp.Average(ride =>
                        ride.RideTime.Second + 60 * ride.RideTime.Minute + 3600 * ride.RideTime.Hour),
                    max = grp.Max(ride => ride.RideTime.Second + 60 * ride.RideTime.Minute + 3600 * ride.RideTime.Hour)
                })
            from driver in drivers
            where driver.Id == ridesInfo.vehicleId
            select new
            {
                driver.LastName,
                driver.FirstName,
                driver.Patronymic,
                ridesInfo.count,
                ridesInfo.avg,
                ridesInfo.max
            }).ToList();
        
        Assert.Equal(5, query.Count());
        Assert.Equal(1980, query[4].avg);
        Assert.Equal(2400, query[0].max);
        Assert.Equal(4, query[2].count);
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

        var subquery = (from passenger in passengers
            from ride in passenger.Rides
            where ride.RideDate < maxDate && ride.RideDate > minDate
            group passenger.Id by passenger
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
        
        Assert.Equal(5, query.Count);
        Assert.DoesNotContain(query, elem => elem.count == 1);
        Assert.DoesNotContain(query, elem => elem.count == 3);
        Assert.Contains(query, elem => elem.count == 2);
        Assert.DoesNotContain(query, elem => elem.LastName == "Кулешов");
        Assert.Contains(query, elem => elem.LastName == "Беляева");
    }
    
}