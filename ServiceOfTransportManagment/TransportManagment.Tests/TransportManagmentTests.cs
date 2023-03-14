using TransManagment.Domain;

namespace Unit.Tests;


public class UnitTest
{
    /// <summary>
    /// FixturTrans - default list of transports
    /// </summary>
    public List<Transport> FixturTrans()
    {
        return new List<Transport>()
        {
            new Transport(1, "bus", "Mercedes", new DateOnly(1990, 10, 23)),
            new Transport(2, "bus", "Audi", new DateOnly(1992, 04, 18)),
            new Transport(3, "trolleybus", "VAZ", new DateOnly(1985, 10, 23)),
            new Transport(4, "trolleybus", "VAZ", new DateOnly(2010, 11, 01)),
            new Transport(5, "tram", "Sam_tram", new DateOnly(1990, 10, 13)),
            new Transport(6, "tram", "Mos_tram", new DateOnly(1989, 08, 02)),
        };
    }
    /// <summary>
    /// FixturDriv - default list of drivers
    /// </summary>
    public List<Driver> FixtureDriv()
    {
        return new List<Driver>()
        {
             new Driver (11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090),
             new Driver (12, "Oleg", "Fursov", "Igorevich", 292365, 2211, 2578090),
             new Driver (13, "Evpatiy", "Kage", "Niconorovich", 129561, 3081, 2568430),
             new Driver (14, "Egor", "Abramov", "Danilovich", 280123, 2411, 2568123),
             new Driver (15, "Adry", "Tarasov", "Sergeivich", 199321, 2784, 2522290),
             new Driver (16, "Bill", "Pechorin", "Andeivich", 300965, 1234, 3668090),
        };
    }
    /// <summary>
    /// FixturRoute - default list of routes
    /// </summary>
    public List<Route> FixtureRoute()
    {
        List<Driver> temp_d = FixtureDriv();
        List<Transport> temp_t = FixturTrans();
        return new List<Route>()
        {
            new Route(100, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), temp_t[0], temp_d[0]),
            new Route(111, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 09, 00, 00), new DateTime(2022, 02, 11, 16, 00, 00), temp_t[1], temp_d[1]),
            new Route(112, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 16, 30, 00), new DateTime(2022, 02, 11, 22, 30, 00), temp_t[1], temp_d[2]),
            new Route(123, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 07, 30, 00), new DateTime(2022, 02, 11, 14, 30, 00), temp_t[2], temp_d[3]),
            new Route(133, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 15, 00, 00), new DateTime(2022, 02, 11, 23, 00, 00), temp_t[3], temp_d[3]),
            new Route(144, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 06, 00, 00), new DateTime(2022, 02, 11, 18, 00, 00), temp_t[4], temp_d[4]),
            new Route(155, new DateOnly(2022, 02, 12), new DateTime(2022, 02, 12, 06, 30, 00), new DateTime(2022, 02, 11, 18, 00, 00), temp_t[5], temp_d[5]),
        };
    }

    /// <summary>
    /// TransportTest - test about transports
    /// </summary>
    [Fact]
    public void TransportTest()
    {
        var transport = new Transport(1, "bus", "Mercedes", new DateOnly(1990, 10, 23));
        Assert.Equal(1, transport.Transport_id);
        Assert.Equal("bus", transport.Type);
        Assert.Equal("Mercedes", transport.Model);
        Assert.Equal(new DateOnly(1990, 10, 23), transport.Date_make);
    }
    /// <summary>
    /// DriverTest - test about drivers
    /// </summary>
    [Fact]
    public void DriverTest()
    {
        var driver = new Driver(11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090);
        Assert.Equal(11, driver.Driver_id);
        Assert.Equal("Igor", driver.First_name);
        Assert.Equal("Gudzenko", driver.Last_name);
        Assert.Equal("Nicolaevich", driver.Patronymic);
        Assert.Equal(290865, driver.Passport);
        Assert.Equal(2434, driver.Driver_card);
        Assert.Equal(2568090, driver.Number);
    }
    /// <summary>
    /// RouteTest - test about routes
    /// </summary>
    [Fact]
    public void RouteTest()
    {
        List<Driver> temp_d = FixtureDriv();
        List<Transport> temp_t = FixturTrans();
        var route = new Route(100, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), temp_t[0], temp_d[0]);
        Assert.Equal(100, route.Route_id);
        Assert.Equal(new DateOnly(2022, 02, 11), route.Date);
        Assert.Equal(new DateTime(2022, 02, 11, 08, 00, 00), route.Time_to);
        Assert.Equal(new DateTime(2022, 02, 11, 17, 30, 00), route.Time_from);
        Assert.Equal(temp_t[0], route.Transport);
        Assert.Equal(temp_d[0], route.Driver);
    }

    /// <summary>
    /// Task1 - Output all information about a specific vehicle.
    /// </summary>
    [Fact]
    public void AllTransportInfo()
    {
        List<Transport> transports = FixturTrans();
        var result = (from transport in transports
                      where transport.Transport_id == 1
                      select transport);

        Assert.Single(result);
        Assert.Contains(result, transport => transport.Transport_id == 1);
    }
    /// <summary>
    /// Task2 - Output all drivers who have made trips for a given period, sort by full name.
    /// </summary>
    [Fact]
    public void AllDriversWithSpecificDate()
    {
        List<Driver> drivers = FixtureDriv();
        List<Route> routes = FixtureRoute();
        var result = (from driver in drivers
                      join route in routes on driver.Driver_id equals route.Driver.Driver_id
                      orderby driver.Last_name
                      where route.Date < new DateOnly(2022, 02, 12) && route.Date > new DateOnly(2022, 02, 10)
                      select driver).ToList();
        Assert.Equal(6, result.Count());
        Assert.Contains(result, driver => driver.Driver_id == 11);
        Assert.Contains(result, driver => driver.Driver_id == 12);
        Assert.Contains(result, driver => driver.Driver_id == 13);
        Assert.Contains(result, driver => driver.Driver_id == 14);
        Assert.Contains(result, driver => driver.Driver_id == 15);
    }
    /// <summary>
    /// Task3 - Output the total travel time of the vehicle of each type and model.
    /// </summary>
    [Fact]
    public void TotalTimeTravelEveryTypeAndModel()
    {
        List<Transport> transports = FixturTrans();
        List<Route> routes = FixtureRoute();
        var result = (from transport in transports
                      join route in routes on transport.Transport_id equals route.Transport.Transport_id
                      group route by new { transport.Model, transport.Type } into res
                      orderby res.Sum(route => route.Time_from.ToBinary() - route.Time_to.ToBinary()) descending
                      select new
                      {
                          res.First().Driver.Driver_id,
                          time = res.Sum(route => route.Time_from.ToBinary() - route.Time_to.ToBinary())
                      }
                      ).ToList();
        Assert.Equal(5, result.Count());
        Assert.Contains(result, driver => driver.Driver_id == 11);
        Assert.Contains(result, driver => driver.Driver_id == 12);
        Assert.Contains(result, driver => driver.Driver_id == 14);
        Assert.Contains(result, driver => driver.Driver_id == 15);
        Assert.Contains(result, driver => driver.Driver_id == 16);
    }
    /// <summary>
    /// Task4 - Output the top 5 drivers by the number of trips made.
    /// </summary>
    [Fact]
    public void TopFiveDrivers()
    {
        List<Driver> drivers = FixtureDriv();
        List<Route> routes = FixtureRoute();
        var result = (from driver in drivers
                      join route in routes on driver.Driver_id equals route.Driver.Driver_id
                      group route by driver.Driver_id into res
                      orderby res.Count() descending
                      select res).Take(5);
        Assert.Equal(5, result.Count());
        Assert.Contains(result, driver => driver.ToList()[0].Driver.Driver_id == 11);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.Driver_id == 12);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.Driver_id == 13);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.Driver_id == 14);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.Driver_id == 15);
    }
    /// <summary>
    /// Task5 - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    [Fact]
    public void InfoAboutCountTravelAvgTimeTranvelMaxTimeTravel()
    {
        List<Driver> drivers = FixtureDriv();
        List<Route> routes = FixtureRoute();
        var result = (from driver in drivers
                      join route in routes on driver.Driver_id equals route.Driver.Driver_id
                      group route by driver.Driver_id into res
                      select res.First().Time_from.ToBinary() - res.First().Time_to.ToBinary()).ToList();
        Assert.Equal(6, result.Count());
        Assert.Equal(432000000000, result.Max());
        Assert.Equal(174000000000, result.Average());
    }
    /// <summary>
    /// Task6 - Display information about vehicles that have made the maximum number of trips during the specified period.
    /// </summary>
    [Fact]
    public void TransportInfoWithMaxCountForSpecificDate()
    {
        List<Transport> transports = FixturTrans();
        List<Route> routes = FixtureRoute();
        var result = (from transport in transports
                      join route in routes on transport.Transport_id equals route.Transport.Transport_id
                      group route by route.Transport.Transport_id into res
                      orderby res.Count()
                      where res.First().Date < new DateOnly(2022, 02, 12) && res.First().Date > new DateOnly(2022, 02, 10) && res.Count() == 2
                      select res);
        Assert.Equal(2, result.First().Count());
        Assert.Contains(result.First(), driver => driver.Driver.Driver_id == 12);
    }
}