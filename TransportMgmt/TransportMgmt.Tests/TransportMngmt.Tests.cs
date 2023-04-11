using System.Data;

namespace TransportMgmt.Tests;

public class TransportTests : IClassFixture<TransportFixture>
{
    private readonly TransportFixture _fixture;

    public TransportTests(TransportFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// First request - display all information about a specific transport
    /// </summary>
    [Fact]
    public void TransportTest()
    {
        var fixtureTransport = _fixture.Transports.ToList();
        var query = (from transports in fixtureTransport
                     where transports.Id == 2 && transports.Model.ModelName == "MAN Lion's City"
                     select transports).ToList();
        Assert.Single(query);
        Assert.Contains(query, x => x.Model.ModelName == "MAN Lion's City");
    }
    /// <summary>
    /// Second request - display all drivers who have made trips for a given period, sort by full name
    /// </summary>
    [Fact]
    public void DriverTest()
    {
        var fixtureTrip = _fixture.Trips.ToList();
        var query = (from trip in fixtureTrip
                     where trip.Date == new DateTime(2023, 03, 19) && trip.TimeOn == new DateTime(2023, 03, 19, 08, 00, 00)
                     && trip.TimeOff == new DateTime(2023, 03, 19, 17, 30, 00)
                     group trip by trip.Driver.Id into res
                     orderby res.First().Driver.LastName, res.First().Driver.FirstName, res.First().Driver.MiddleName
                     select new
                     {
                         driverId = res.First().Driver.Id,
                         firstName = res.First().Driver.FirstName,
                         lastName = res.First().Driver.LastName,
                         middleName = res.First().Driver.MiddleName
                     }).ToList();
        Assert.Equal(5, query.Count);
        Assert.Contains(query, x => x.lastName == "Водянов");
        Assert.Contains(query, x => x.driverId == 2);
        Assert.Contains(query, x => x.firstName == "Михаил" && x.middleName == "Владиславович");
        Assert.Contains(query, x => x.driverId == 5);
    }
    /// <summary>
    /// Third request - display the total travel time for each transport type and model.
    /// </summary>
    [Fact]
    public void TotalTravelTime()
    {
        var fixtureTrip = _fixture.Trips.ToList();
        var fixtureTransport = _fixture.Transports.ToList();
        var query = (from trip in fixtureTrip
                     join transport in fixtureTransport on trip.Transport.Id equals transport.Id
                     group trip by new { transport.Type, transport.Model } into res
                     orderby res.Sum(trip => (trip.TimeOff - trip.TimeOn).TotalHours) descending
                     select new
                     {
                         transportId = res.First().Transport.Id,
                         type = res.First().Transport.Type,
                         model = res.First().Transport.Model,
                         time = res.Sum(trip => (trip.TimeOff - trip.TimeOn).TotalHours)
                     }
             ).ToList();

        Assert.Equal(7, query.Count);
        Assert.Contains(query, transport => transport.transportId == 2);
        Assert.Contains(query, transport => transport.transportId == 1);
        Assert.Contains(query, transport => transport.transportId == 3);
        Assert.Contains(query, transport => transport.transportId == 4);
        Assert.Contains(query, transport => transport.transportId == 5);
        Assert.Contains(query, transport => transport.transportId == 6);
    }
    /// <summary>
    /// Fourth request - Display the top 5 drivers by the number of trips completed.
    /// </summary>
    [Fact]
    public void DriversTopFive()
    {
        var fixtureTrip = _fixture.Trips.ToList();
        var fixtureDriver = _fixture.Drivers.ToList();
        var query = (from trip in fixtureTrip
                     join driver in fixtureDriver on trip.Driver.Id equals driver.Id
                     group trip by trip.Driver.Id into res
                     orderby res.Count() descending
                     select res).Take(5).ToList();
        Assert.Equal(5, query.Count);
        Assert.Contains(query, driver => driver.ToList()[0].Driver.Id == 1);
        Assert.Contains(query, driver => driver.ToList()[0].Driver.Id == 2);
        Assert.Contains(query, driver => driver.ToList()[0].Driver.Id == 3);
        Assert.Contains(query, driver => driver.ToList()[0].Driver.Id == 4);
        Assert.Contains(query, driver => driver.ToList()[0].Driver.Id == 5);
    }
    /// <summary>
    /// Fifth request - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    [Fact]
    public void InfoAboutCountTravelAvgTimeTravelMaxTimeTravel()
    {
        var fixtureTrip = _fixture.Trips.ToList();
        var fixtureDriver = _fixture.Drivers.ToList();
        var query = (from trip in fixtureTrip
                     join driver in fixtureDriver on trip.Driver.Id equals driver.Id
                     group trip by trip.Driver.Id into res
                     select new
                     {
                         fistName = res.First().Driver.FirstName,
                         lastName = res.First().Driver.LastName,
                         middleName = res.First().Driver.MiddleName,
                         tripsAmount = res.Count(),
                         averageTrips = res.Average(trip => (trip.TimeOff - trip.TimeOn).TotalHours),
                         maxTrip = res.Max(trip => (trip.TimeOff - trip.TimeOn).TotalHours)
                     }
                     ).ToList();
        Assert.Equal(5, query.Count);
        Assert.Contains(query, driver => driver.tripsAmount == 4);
        Assert.Contains(query, driver => driver.lastName == "Денисов");
        Assert.Contains(query, driver => driver.fistName == "Степан");
        Assert.Contains(query, driver => driver.middleName == "Денисович");
        Assert.Contains(query, driver => driver.maxTrip == 9.5);
    }
    /// <summary>
    /// Sixth request - Display information about the transports that made the maximum number of trips for the specified period.
    /// </summary>
    [Fact]
    public void TransportInfoWithMaxCountForSpecificDate()
    {
        var fixtureTrip = _fixture.Trips.ToList();
        var fixtureTransport = _fixture.Transports.ToList();
        var numOfTrips = (from trip in fixtureTrip
                          group trip by trip.Transport.Id into res
                          where res.First().Date < new DateTime(2023, 03, 20) && res.First().Date < new DateTime(2023, 03, 20)
                          select new
                          {
                              tansportId = res.First().Transport.Id,
                              tripsAmount = res.Count()
                          }).ToList();
        var query = (from trip in numOfTrips
                     join transport in fixtureTransport on trip.tansportId equals transport.Id
                     where (trip.tripsAmount == numOfTrips.Max(x => x.tripsAmount))
                     select new
                     {
                         transport,
                         trip.tripsAmount
                     }
                     ).ToList();
        Assert.Single(query);
        Assert.Contains(query, trip => trip.tripsAmount == 3);
        Assert.Contains(query, trip => trip.transport.Id == 2);
    }

}