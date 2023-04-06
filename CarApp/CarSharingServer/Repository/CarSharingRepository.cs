namespace CarSharingServer.Repository;
using CarSharingDomain;
/// <summary>
/// Data repository to contain all data about Cars, Rental points, Clients and Rented cars
/// </summary>
public class CarSharingRepository:ICarSharingRepository
{
    private readonly List<Client> _clients;
    private readonly List<Car> _cars;
    private readonly List<RentalPoint> _rentalPoints;
    private readonly List<RentedCar> _rentedCars;
    /// <summary>
    /// Constructor for CarSharingRepository
    /// </summary>
    public CarSharingRepository()
    {

        _clients = new List<Client>()
        {
            new Client(1, "20227171", DateTime.Parse("2002-09-06"), "Gusev", "Vladimir"),
            new Client(2, "20200121", DateTime.Parse("2003-01-16"), "Ivanov", "Ivan"),
            new Client(3, "39393939", DateTime.Parse("2007-08-31"), "Hatsune", "Miku"),
            new Client(4, "20202942", DateTime.Parse("2005-04-09"), "Schoenheit", "Vil"),
            new Client(5, "20219372", DateTime.Parse("2004-09-28"), "Archiviste", "Noe")
        };

        _cars = new List<Car>()
        {
            new Car(1, "Tesla Model S", "red", "b069sd"),
            new Car(2, "Rolls-Royce Boat Tail", "orange", "a777a"),
            new Car(3, "Bugatti La Voiture Noire", "black", "d111kn"),
            new Car(4, "Lamborghini Sesto Elemento", "dark grey", "k474cm"),
            new Car(5, "Lada Kalina", "blue", "s937nf")
        };

        _rentalPoints = new List<RentalPoint>()
        {
            new RentalPoint(1, "Kchau", "445 Bowman Lane"),
            new RentalPoint(2, "Delimobile", "456 Lakeshore St."),
            new RentalPoint(3, "YandexIsEverywhere", "525 Elmwood Lane"),
            new RentalPoint(4, "July's", "7411 Kent Ave.")
        };

        _rentedCars = new List<RentedCar>()
        {
             new RentedCar(1, _clients[0], 1, _rentalPoints[3], 4, _cars[0], 1, DateTime.Parse("2023-02-21"), 5),
             new RentedCar(2, _clients[2], 3, _rentalPoints[0], 1, _cars[1], 2, DateTime.Parse("2023-03-02"), 3),
             new RentedCar(3, _clients[1], 2, _rentalPoints[1], 2, _cars[0], 1, DateTime.Parse("2023-02-25"), 1),
             new RentedCar(4, _clients[3], 4, _rentalPoints[2], 3, _cars[2], 3, DateTime.Parse("2023-03-21"), 2),
             new RentedCar(5, _clients[2], 3, _rentalPoints[3], 4, _cars[0], 1, DateTime.Parse("2023-03-01"), 5),
             new RentedCar(6, _clients[1], 2, _rentalPoints[1], 2, _cars[0], 1, DateTime.Parse("2023-03-11"), 9),
             new RentedCar(7, _clients[0], 1, _rentalPoints[0], 1, _cars[3], 4, DateTime.Parse("2023-04-04"), 5),
             new RentedCar(8, _clients[1], 2, _rentalPoints[2], 3, _cars[4], 5, DateTime.Parse("2023-03-05"), 2),
             new RentedCar(9, _clients[0], 1, _rentalPoints[0], 1, _cars[4], 5, DateTime.Parse("2023-04-04"), 10)
        };
    }
    /// <summary>
    /// List of all clients and info about them
    /// </summary>
    public List<Client> Clients => _clients;
    /// <summary>
    /// List of all cars and info about it
    /// </summary>
    public List<Car> Cars => _cars;
    /// <summary>
    /// List of all rental points and info about it
    /// </summary>
    public List<RentalPoint> RentalPoints => _rentalPoints;
    /// <summary>
    /// List of rented cars and info about it
    /// </summary>
    public List<RentedCar> RentedCars => _rentedCars;
}
