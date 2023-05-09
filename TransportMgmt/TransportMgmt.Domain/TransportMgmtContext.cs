using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace TransportMgmt.Domain;

public class TransportMgmtContext : DbContext
{
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Model> Models { get; set; } = null!;
    public DbSet<Routes> Routes { get; set; } = null!;
    public DbSet<Transport> Transports { get; set; } = null!;
    public DbSet<TransportType> TransportTypes { get; set; } = null!;
    public DbSet<Trip> Trips { get; set; } = null!;

    public TransportMgmtContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var transportTypes = new List<TransportType>
        {
            new TransportType { Id = 1, TypeName = "автобус" },
            new TransportType { Id = 2, TypeName = "троллейбус" },
            new TransportType { Id = 3, TypeName = "трамвай" }
        };
           modelBuilder.Entity<TransportType>().HasData(transportTypes);

        var models = new List<Model>
            {
                new Model {Id = 1, ModelName = "ГАЗель NN", FloorLevel = "Low", MaxCapacity = 20},
                new Model {Id = 2, ModelName = "MAN Lion's City", FloorLevel = "High", MaxCapacity = 35},
                new Model {Id = 3, ModelName = "ЗИЛ", FloorLevel = "Low", MaxCapacity = 15},
                new Model {Id = 4, ModelName = "ЛиАЗ-4292", FloorLevel = "High", MaxCapacity = 25},
                new Model {Id = 5, ModelName = "Ситирим-10", FloorLevel = "High", MaxCapacity = 40},
                new Model {Id = 6, ModelName = "МАЗ-232", FloorLevel = "Low", MaxCapacity = 20},
                new Model {Id = 7, ModelName = "Mercedes-Benz Sprinter", FloorLevel = "Low", MaxCapacity = 20},
            };
        modelBuilder.Entity<Model>().HasData(models);

        var routes = new List<Routes>
            {
                new Routes { Id = 1, RouteNumber = "1"},
                new Routes { Id = 2, RouteNumber = "2"},
                new Routes { Id = 3, RouteNumber = "3"},
                new Routes { Id = 4, RouteNumber = "4"},
                new Routes { Id = 5, RouteNumber = "5Д"},
                new Routes { Id = 6, RouteNumber = "67"},
                new Routes { Id = 7, RouteNumber = "126с"},
                new Routes { Id = 8, RouteNumber = "126ю"},
                new Routes { Id = 9, RouteNumber = "20"},
                new Routes { Id = 10, RouteNumber = "22"},
                new Routes { Id = 11, RouteNumber = "5"},
                new Routes { Id = 12, RouteNumber = "13"}
            };
        modelBuilder.Entity<Routes>().HasData(routes);

        var drivers = new List<Driver>
            {
                new Driver (1, "Степан", "Водянов", "Денисович", 270972, 1112, "22 Армии 412", "88005553535"),
                new Driver (2, "Степан", "Арапенков", "Владимирович", 270973, 1113, "22 Армии 413", "88005553536"),
                new Driver (3, "Семён", "Денисов", "Владимирович", 270976, 1116, "22 Армии 416", "88005553539"),
                new Driver (4, "Михаил", "Борисычев", "Владиславович", 270974, 1114, "22 Армии 414", "88005553537"),
                new Driver (5, "Владимир", "Гусев", "Андреевич", 270975, 1115, "22 Армии 415", "88005553538"),
                new Driver (6, "Степан", "Денисов", "Владимирович", 270977, 1117, "22 Армии 417", "88005553540"),
            };
        modelBuilder.Entity<Driver>().HasData(drivers);

        var transports = new List<Transport>
            {
                new Transport(1, "A001AA163", transportTypes[0].Id, models[0].Id, new DateTime(1990, 10, 23)),
                new Transport(3, "A003AA163", transportTypes[1].Id, models[1].Id, new DateTime(1985, 10, 15)),
                new Transport(2, "A002AA163", transportTypes[2].Id, models[2].Id, new DateTime(1992, 04, 18)),
                new Transport(4, "A004AA163", transportTypes[0].Id, models[3].Id, new DateTime(2010, 11, 13)),
                new Transport(5, "A005AA163", transportTypes[1].Id, models[4].Id, new DateTime(2015, 12, 09)),
                new Transport(6, "A006AA163", transportTypes[2].Id, models[5].Id, new DateTime(2007, 08, 12)),
                new Transport(7, "A007AA163", transportTypes[1].Id, models[6].Id, new DateTime(2009, 06, 07))
            };                                
        modelBuilder.Entity<Transport>().HasData(transports);

        var trips = new List<Trip>
            {
                new Trip(1, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[0].Id, transports[0].Id, 1),
                new Trip(2, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[1].Id, transports[1].Id, 2),
                new Trip(3, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[2].Id, transports[2].Id, 3),
                new Trip(4, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[3].Id, transports[3].Id, 4),
                new Trip(5, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[4].Id, transports[4].Id, 5),
                new Trip(6, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[5].Id, transports[5].Id, 3),
                new Trip(7, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 19, 30, 00), routes[5].Id, transports[0].Id, 1),
                new Trip(8, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 19, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), routes[3].Id, transports[2].Id, 1),
                new Trip(9, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 17, 30, 00), new DateTime(2023, 03, 19, 21, 00, 00), routes[4].Id, transports[1].Id, 4),
                new Trip(10, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 08, 00, 00), new DateTime(2023, 03, 19, 17, 30, 00), routes[2].Id, transports[6].Id, 3),
                new Trip(11, new DateTime(2023, 03, 19), new DateTime(2023, 03, 19, 21, 00, 00), new DateTime(2023, 03, 19, 21, 30, 00), routes[0].Id, transports[5].Id, 1)
        };
        modelBuilder.Entity<Trip>().HasData(trips);
    }
}
