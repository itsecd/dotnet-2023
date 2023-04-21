using TaxiDepo.Domain;

namespace TaxiDepo.Server.Repositories;

/// <summary>
/// Interface TaxiDepoRepository
/// </summary>
public interface ITaxiDepoRepository
{
    /// <summary>
    /// List if Driver class object
    /// </summary>
    List<Driver> Drivers { get; }
    /// <summary>
    /// List if Car class object
    /// </summary>
    List<Car> Cars { get; }
    /// <summary>
    /// List if User class object
    /// </summary>
    List<User> Users { get; }
    /// <summary>
    /// List if Rides class object
    /// </summary>
    List<Ride> Rides { get; }
}
/// <summary>
/// TaxiDepoRepository class
/// </summary>
public class TaxiDepoRepository : ITaxiDepoRepository
{
    /// <summary>
    /// Constructor without params
    /// </summary>
    public TaxiDepoRepository()
    {
        Drivers = new List<Driver>
        {
            new Driver(0, "Antonov", "Viktor", "Pavlovich",
                14557586, "Samara Lenina 25, 4", "89791113223", new Car(0, "A279TT163", "BMW E34", "Purple")),
            new Driver(1, "Antipov", "Anton", "Viktorovich", 
                21534496, "Samara Stalina 115, 43", "89343322223", new Car(1, "M777MM763", "Mercedes E63", "Black")),
            new Driver(2, "Pavlov", "Sergey", "Sergeevich", 
                37927348, "Samara Nikonova 205, 49", "87983839938", new Car(2, "A279TT163", "BMW E34", "Purple")),
            new Driver(3, "Tolov", "Dmitriy", "Stanislavovich", 
                93894829, "Samara Pavlova 99, 99", "89111199993", new Car(3, "A279TT163", "BMW E34", "Purple")),
            new Driver(4, "Sipov", "Pavel", "Antonovich", 
                34943834, "Samara Vokzalnaya 32, 533", "89787293792", new Car(4, "A279TT163", "BMW E34", "Purple")),
        };

        Cars = new List<Car>
        {
            new Car(0, "A279TT163", "BMW E34", "Purple"),
            new Car(1, "M777MM763", "Mercedes E63", "Black"),
            new Car(2, "B281BB777", "Toyota corolla", "White"),
            new Car(3, "A909BA102", "Toyota LC200", "Yellow"),
            new Car(4, "M763MM763", "Lada Vesta", "White"),
            new Car(5, "E700EA77", "Lada Priora", "Orange"),
            new Car(6, "M808AM63", "Geely Emgrand", "Blue"),
        };

        Users = new List<User>
        {
            new User(0, "Vitov", "Viktor", "Vladimirovich", "89193829222"),
            new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434"),
            new User(2, "Topov", "Andrey", "Dmitrievich", "89889230233"),
            new User(3, "Losev", "Pavel", "Yanovich", "89230039402"),
            new User(4, "Lisov", "Vladimir", "Artmovich", "89177373403")
        };
        
        Rides = new List<Ride>
        {
            new Ride(0, "Samara Lisova 15", "Samara Lisova 113", 
                new DateTime(2020, 05, 14,22, 43, 42), 
                new TimeSpan(2, 3, 4), 
                341.23, Cars[0],
                Users[4]),
            
            new Ride(1, "Samara Antonova 25", "Samara Vitova 122", 
                new DateTime(2020, 06, 22, 15,53, 54), 
                new TimeSpan(1, 32, 4), 
                129.22, Cars[0],
                Users[4]),
            
            new Ride(2, "Samara Vlasova 77", "Samara Motova 222", 
                new DateTime(2021, 11,29, 19, 20, 22), 
                new TimeSpan(1, 19, 4), 
                472.41, Cars[1], 
                Users[1]),
            
            new Ride(3, "Samara Tolova 9", "Samara Stakova 91", 
                new DateTime(2022,01, 19, 18, 30, 20), 
                new TimeSpan(1, 13, 42),  
                99.11, Cars[2], 
                Users[1]),
            
            new Ride(4, "Samara Olova 9", "Samara Stakova 91", 
                new DateTime(2022,01, 19, 18, 30, 20), 
                new TimeSpan(1, 13, 42),  
                99.11, Cars[3],
                Users[1]),
            
            new Ride(5, "Samara Rolova 9", "Samara Stakova 91", 
                new DateTime(2022,01, 19, 18, 30, 20), 
                new TimeSpan(1, 13, 42),  
                99.11, Cars[4],
                Users[3]),
        };
    }
    /// <summary>
    /// Implement list of Drivers
    /// </summary>
    public List<Driver> Drivers { get; }

    /// <summary>
    /// Implement list of Cars
    /// </summary>
    public List<Car> Cars { get; }

    /// <summary>
    /// Implement list of Users
    /// </summary>
    public List<User> Users { get; }

    /// <summary>
    /// Implement list of Rides
    /// </summary>
    public List<Ride> Rides { get; }
}