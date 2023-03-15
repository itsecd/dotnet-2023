using CarSharingDomain;
namespace CarSharingTests;
public class CarFixture
{
    /// <summary>
    /// list of clients to test queries
    /// </summary>
    public List<Client> FixtureClient
    {
        get
        {
            var clients = new List<Client>()
            {
                new Client(Guid.NewGuid(), "20227171", DateTime.Parse("2002-09-06"), "Gusev", "Vladimir"),
                new Client(Guid.NewGuid(), "20200121", DateTime.Parse("2003-01-16"), "Ivanov", "Ivan"),
                new Client(Guid.NewGuid(), "39393939", DateTime.Parse("2007-08-31"), "Hatsune", "Miku"),
                new Client(Guid.NewGuid(), "20202942", DateTime.Parse("1991-12-12"), "Evans", "Linda"),
                new Client(Guid.NewGuid(), "20219372", DateTime.Parse("2004-09-28"), "Archiviste", "Noe")
            };
            return clients;
        }
    }
    /// <summary>
    /// list of available cars to test queries
    /// </summary>
    public List<Car> FixtureCar
    {
        get
        {
            var allCars = new List<Car>()
            {
                new Car(Guid.NewGuid(), "Tesla Model S", "red", "b069sd"),
                new Car(Guid.NewGuid(), "Rolls-Royce Boat Tail", "orange", "a777a"),
                new Car(Guid.NewGuid(), "Bugatti La Voiture Noire", "black", "d111kn"),
                new Car(Guid.NewGuid(), "Lamborghini Sesto Elemento", "dark grey", "k474cm"),
                new Car(Guid.NewGuid(), "Lada Kalina", "blue", "s937nf")
            };
            return allCars;
        }
    }
    /// <summary>
    /// list of rental points to test queries
    /// </summary>
    public List<RentalPoint> FixtureRentalPoint
    {
        get
        {
            var rentalPoint = new List<RentalPoint>()
            {
                new RentalPoint(Guid.NewGuid(), "Kchau", "445 Bowman Lane"),
                new RentalPoint(Guid.NewGuid(), "Delimobile", "456 Lakeshore St."),
                new RentalPoint(Guid.NewGuid(), "YandexIsEverywhere", "525 Elmwood Lane"),
                new RentalPoint(Guid.NewGuid(), "July's", "7411 Kent Ave.")
            };
            return rentalPoint;
        }
    }
    public List<RentedCar> FixtureRentedCar
    {
        get
        {
            var clients = FixtureClient;
            var allCars = FixtureCar;
            var rentalPoint = FixtureRentalPoint;
            var rentedCar = new List<RentedCar>()
            {
                new RentedCar(Guid.NewGuid(), clients[0], rentalPoint[3] , allCars[0], DateTime.Parse("2023-02-21"), 5),
                new RentedCar(Guid.NewGuid(), clients[2], rentalPoint[0] , allCars[1], DateTime.Parse("2023-03-02"), 3),
                new RentedCar(Guid.NewGuid(), clients[1], rentalPoint[1] , allCars[0], DateTime.Parse("2023-02-25"), 1),
                new RentedCar(Guid.NewGuid(), clients[3], rentalPoint[2] , allCars[2], DateTime.Parse("2023-02-21"), 2),
                new RentedCar(Guid.NewGuid(), clients[2], rentalPoint[3] , allCars[0], DateTime.Parse("2023-03-01"), 5),
                new RentedCar(Guid.NewGuid(), clients[1], rentalPoint[1] , allCars[0], DateTime.Parse("2023-03-11"), 9),
                new RentedCar(Guid.NewGuid(), clients[0], rentalPoint[0] , allCars[3], DateTime.Parse("2023-03-04"), 4),
                new RentedCar(Guid.NewGuid(), clients[1], rentalPoint[2] , allCars[4], DateTime.Parse("2023-03-05"), 2),
                new RentedCar(Guid.NewGuid(), clients[0], rentalPoint[0] , allCars[4], DateTime.Parse("2023-03-04"), 5)
            };
            return rentedCar;
        }
    }
}