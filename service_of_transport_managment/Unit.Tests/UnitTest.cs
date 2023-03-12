using System.Diagnostics.Metrics;
using TransManagment;
using Xunit.Sdk;

namespace Unit.Tests;


public class UnitTest
{
    public List<Transports> FixturTrans()
    {
        return new List<Transports>()
        {
            new Transports(1, "bus", "Mercedes", new DateOnly(1990, 10, 23)),
            new Transports(2, "bus", "Audi", new DateOnly(1992, 04, 18)),
            new Transports(3, "trolleybus", "VAZ", new DateOnly(1985, 10, 23)),
            new Transports(4, "trolleybus", "VAZ", new DateOnly(2010, 11, 01)),
            new Transports(5, "tram", "Sam_tram", new DateOnly(1990, 10, 13)),
            new Transports(6, "tram", "Mos_tram", new DateOnly(1989, 08, 02)),
        };
    }
    public List<Drivers> FixtureDriv()
    {
        return new List<Drivers>()
        {
             new Drivers (11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090),
             new Drivers (12, "Oleg", "Fursov", "Igorevich", 292365, 2211, 2578090),
             new Drivers (13, "Evpatiy", "Kage", "Niconorovich", 129561, 3081, 2568430),
             new Drivers (14, "Egor", "Abramov", "Danilovich", 280123, 2411, 2568123),
             new Drivers (15, "Adry", "Tarasov", "Sergeivich", 199321, 2784, 2522290),
             new Drivers (16, "Bill", "Pechorin", "Andeivich", 300965, 1234, 3668090),
        };
    }
    public List<Routes> FixtureRoute()
    {
        List<Drivers> temp_d = FixtureDriv();
        List<Transports> temp_t = FixturTrans();
        return new List<Routes>()
        {
            new Routes(100, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), temp_t[0], temp_d[0]),
            new Routes(111, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 09, 00, 00), new DateTime(2022, 02, 11, 16, 00, 00), temp_t[1], temp_d[1]),
            new Routes(112, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 16, 30, 00), new DateTime(2022, 02, 11, 22, 30, 00), temp_t[1], temp_d[2]),
            new Routes(123, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 07, 30, 00), new DateTime(2022, 02, 11, 14, 30, 00), temp_t[2], temp_d[3]),
            new Routes(133, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 15, 00, 00), new DateTime(2022, 02, 11, 23, 00, 00), temp_t[3], temp_d[3]),
            new Routes(144, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 06, 00, 00), new DateTime(2022, 02, 11, 18, 00, 00), temp_t[4], temp_d[4]),
            new Routes(155, new DateOnly(2022, 02, 12), new DateTime(2022, 02, 12, 06, 30, 00), new DateTime(2022, 02, 11, 18, 00, 00), temp_t[5], temp_d[5]),
        };
    }

    public int Func(Routes x, Routes y)
    {
        if(x.Driver.Driver_id == y.Driver.Driver_id)
            return 2;
        return 1;
    }

    [Fact]
    public void TransportTest()
    {
        var transport = new Transports(1, "bus", "Mercedes", new DateOnly(1990, 10, 23));
        Assert.Equal(1, transport.Transport_id);
        Assert.Equal("bus", transport.Type);
        Assert.Equal("Mercedes", transport.Model);
        Assert.Equal(new DateOnly(1990, 10, 23), transport.Date_make);
    }
    [Fact]
    public void DriverTest()
    {
        var driver = new Drivers(11, "Igor", "Gudzenko", "Nicolaevich", 290865, 2434, 2568090);
        Assert.Equal(11, driver.Driver_id);
        Assert.Equal("Igor", driver.First_name);
        Assert.Equal("Gudzenko", driver.Last_name);
        Assert.Equal("Nicolaevich", driver.Dad_name);
        Assert.Equal(290865, driver.Passport);
        Assert.Equal(2434, driver.Driver_card);
        Assert.Equal(2568090, driver.Number);
    }
    [Fact]
    public void RouteTest() 
    {
        List<Drivers> temp_d = FixtureDriv();
        List<Transports> temp_t = FixturTrans();
        var route = new Routes(100, new DateOnly(2022, 02, 11), new DateTime(2022, 02, 11, 08, 00, 00), new DateTime(2022, 02, 11, 17, 30, 00), temp_t[0], temp_d[0]);
        Assert.Equal(100, route.Route_id);
        Assert.Equal(new DateOnly(2022, 02, 11), route.Date);
        Assert.Equal(new DateTime(2022, 02, 11, 08, 00, 00), route.Time_to);
        Assert.Equal(new DateTime(2022, 02, 11, 17, 30, 00), route.Time_from);
        Assert.Equal(temp_t[0], route.Transport);
        Assert.Equal(temp_d[0], route.Driver);
    }
    [Fact]

    public void Task1()
    {
        List<Transports> transports = FixturTrans();
        var result = (from transport in transports
                      where transport.Transport_id == 1
                      select transport);

        Assert.Single(result);
        Assert.Contains(result, transport => transport.Transport_id == 1);
    }
    [Fact]
    public void Task2()
    {
        List<Drivers> drivers = FixtureDriv();
        List<Routes> routes = FixtureRoute();
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
    [Fact]
    public void Task3()
    {
        List<Transports> transports = FixturTrans();
        List<Routes> routes = FixtureRoute();
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
    [Fact]
    public void Task4()
    {
        List<Drivers> drivers = FixtureDriv();
        List<Routes> routes = FixtureRoute();
        var result = (from driver in drivers
                      join route in routes on driver.Driver_id equals route.Driver.Driver_id
                      group route by driver.Driver_id into res
                      orderby res.Count()
                      select res).Take(5).ToList();
        Assert.Equal(5, result.Count());
        //Assert.Contains(result, driver => driver.Driver_id == 11);
        //Assert.Contains(result, driver => driver.Driver_id == 12);
        //Assert.Contains(result, driver => driver.Driver_id == 13);
        //Assert.Contains(result, driver => driver.Driver_id == 14);
        //Assert.Contains(result, driver => driver.Driver_id == 15);
    }
}