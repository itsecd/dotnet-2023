using Taxi.Domain;

namespace Taxi.Tests;

public class TaxiTests : IClassFixture<TaxiFixture>
{
    private readonly TaxiFixture _fixture;

    public TaxiTests(TaxiFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    ///     First Request:
    ///     Output all information about the individual driver and his vehicle
    /// </summary>
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

    /// <summary>
    ///     Second request:
    ///     Output all passengers who have ride in the given period, sorted by full name
    /// </summary>
    [Fact]
    public void PassengersOverGivenPeriod()
    {
        List<Passenger> passengers = _fixture.FixturePassengers;
        List<Ride> rides = _fixture.FixtureRides;
        foreach (Ride ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }

        var minDate = new DateTime(2023, 2, 3);
        var maxDate = new DateTime(2023, 2, 4);

        var query = (from passenger in passengers
            from ride in passenger.Rides
            where ride.RideDate <= maxDate && ride.RideDate >= minDate
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

    /// <summary>
    ///     Third request:
    ///     Output the number of ride for each passenger
    /// </summary>
    [Fact]
    public void CountPassengerRides()
    {
        List<Passenger> passengers = _fixture.FixturePassengers;
        List<Ride> rides = _fixture.FixtureRides;
        foreach (Ride ride in rides)
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
        Assert.DoesNotContain(query, elem => elem.LastName == "Белый" && elem.Count == 1);
    }

    /// <summary>
    ///     Fourth request:
    ///     Output the top 2 drivers by the number of ride made
    /// </summary>
    [Fact]
    public void CountTopDriverRides()
    {
        List<Vehicle> vehicles = _fixture.FixtureVehicles;
        List<Ride> rides = _fixture.FixtureRides;
        List<Driver> drivers = _fixture.FixtureDrivers;
        foreach (Ride ride in rides)
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

    /// <summary>
    ///     Fifth request:
    ///     Output information about the number of rides, average time and maximum ride time for each driver
    /// </summary>
    [Fact]
    public void InfosAboutRides()
    {
        List<Vehicle> vehicles = _fixture.FixtureVehicles;
        List<Ride> rides = _fixture.FixtureRides;
        List<Driver> drivers = _fixture.FixtureDrivers;
        foreach (Ride ride in rides)
        {
            vehicles[(int)ride.VehicleId - 1].Rides.Add(ride);
        }

        var query = (from ridesInfo in from ride in rides
                group ride by ride.VehicleId
                into grp
                select new
                {
                    vehicleId = grp.Key,
                    count = grp.Count(),
                    avg = grp.Average(ride =>
                        ride.RideTime.Second + (60 * ride.RideTime.Minute) + (3600 * ride.RideTime.Hour)),
                    max = grp.Max(ride =>
                        ride.RideTime.Second + (60 * ride.RideTime.Minute) + (3600 * ride.RideTime.Hour))
                }
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

    /// <summary>
    ///     Sixth request:
    ///     Output the information about the passengers who have made the maximum number of rides in a given period
    /// </summary>
    [Fact]
    public void MaxRidesOfPassenger()
    {
        List<Passenger> passengers = _fixture.FixturePassengers;
        List<Ride> rides = _fixture.FixtureRides;
        foreach (Ride ride in rides)
        {
            passengers[(int)ride.PassengerId - 1].Rides.Add(ride);
        }

        var minDate = new DateTime(2023, 2, 3);
        var maxDate = new DateTime(2023, 2, 6);

        var subquery = from passenger in passengers
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
            };

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