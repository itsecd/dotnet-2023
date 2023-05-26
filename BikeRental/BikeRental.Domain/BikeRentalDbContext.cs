using Microsoft.EntityFrameworkCore;

namespace BikeRental.Domain;

/// <summary>
/// DbContext for creating a database
/// </summary>
public class BikeRentalDbContext : DbContext
{
    /// <summary>
    /// Collection of bikes
    /// </summary>
    public DbSet<Bike>? Bikes { get; set; }

    /// <summary>
    /// Collection of bike types
    /// </summary>
    public DbSet<BikeType>? BikeTypes { get; set; }

    /// <summary>
    /// Collection of clients
    /// </summary>
    public DbSet<Client>? Clients { get; set; }

    /// <summary>
    /// Collection of rent records
    /// </summary>
    public DbSet<RentRecord>? RentRecords { get; set; }

    public BikeRentalDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Inserting data into database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var type1 = new BikeType { Id = 1, TypeName = "горный", RentCost = 300 };
        var type2 = new BikeType { Id = 2, TypeName = "прогулочный", RentCost = 100 };
        var type3 = new BikeType { Id = 3, TypeName = "спортивный", RentCost = 200 };

        modelBuilder.Entity<BikeType>().HasData(new List<BikeType> { type1, type2, type3 });

        var bike1 = new Bike { Id = 1, SerialNumber = 12345, Model = "Model1", Color = "green", TypeId = 1 };
        var bike2 = new Bike { Id = 2, SerialNumber = 23451, Model = "Model2", Color = "red", TypeId = 2 };
        var bike3 = new Bike { Id = 3, SerialNumber = 34512, Model = "Model3", Color = "purple", TypeId = 3 };
        var bike4 = new Bike { Id = 4, SerialNumber = 45123, Model = "Model4", Color = "green", TypeId = 1 };
        var bike5 = new Bike { Id = 5, SerialNumber = 51234, Model = "Model5", Color = "blue", TypeId = 3 };
        var bike6 = new Bike { Id = 6, SerialNumber = 11234, Model = "Model6", Color = "purple", TypeId = 3 };

        modelBuilder.Entity<Bike>().HasData(new List<Bike> { bike1, bike2, bike3, bike4, bike5, bike6 });

        var client1 = new Client { Id = 1, FullName = "Ivan Ivanov", BirthYear = 1995, PhoneNumber = "+7(927)123-45-67" };
        var client2 = new Client { Id = 2, FullName = "Petr Petrov", BirthYear = 1992, PhoneNumber = "+7(927)123-45-68" };
        var client3 = new Client { Id = 3, FullName = "Kuznec Kuznecov", BirthYear = 1986, PhoneNumber = "+7(927)123-45-69" };
        var client4 = new Client { Id = 4, FullName = "Andrey Andreev", BirthYear = 2000, PhoneNumber = "+7(927)123-45-60" };
        var client5 = new Client { Id = 5, FullName = "Ignat Ignatiev", BirthYear = 2001, PhoneNumber = "+7(927)123-45-61" };

        modelBuilder.Entity<Client>().HasData(new List<Client> { client1, client2, client3, client4, client5 });

        var record1 = new RentRecord { Id = 1, ClientId = 1, BikeId = 1, RentStartTime = DateTime.Parse("2023-01-1 13:45"), RentEndTime = DateTime.Parse("2023-01-1 14:45") };
        var record2 = new RentRecord { Id = 2, ClientId = 2, BikeId = 2, RentStartTime = DateTime.Parse("2023-01-1 15:45"), RentEndTime = DateTime.Parse("2023-01-1 16:45") };
        var record3 = new RentRecord { Id = 3, ClientId = 3, BikeId = 3, RentStartTime = DateTime.Parse("2023-01-1 10:45"), RentEndTime = DateTime.Parse("2023-01-1 11:45") };
        var record4 = new RentRecord { Id = 4, ClientId = 4, BikeId = 4, RentStartTime = DateTime.Parse("2023-01-1 8:45"), RentEndTime = DateTime.Parse("2023-01-1 9:45") };
        var record5 = new RentRecord { Id = 5, ClientId = 5, BikeId = 2, RentStartTime = DateTime.Parse("2023-01-1 19:45"), RentEndTime = DateTime.Parse("2023-01-1 20:45") };
        var record6 = new RentRecord { Id = 6, ClientId = 1, BikeId = 1, RentStartTime = DateTime.Parse("2023-01-1 15:45"), RentEndTime = DateTime.Parse("2023-01-1 16:45") };
        var record7 = new RentRecord { Id = 7, ClientId = 1, BikeId = 6, RentStartTime = DateTime.Parse("2023-01-1 17:45"), RentEndTime = DateTime.Parse("2023-01-1 19:48") };

        modelBuilder.Entity<RentRecord>().HasData(new List<RentRecord> { record1, record2, record3, record4, record5, record6, record7 });
    }
}
