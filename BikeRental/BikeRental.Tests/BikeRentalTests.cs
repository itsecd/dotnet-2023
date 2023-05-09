using BikeRental.Domain;
using System.Threading.Tasks.Dataflow;

namespace BikeRental.Tests;

public class BikeRentalTests : IClassFixture<BikeRentalFixture>
{
    private readonly BikeRentalFixture _bikeRentalFixture;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="bikeRentalFixture"></param>
    public BikeRentalTests(BikeRentalFixture bikeRentalFixture)
    {
        _bikeRentalFixture = bikeRentalFixture;
    }

    /// <summary>
    /// 1st request - give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestSportBikes()
    {
        var request = 
            from bike in _bikeRentalFixture.Bikes
            where bike.Type == _bikeRentalFixture.BikeTypes[2]
            select bike;

        Assert.Equal(3, request.Count());
    }

    /// <summary>
    /// 2nd request - give ordered by client's name info about all clients who have rented mountain bikes
    /// </summary>
    [Fact]
    public void TestMountainBikes()
    {
        var request = 
            from client in _bikeRentalFixture.Clients
            join record in _bikeRentalFixture.Records on client.FullName equals record.ClientName
            join bike in _bikeRentalFixture.Bikes on record.BikeSerialNumber equals bike.SerialNumber
            where bike.Type == _bikeRentalFixture.BikeTypes[0]
            orderby client.FullName 
            select client;

        Assert.Equal(3, request.Count());
    }

    /// <summary>
    /// 3rd request - give total rent time for each bike type
    /// </summary>
    [Fact]
    public void TestTypeTime()
    {
        var request =
            (from record in _bikeRentalFixture.Records
             join bike in _bikeRentalFixture.Bikes on record.BikeSerialNumber equals bike.SerialNumber
             group record by bike.Type.Id into BikeTypeGroup
             select new
             {
                 type = BikeTypeGroup.Key,
                 time = BikeTypeGroup.Sum(x => (x.RentEndTime - x.RentStartTime).TotalMinutes)
             }).ToList();

        Assert.Equal(3, request.Count);
        Assert.Equal(180, request[0].time);
        Assert.Equal(120, request[1].time);
        Assert.Equal(183, request[2].time);
    }

    /// <summary>
    /// 4th request - give info about clients who have rented bikes the most
    /// </summary>
    [Fact]
    public void TestRentAmount()
    {
        var rentAmount =
            (from record in _bikeRentalFixture.Records
             orderby record.ClientName
             group record by record.ClientName into clientGroup
             select new
             {
                 name = clientGroup.Key,
                 counter = clientGroup.Distinct().Count()
             }).ToList();
        var maxRent =
            (from record in rentAmount
             where record.counter == rentAmount.Max(rents => rents.counter)
             select record.name).ToList();

        Assert.Equal("Ivan Ivanov", maxRent[0]);
    }

    /// <summary>
    /// 5th request - give info about 5 most rented bikes
    /// </summary>
    [Fact]
    public void TestMostRentedBikes()
    {
        var counter = 
            (from record in _bikeRentalFixture.Records
             group record by record.BikeSerialNumber into bikeRents
             select new
             {
                 number = bikeRents.Key,
                 count = bikeRents.Count()
             }).ToList();
        var result = (from bikecounter in counter orderby bikecounter.count descending select bikecounter).Take(5).ToList();

        Assert.Equal(5, result.Count);
    }

    /// <summary>
    /// 6th request - give info about min, max and average rent time
    /// </summary>
    [Fact]
    public void TestRentTime()
    {
        var time =
            (from record in _bikeRentalFixture.Records
             select new
             {
                 id = record.Id,
                 rentTime = (record.RentEndTime - record.RentStartTime).TotalMinutes
             }).ToList();

        Assert.Equal(60, time.Min(timeCount => timeCount.rentTime));
        Assert.Equal(123, time.Max(timeCount => timeCount.rentTime));
        Assert.Equal(69, time.Average(timeCount => timeCount.rentTime));
    }
}