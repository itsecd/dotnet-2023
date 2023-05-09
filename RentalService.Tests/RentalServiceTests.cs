using RentalService.Domain;

namespace RentalService.Tests;

public class RentalServiceTests : IClassFixture<RentalServiceFixture>
{
    private readonly RentalServiceFixture _fixture;

    public RentalServiceTests(RentalServiceFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    ///     Display information about all vehicles
    /// </summary>
    [Fact]
    public void InformationAboutVehicles()
    {
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<Vehicle> vehicles = _fixture.FixtureVehicle;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }

        var query = (from vehicle in vehicles
            select new
            {
                vehicle.Id,
                vehicle.Number,
                ModelId = vehicle.VehicleModelId,
                vehicle.Colour
            }).ToList();

        Assert.Contains(query, elem => elem.Number == "Х547ХМ18");
        Assert.Contains(query, elem => elem.ModelId == 3);
        Assert.DoesNotContain(query, elem => elem.Colour == "Фиолетовый");
    }

    /// <summary>
    ///     Display information about all customers who have rented cars of the specified model, arrange by full name
    /// </summary>
    [Fact]
    public void ClientsWhoTookTheVehicleOfTheSpecifiedModel()
    {
        List<Client> clients = _fixture.FixtureClient;
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<Vehicle> vehicles = _fixture.FixtureVehicle;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            clients[(int)issuedCar.ClientId - 1].RentedCars.Add(issuedCar);
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }

        var query = (from client in clients
            join issuedCar in issuedCars on client.Id equals issuedCar.ClientId
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            where vehicle.VehicleModelId == 1
            orderby client.LastName, client.FirstName, client.Patronymic
            select new
            {
                lastName = client.LastName,
                firstName = client.FirstName,
                patronymic = client.Patronymic,
                passport = client.Passport,
                birthDate = client.BirthDate
            }).ToList();

        Assert.Equal(1, query.Count);
        Assert.Contains(query, elem => elem.lastName == "Яруллин");
        Assert.DoesNotContain(query, elem => elem.lastName == "Аникин");
        Assert.DoesNotContain(query, elem => elem.lastName == "Щербинина");
        Assert.DoesNotContain(query, elem => elem.lastName == "Горева");
        Assert.DoesNotContain(query, elem => elem.lastName == "Лапидус");
    }

    /// <summary>
    ///     Display information about cars that are rented
    /// </summary>
    [Fact]
    public void CarsForRent()
    {
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<Vehicle> vehicles = _fixture.FixtureVehicle;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }

        var query = (from issuedCar in issuedCars
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            where issuedCar.RefundInformationId == null
            select new
            {
                number = vehicle.Number,
                modelId = vehicle.VehicleModelId,
                colour = vehicle.Colour
            }).ToList();

        Assert.Equal(1, query.Count);
        Assert.Contains(query, elem => elem.number == "Н818ОО35");
        Assert.DoesNotContain(query, elem => elem.number == "К622КА39");
        Assert.DoesNotContain(query, elem => elem.number == "М018ЕС73");
        Assert.DoesNotContain(query, elem => elem.number == "Н728МН81");
        Assert.DoesNotContain(query, elem => elem.number == "Х547ХМ18");
    }

    /// <summary>
    ///     Display information about the top 5 most frequently rented cars
    /// </summary>
    [Fact]
    public void TopFiveFrequentlyRentedVehicles()
    {
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<Vehicle> vehicles = _fixture.FixtureVehicle;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }

        var query = (from issuedCar in issuedCars
            join vehicle in vehicles on issuedCar.VehicleId equals vehicle.Id
            orderby vehicle.RentalCases.Count
            select new
            {
                number = vehicle.Number,
                modelId = vehicle.VehicleModelId,
                colour = vehicle.Colour,
                count = vehicle.RentalCases.Count
            }).Take(5).ToList();

        Assert.Equal(5, query.Count);
    }

    /// <summary>
    ///     Print the number of leases for each car
    /// </summary>
    [Fact]
    public void NumberOfCarRentals()
    {
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<Vehicle> vehicles = _fixture.FixtureVehicle;

        foreach (IssuedCar issuedCar in issuedCars)
        {
            vehicles[(int)issuedCar.VehicleId - 1].RentalCases.Add(issuedCar);
        }

        var query = (from vehicle in vehicles
            select new
            {
                number = vehicle.Number,
                modelId = vehicle.VehicleModelId,
                colour = vehicle.Colour,
                rentalCasesCount = vehicle.RentalCases.Count
            }).ToList();

        Assert.Equal(5, query.Count);
        Assert.Contains(query, elem => elem.number == "К622КА39" && elem.rentalCasesCount == 1);
        Assert.DoesNotContain(query, elem => elem.number == "Х547ХМ18" && elem.rentalCasesCount > 1);
    }

    /// <summary>
    ///     Display information about rental locations where cars have been rented the maximum number of times,
    ///     arrange by name
    /// </summary>
    [Fact]
    public void TopCarRentalLocations()
    {
        List<IssuedCar> issuedCars = _fixture.FixtureIssuedCar;
        List<RentalInformation> rentalInformations = _fixture.FixtureRentalInformation;
        List<RentalPoint> rentalPoints = _fixture.FixtureRentalPoint;

        var subquery = (from issuedCar in issuedCars
            join rentalInformation in rentalInformations on issuedCar.RentalInformationId equals rentalInformation.Id
            join rentalPoint in rentalPoints on rentalInformation.RentalPointId equals rentalPoint.Id
            group rentalPoint.Id by rentalPoint
            into grp
            select new
            {
                grp.Key.Title,
                grp.Key.Address,
                count = grp.Count()
            }).ToList();

        var maxNumberOfRents = subquery.Max(elem => elem.count);

        var query = (from sq in subquery
            where sq.count == maxNumberOfRents
            select sq).ToList();

        Assert.Equal(1, query.Count);
        Assert.Contains(query, elem => elem.count == 2);
        Assert.Contains(query, elem => elem.Title == "Бумеранг-Авто");
        Assert.DoesNotContain(query, elem => elem.Title == "Соло");
    }
}