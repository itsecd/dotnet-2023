using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TransportManagment.Classes.Tests;
public class TransManagmentTests
{
    /// <summary>
    /// Default list of transports
    /// </summary>
    public List<Transport> DefaultTransports()
    {
        return new List<Transport>()
        {
            new Transport(1, "bus", "Mercedes", new DateTime(1990, 10, 23)),//, new List<int> {100}),
            new Transport(2, "bus", "Audi", new DateTime(1992, 04, 18)),//, new List<int> {111, 112}),
            new Transport(3, "trolleybus", "VAZ", new DateTime(1985, 10, 23)),//, new List<int> {123}),
            new Transport(4, "trolleybus", "VAZ", new DateTime(2010, 11, 01)),//, new List < int > {133}),
            new Transport(5, "tram", "Samtram", new DateTime(1990, 10, 13)),//, new List < int > {144}),
            new Transport(6, "tram", "Mostram", new DateTime(1989, 08, 02)),//, new List < int > {155}),
        };
    }
    /// <summary>
    /// Default list of drivers
    /// </summary>
    public List<Driver> DefaultDrivers()
    {
        return new List<Driver>()
        {
             new Driver (11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090),//, new List<int> { 100 }),
             new Driver (12, "Oleg", "Fursov", "Igorevich", 292365, 2211, 2578090),//, new List < int > { 111 }),
             new Driver (13, "Evpatiy", "Kage", "Niconorovich", 129561, 3081, 2568430),//, new List < int > { 112 }),
             new Driver (14, "Egor", "Abramov", "Danilovich", 280123, 2411, 2568123),//, new List < int > {123, 133}),
             new Driver (15, "Adry", "Tarasov", "Sergeivich", 199321, 2784, 2522290),//, new List < int > { 144 }),
             new Driver (16, "Bill", "Pechorin", "Andeivich", 300965, 1234, 3668090),//, new List < int > { 155 }),
        };
    }
    /// <summary>
    /// Default list of routes
    /// </summary>
    public List<Route> DefaultRoutes()
    {
        List<Driver> tempd = DefaultDrivers();
        List<Transport> tempt = DefaultTransports();
        return new List<Route>()
        {
            new Route(100, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), 1, 11),//, tempt[0], tempd[0]
            new Route(111, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 09, 00, 00), new DateTime(2022, 02, 11, 16, 00, 00), 2, 12),//, tempt[1], tempd[1]
            new Route(112, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 16, 30, 00), new DateTime(2022, 02, 11, 22, 30, 00), 2, 13),//, tempt[1], tempd[2]
            new Route(123, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 07, 30, 00), new DateTime(2022, 02, 11, 14, 30, 00), 3, 14),//, tempt[2], tempd[3]
            new Route(133, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 15, 00, 00), new DateTime(2022, 02, 11, 23, 00, 00), 4, 14),//, tempt[3], tempd[3]
            new Route(144, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 06, 00, 00), new DateTime(2022, 02, 11, 18, 00, 00), 5, 15),//, tempt[4], tempd[4]
            new Route(155, new DateTime(2022, 02, 12), new DateTime(2022, 02, 12, 06, 30, 00), new DateTime(2022, 02, 11, 18, 00, 00), 6, 16),//, tempt[5], tempd[5]
        };
    }
    /// <summary>
    /// TransportTest - test about transports
    /// </summary>
    [Fact]
    public void TransportTest()
    {
        var transport = new Transport(1, "bus", "Mercedes", new DateTime(1990, 10, 23));
        Assert.Equal(1, transport.TransportId);
        Assert.Equal("bus", transport.Type);
        Assert.Equal("Mercedes", transport.Model);
        Assert.Equal(new DateTime(1990, 10, 23), transport.DateMake);
        //Assert.Equal(new List<int> {100}, transport.Routes);
    }
    /// <summary>
    /// DriverTest - test about drivers
    /// </summary>
    [Fact]
    public void DriverTest()
    {
        var driver = new Driver(11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090);
        Assert.Equal(11, driver.DriverId);
        Assert.Equal("Igor", driver.FirstName);
        Assert.Equal("Gudzenko", driver.LastName);
        Assert.Equal("Nicolaevich", driver.Patronymic);
        Assert.Equal(290865, driver.Passport);
        Assert.Equal(2434, driver.DriverCard);
        Assert.Equal(2568090, driver.Number);
    }
    /// <summary>
    /// RouteTest - test about routes
    /// </summary>
    [Fact]
    public void RouteTest()
    {
        List<Driver> tempd = DefaultDrivers();
        List<Transport> tempt = DefaultTransports();
        var route = new Route(100, new DateTime(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), 1, 11);
        route.Transport = tempt[0];
        route.Driver = tempd[0];
        Assert.Equal(100, route.RouteId);
        Assert.Equal(new DateTime(2022, 02, 11), route.Date);
        Assert.Equal(new DateTime(2022, 02, 11, 08, 00, 00), route.TimeTo);
        Assert.Equal(new DateTime(2022, 02, 11, 17, 30, 00), route.TimeFrom);
        Assert.Equal(tempt[0], route.Transport);
        Assert.Equal(tempd[0], route.Driver);
    }
    /// <summary>
    /// Task 1 - Output all information about a specific vehicle.
    /// </summary>
    [Fact]
    public void AllTransportInfo()
    {
        List<Transport> transports = DefaultTransports();
        var result = (from transport in transports
                      where transport.TransportId == 1
                      select transport);

        Assert.Single(result);
        Assert.Contains(result, transport => transport.TransportId == 1);
    }
    /// <summary>
    /// Task 2 - Output all drivers who have made trips for a given period, sort by full name.
    /// </summary>
    [Fact]
    public void AllDriversWithSpecificDate()
    {
        List<Driver> drivers = DefaultDrivers();
        List<Route> routes = DefaultRoutes();
        var result = (from driver in drivers
                      join route in routes on driver.DriverId equals route.Driver.DriverId
                      orderby driver.LastName
                      where route.Date < new DateTime(2022, 02, 12) && route.Date > new DateTime(2022, 02, 10)
                      select driver).ToList();
        Assert.Equal(6, result.Count());
        Assert.Contains(result, driver => driver.DriverId == 11);
        Assert.Contains(result, driver => driver.DriverId == 12);
        Assert.Contains(result, driver => driver.DriverId == 13);
        Assert.Contains(result, driver => driver.DriverId == 14);
        Assert.Contains(result, driver => driver.DriverId == 15);
    }
    /// <summary>
    /// Task 3 - Output the total travel time of the vehicle of each type and model.
    /// </summary>
    [Fact]
    public void TotalTimeTravelEveryTypeAndModel()
    {
        List<Transport> transports = DefaultTransports();
        List<Route> routes = DefaultRoutes();
        var result = (from transport in transports
                      join route in routes on transport.TransportId equals route.Transport.TransportId
                      group route by new { transport.Model, transport.Type } into res
                      orderby res.Sum(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary()) descending
                      select new
                      {
                          res.First().Driver.DriverId,
                          time = res.Sum(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary())
                      }
                      ).ToList();
        Assert.Equal(5, result.Count());
        Assert.Contains(result, driver => driver.DriverId == 11);
        Assert.Contains(result, driver => driver.DriverId == 12);
        Assert.Contains(result, driver => driver.DriverId == 14);
        Assert.Contains(result, driver => driver.DriverId == 15);
        Assert.Contains(result, driver => driver.DriverId == 16);
    }
    /// <summary>
    /// Task 4 - Output the top 5 drivers by the number of trips made.
    /// </summary>
    [Fact]
    public void TopFiveDrivers()
    {
        List<Driver> drivers = DefaultDrivers();
        List<Route> routes = DefaultRoutes();
        var result = (from driver in drivers
                      join route in routes on driver.DriverId equals route.Driver.DriverId
                      group route by driver.DriverId into res
                      orderby res.Count() descending
                      select res).Take(5);
        Assert.Equal(5, result.Count());
        Assert.Contains(result, driver => driver.ToList()[0].Driver.DriverId == 11);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.DriverId == 12);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.DriverId == 13);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.DriverId == 14);
        Assert.Contains(result, driver => driver.ToList()[0].Driver.DriverId == 15);
    }
    /// <summary>
    /// Task 5 - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    [Fact]
    public void InfoAboutCountTravelAvgTimeTranvelMaxTimeTravel()
    {
        List<Driver> drivers = DefaultDrivers();
        List<Route> routes = DefaultRoutes();
        var result = (from driver in drivers
                      join route in routes on driver.DriverId equals route.Driver.DriverId
                      group route by driver.DriverId into res
                      select res.First().TimeFrom.ToBinary() - res.First().TimeTo.ToBinary()).ToList();
        Assert.Equal(6, result.Count());
        Assert.Equal(432000000000, result.Max());
        Assert.Equal(174000000000, result.Average());
    }
    /// <summary>
    /// Task 6 - Display information about vehicles that have made the maximum number of trips during the specified period.
    /// </summary>
    [Fact]
    public void TransportInfoWithMaxCountForSpecificDate()
    {
        List<Transport> transports = DefaultTransports();
        List<Route> routes = DefaultRoutes();
        var result = (from transport in transports
                      join route in routes on transport.TransportId equals route.Transport.TransportId
                      group route by route.Transport.TransportId into res
                      orderby res.Count()
                      where res.First().Date < new DateTime(2022, 02, 12) && res.First().Date > new DateTime(2022, 02, 10) && res.Count() == 2
                      select res);
        Assert.Equal(2, result.First().Count());
        Assert.Contains(result.First(), driver => driver.Driver.DriverId == 12);
    }
}
