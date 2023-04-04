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
                new Client(1, "20227171", DateTime.Parse("2002-09-06"), "Gusev", "Vladimir"),
                new Client(2, "20200121", DateTime.Parse("2003-01-16"), "Ivanov", "Ivan"),
                new Client(3, "39393939", DateTime.Parse("2007-08-31"), "Hatsune", "Miku"),
                new Client(3, "20202942", DateTime.Parse("1991-12-12"), "Evans", "Linda"),
                new Client(4, "20219372", DateTime.Parse("2004-09-28"), "Archiviste", "Noe")
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
                new Car(1, "Tesla Model S", "red", "b069sd"),
                new Car(2, "Rolls-Royce Boat Tail", "orange", "a777a"),
                new Car(3, "Bugatti La Voiture Noire", "black", "d111kn"),
                new Car(4, "Lamborghini Sesto Elemento", "dark grey", "k474cm"),
                new Car(5, "Lada Kalina", "blue", "s937nf")
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
                new RentalPoint(1, "Kchau", "445 Bowman Lane"),
                new RentalPoint(2, "Delimobile", "456 Lakeshore St."),
                new RentalPoint(3, "YandexIsEverywhere", "525 Elmwood Lane"),
                new RentalPoint(4, "July's", "7411 Kent Ave.")
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
                new RentedCar(1, clients[0], 1, rentalPoint[3], 4, allCars[0], 1, DateTime.Parse("2023-02-21"), 5),
                new RentedCar(2, clients[2], 3, rentalPoint[0], 1, allCars[1], 2, DateTime.Parse("2023-03-02"), 3),
                new RentedCar(3, clients[1], 2, rentalPoint[1], 2, allCars[0], 1, DateTime.Parse("2023-02-25"), 1),
                new RentedCar(4, clients[3], 4, rentalPoint[2], 3, allCars[2], 3, DateTime.Parse("2023-03-21"), 2),
                new RentedCar(5, clients[2], 3, rentalPoint[3], 4, allCars[0], 1, DateTime.Parse("2023-03-01"), 5),
                new RentedCar(6, clients[1], 2, rentalPoint[1], 2, allCars[0], 1, DateTime.Parse("2023-03-11"), 9),
                new RentedCar(7, clients[0], 1, rentalPoint[0], 1, allCars[3], 4, DateTime.Parse("2023-03-04"), 4),
                new RentedCar(8, clients[1], 2, rentalPoint[2], 3, allCars[4], 5, DateTime.Parse("2023-03-05"), 2),
                new RentedCar(9, clients[0], 1, rentalPoint[0], 1, allCars[4], 5, DateTime.Parse("2023-04-04"), 5)
            };
            return rentedCar;
        }
    }
}