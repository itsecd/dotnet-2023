using Microsoft.EntityFrameworkCore;

namespace CarSharingDomain;
/// <summary>
/// DbContext for carsharing
/// </summary>
public class CarSharingDbContext : DbContext
{
    /// <summary>
    /// Store cars which can be rented or already in rent
    /// </summary>
    public DbSet<Car>? Cars { get; set; } = null!;
    /// <summary>
    /// Store clients of carsharing service
    /// </summary>
    public DbSet<Client>? Clients { get; set; } = null!;
    /// <summary>
    /// Store rental points where cars can be rented
    /// </summary>
    public DbSet<RentalPoint>? RentalPoints { get; set; } = null!;
    /// <summary>
    /// Store info about rented car and return period
    /// </summary>
    public DbSet<RentedCar>? RentedCars { get; set; } = null!;
    /// <summary>
    /// Creation of database
    /// </summary>
    /// <param name="options"></param>
    public CarSharingDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*var cars = new List<Car>()
        {
            new Car { Model = "Tesla Model S", Colour = "black", Id = 1, Number = "a000aa" },
            new Car { Model = "Rolls-Royce Boat Tail", Colour = "red", Id = 2, Number = "b069sd" },
            new Car { Model = "Bugatti La Voiture Noire", Colour = "gray", Id = 3, Number = "b111bb" },
            new Car { Model = "Lamborghini Sesto Elemento", Colour = "red", Id = 4, Number = "c222cc" },
            new Car { Model = "Lada Kalina", Colour = "blue", Id = 5, Number = "d444dd" }
        };

        var clients = new List<Client>()
        {
            new Client { Passport = "21210707", BirthDate = DateTime.Parse("2002-09-07"), FirstName = "Vladimir", LastName = "Gusev", Id = 1 },
            new Client { Passport = "39393939", BirthDate = DateTime.Parse("2007-08-31"), FirstName = "Miku", LastName = "Hatsune", Id = 2 },
            new Client { Passport = "21219327", BirthDate = DateTime.Parse("2004-09-28"), FirstName = "Noe", LastName = "Archiviste", Id = 3 },
            new Client { Passport = "21215555", BirthDate = DateTime.Parse("2005-04-09"), FirstName = "Vil", LastName = "Schoenheit", Id = 4 },
            new Client { Passport = "21209897", BirthDate = DateTime.Parse("2002-06-24"), FirstName = "Rui", LastName = "Kamishiro", Id = 5 }
        };

        var rentalPoints = new List<RentalPoint>() {
            new RentalPoint {PointName = "Kchau", PointAddress = "445 Bowman Lane", Id = 1},
            new RentalPoint { PointName = "July's", PointAddress = "7411 Kent Ave.", Id = 2 },
            new RentalPoint { PointName = "YandexIsEverywhere", PointAddress = "525 Elmwood Lane", Id = 3 },
            new RentalPoint {PointName = "TachkiNaProkat", PointAddress = "7901 East Sussex St.", Id = 4 },
            new RentalPoint { PointName = "AAA", PointAddress = "4170 Gregory Road", Id = 5 }
        };

        var rentedCars = new List<RentedCar>() {
            new RentedCar{ Id = 1, CarId = 1, RentalPointId = 4, ClientId = 1 ,TimeOfRent = DateTime.Parse("2023-02-21"), RentPeriod = 5},*/
        /*new RentedCar{ Id = 2, Car = cars[1], Point = rentalPoints[0], Client = clients[2], TimeOfRent = DateTime.Parse("2023-03-02"), RentPeriod = 3},
        new RentedCar{ Id = 3, Car = cars[0], Point = rentalPoints[1], Client = clients[1], TimeOfRent = DateTime.Parse("2023-02-25"), RentPeriod = 1},
        new RentedCar{ Id = 4, Car = cars[2], Point = rentalPoints[2], Client = clients[3], TimeOfRent = DateTime.Parse("2023-03-21"), RentPeriod = 2},
        new RentedCar{ Id = 5, Car = cars[0], Point = rentalPoints[3], Client = clients[2], TimeOfRent = DateTime.Parse("2023-03-01"), RentPeriod = 5},
        new RentedCar{ Id = 6, Car = cars[0], Point = rentalPoints[1], Client = clients[1], TimeOfRent = DateTime.Parse("2023-05-02"), RentPeriod = 9},
        new RentedCar{ Id = 7, Car = cars[3], Point = rentalPoints[0], Client = clients[0], TimeOfRent = DateTime.Parse("2023-03-11"), RentPeriod = 4},
        new RentedCar{ Id = 8, Car = cars[4], Point = rentalPoints[2], Client = clients[1], TimeOfRent = DateTime.Parse("2023-04-02"), RentPeriod = 2},
        new RentedCar{ Id = 9, Car = cars[4], Point = rentalPoints[0], Client = clients[0], TimeOfRent = DateTime.Parse("2023-05-01"), RentPeriod = 5}*/
        //};

        /*modelBuilder.Entity<RentedCar>().HasOne(rentedCar => rentedCar.Point).WithMany(rentalPoint => rentalPoint.RentedCars).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<RentedCar>().HasOne(rentedCar => rentedCar.Client).WithMany(client => client.RentedCars).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<RentedCar>().HasOne(rentedCar => rentedCar.Car).WithMany(car => car.RentedCars).OnDelete(DeleteBehavior.Cascade);*/

        /*modelBuilder.Entity<Car>().HasData(cars);
        modelBuilder.Entity<Client>().HasData(clients);
        modelBuilder.Entity<RentalPoint>().HasData(rentalPoints);
        modelBuilder.Entity<RentedCar>().HasData(rentedCars);*/
        var car1 = new Car { Model = "Tesla Model S", Colour = "black", Id = 1, Number = "a000aa" };
        var car2 = new Car { Model = "Rolls-Royce Boat Tail", Colour = "red", Id = 2, Number = "b069sd" };
        var car3 = new Car { Model = "Bugatti La Voiture Noire", Colour = "gray", Id = 3, Number = "b111bb" };
        var car4 = new Car { Model = "Lamborghini Sesto Elemento", Colour = "red", Id = 4, Number = "c222cc" };
        var car5 = new Car { Model = "Lada Kalina", Colour = "blue", Id = 5, Number = "d444dd" };
        modelBuilder.Entity<Car>().HasData(new List<Car> { car1, car2, car3, car4, car5 });

        var client1 = new Client { Passport = "21210707", BirthDate = DateTime.Parse("2002-09-07"), FirstName = "Vladimir", LastName = "Gusev", Id = 1 };
        var client2 = new Client { Passport = "39393939", BirthDate = DateTime.Parse("2007-08-31"), FirstName = "Miku", LastName = "Hatsune", Id = 2 };
        var client3 = new Client { Passport = "21219327", BirthDate = DateTime.Parse("2004-09-28"), FirstName = "Noe", LastName = "Archiviste", Id = 3 };
        var client4 = new Client { Passport = "21215555", BirthDate = DateTime.Parse("2005-04-09"), FirstName = "Vil", LastName = "Schoenheit", Id = 4 };
        var client5 = new Client { Passport = "21209897", BirthDate = DateTime.Parse("2002-06-24"), FirstName = "Rui", LastName = "Kamishiro", Id = 5 };
        modelBuilder.Entity<Client>().HasData(new List<Client> { client1, client2, client3, client4, client5 });

        var rentalPoint1 = new RentalPoint { PointName = "Kchau", PointAddress = "445 Bowman Lane", Id = 1 };
        var rentalPoint2 = new RentalPoint { PointName = "Julys", PointAddress = "7411 Kent Ave.", Id = 2 };
        var rentalPoint3 = new RentalPoint { PointName = "YandexIsEverywhere", PointAddress = "525 Elmwood Lane", Id = 3 };
        var rentalPoint4 = new RentalPoint { PointName = "TachkiNaProkat", PointAddress = "7901 East Sussex St.", Id = 4 };
        var rentalPoint5 = new RentalPoint { PointName = "AAA", PointAddress = "4170 Gregory Road", Id = 5 };
        modelBuilder.Entity<RentalPoint>().HasData(new List<RentalPoint> { rentalPoint1, rentalPoint2, rentalPoint3, rentalPoint4, rentalPoint5 }); 



        modelBuilder.Entity<RentedCar>().HasData(new List<RentedCar>
         {
             new RentedCar{ Id = 1, ClientId = 1, RentalPointId=4, CarId=1, TimeOfRent=DateTime.Parse("2023-02-21"), RentPeriod = 5},
             new RentedCar{ Id = 2, CarId=2, ClientId = 3, RentalPointId=1 , TimeOfRent=DateTime.Parse("2023-03-02"), RentPeriod = 3},
             new RentedCar{ Id = 3, CarId=1, ClientId = 2, RentalPointId=2 , TimeOfRent=DateTime.Parse("2023-02-25"), RentPeriod = 1},
             new RentedCar{ Id = 4, CarId=3, ClientId = 4, RentalPointId=3 , TimeOfRent=DateTime.Parse("2023-03-21"), RentPeriod = 2},
             new RentedCar{ Id = 5, CarId=1, ClientId = 3, RentalPointId=4 , TimeOfRent=DateTime.Parse("2023-03-01"), RentPeriod = 5},
             new RentedCar{ Id = 6, CarId=1, ClientId = 2, RentalPointId=2 , TimeOfRent=DateTime.Parse("2023-05-02"), RentPeriod = 9},
             new RentedCar{ Id = 7, CarId=4, ClientId = 1, RentalPointId=1 , TimeOfRent=DateTime.Parse("2023-03-11"), RentPeriod = 4},
             new RentedCar{ Id = 8, CarId=5, ClientId = 2, RentalPointId=3 , TimeOfRent=DateTime.Parse("2023-04-02"), RentPeriod = 2},
             new RentedCar{ Id = 9, CarId=5, ClientId = 1, RentalPointId=1 , TimeOfRent=DateTime.Parse("2023-05-01"), RentPeriod = 5},
         });
    }
}
