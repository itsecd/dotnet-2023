using BikeRental.Domain;
using System.Threading.Tasks.Dataflow;

namespace BikeRental.Tests;

public class BikeRentalTests
{
    /// <summary>
    /// First request - give info about all sport bikes
    /// </summary>
    [Fact]
    public void TestSportBikes()
    {
        var bikeTypes = new List<BikeType>
        {
            new BikeType{ Id = 1, TypeName = "горный", RentCost = 300 },
            new BikeType{ Id = 1, TypeName = "прогулочный", RentCost = 100 },
            new BikeType{ Id = 1, TypeName = "спртивный", RentCost = 200 }
        };

        var bikes = new List<Bike>
        {
            new Bike { Id = 1, SerialNumber = 12345, Model = "Model1", Color = "green", Type = bikeTypes[0] },
            new Bike { Id = 2, SerialNumber = 23451, Model = "Model2", Color = "green", Type = bikeTypes[1] },
            new Bike { Id = 3, SerialNumber = 34512, Model = "Model3", Color = "green", Type = bikeTypes[2] },
            new Bike { Id = 4, SerialNumber = 45123, Model = "Model4", Color = "green", Type = bikeTypes[0] },
            new Bike { Id = 5, SerialNumber = 51234, Model = "Model5", Color = "green", Type = bikeTypes[2] }
        };

        var request = 
            from bike in bikes
            where bike.Type == bikeTypes[2]
            select bike;

        Assert.Equal(2, request.Count());
    }

    /// <summary>
    /// Second request - give ordered by client's name info about all clients who have rented mountain bikes
    /// </summary>
    [Fact]
    public void TestMountainBikes()
    {
        var bikeTypes = new List<BikeType>
        {
            new BikeType{ Id = 1, TypeName = "горный", RentCost = 300 },
            new BikeType{ Id = 2, TypeName = "прогулочный", RentCost = 100 },
            new BikeType{ Id = 3, TypeName = "спртивный", RentCost = 200 }
        };

        var bikes = new List<Bike>
        {
            new Bike { Id = 1, SerialNumber = 12345, Model = "Model1", Color = "green", Type = bikeTypes[0] },
            new Bike { Id = 2, SerialNumber = 23451, Model = "Model2", Color = "green", Type = bikeTypes[1] },
            new Bike { Id = 3, SerialNumber = 34512, Model = "Model3", Color = "green", Type = bikeTypes[2] },
            new Bike { Id = 4, SerialNumber = 45123, Model = "Model4", Color = "green", Type = bikeTypes[0] },
            new Bike { Id = 5, SerialNumber = 51234, Model = "Model5", Color = "green", Type = bikeTypes[2] }
        };

        var clients = new List<Client>
        {
            new Client { Id = 1, FullName = "Ivan Ivanov", BirthYear = 1995, PhoneNumber = "+7(927)123-45-67"},
            new Client { Id = 2, FullName = "Petr Petrov", BirthYear = 1992, PhoneNumber = "+7(927)123-45-68"},
            new Client { Id = 3, FullName = "Kuznec Kuznecov", BirthYear = 1986, PhoneNumber = "+7(927)123-45-69"},
            new Client { Id = 4, FullName = "Andrey Andreev", BirthYear = 2000, PhoneNumber = "+7(927)123-45-60"},
            new Client { Id = 4, FullName = "Ignat Ignatiev", BirthYear = 2001, PhoneNumber = "+7(927)123-45-61"}
        };

        var records = new List<RentRecord>
        {
            new RentRecord { Id = 1, ClientName = "Ivan Ivanov", BikeSerialNumber = 12345, RentStartTime= DateTime.Parse("2023-01-1 13:45"), RentEndTime= DateTime.Parse("2023-01-1 14:45") },
            new RentRecord { Id = 2, ClientName = "Petr Petrov", BikeSerialNumber = 23451, RentStartTime= DateTime.Parse("2023-01-1 15:45"), RentEndTime= DateTime.Parse("2023-01-1 16:45") },
            new RentRecord { Id = 3, ClientName = "Kuznec Kuznecov", BikeSerialNumber = 34512, RentStartTime= DateTime.Parse("2023-01-1 10:45"), RentEndTime= DateTime.Parse("2023-01-1 11:45") },
            new RentRecord { Id = 4, ClientName = "Andrey Andreev", BikeSerialNumber = 45123, RentStartTime= DateTime.Parse("2023-01-1 8:45"), RentEndTime= DateTime.Parse("2023-01-1 9:45") },
            new RentRecord { Id = 5, ClientName = "Ignat Ignatiev", BikeSerialNumber = 12345, RentStartTime= DateTime.Parse("2023-01-1 19:45"), RentEndTime= DateTime.Parse("2023-01-1 20:45") }
        };

        var request = 
            from client in clients
            join record in records on client.FullName equals record.ClientName
            join bike in bikes on record.BikeSerialNumber equals bike.SerialNumber
            where bike.Type == bikeTypes[0]
            orderby client.FullName 
            select client;

        Assert.Equal(3, request.Count());
    }
}