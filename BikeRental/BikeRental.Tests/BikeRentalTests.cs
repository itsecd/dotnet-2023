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
    /// First request - give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestSportBikes()
    {
        var request = 
            from bike in _bikeRentalFixture.Bikes
            where bike.Type == _bikeRentalFixture.BikeTypes[2]
            select bike;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// Second request - give ordered by client's name info about all clients who have rented mountain bikes
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
}