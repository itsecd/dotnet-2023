using Microsoft.EntityFrameworkCore;
namespace TransportManagment.Classes;
/// <summary>
/// Class for mapping database on local classes
/// </summary>
public class TransportManagmentDbContext : DbContext
{
    /// <summary>
    /// Mapping on the Driver
    /// </summary>
    public DbSet<Driver>? Drivers { get; set; }
    /// <summary>
    /// Mapping on the Route
    /// </summary>
    public DbSet<Route>? Routes { get; set; }
    /// <summary>
    /// Mapping on the Transport
    /// </summary>
    public DbSet<Transport>? Transports { get; set; }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options"></param>
    public TransportManagmentDbContext(DbContextOptions options) : base(options) 
    {
        Database.EnsureCreated();
    }
    /// <summary>
    /// Methods started with database, default data
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Route>().HasOne(i => i.Driver).WithMany(b => b.Routes).HasForeignKey(e => e.DriverId).IsRequired();
        modelBuilder.Entity<Route>().HasOne(i => i.Driver).WithMany(b => b.Routes).HasForeignKey(e => e.TransportId).IsRequired();
        modelBuilder.Entity<Driver>().HasMany(b => b.Routes).WithOne(i => i.Driver).HasForeignKey(e => e.DriverId).HasPrincipalKey(c => c.DriverId);
        modelBuilder.Entity<Transport>().HasMany(b => b.Routes).WithOne(i => i.Transport).HasForeignKey(e => e.TransportId).HasPrincipalKey(c => c.TransportId); ;
        var transports = new List<Transport>
        {
            new Transport{ TransportId = 1, Type = "bus", Model = "Mercedes", DateMake = new DateTime(1990, 10, 23) },
            new Transport{ TransportId = 2, Type = "bus", Model = "Audi", DateMake = new DateTime(1992, 04, 18) },
            new Transport{ TransportId = 3, Type = "trolleybus", Model = "VAZ", DateMake = new DateTime(1985, 10, 23) },
            new Transport{ TransportId = 4, Type = "trolleybus", Model = "VAZ", DateMake = new DateTime(2010, 11, 01) },
            new Transport{ TransportId = 5, Type = "tram", Model = "Samtram", DateMake = new DateTime(1990, 10, 13) },
            new Transport{ TransportId = 6, Type = "tram", Model = "Mostram", DateMake = new DateTime(1989, 08, 02) },
        };
        var drivers = new List<Driver>
        {
             new Driver { DriverId = 11, FirstName = "Igor", LastName = "Gudzenko", Patronymic = "Nicolaevich",  Passport = 290865, DriverCard = 2434, Number = 2568090},
             new Driver { DriverId = 12, FirstName = "Oleg", LastName = "Fursov", Patronymic = "Igorevich", Passport = 292365, DriverCard = 2211, Number = 2578090},
             new Driver { DriverId = 13, FirstName = "Evpatiy", LastName = "Kage", Patronymic = "Niconorovich", Passport = 129561, DriverCard = 3081, Number = 2568430},
             new Driver { DriverId = 14, FirstName = "Egor", LastName = "Abramov", Patronymic = "Danilovich", Passport = 280123, DriverCard = 2411, Number = 2568123 },
             new Driver { DriverId = 15, FirstName = "Adry", LastName = "Tarasov", Patronymic = "Sergeivich", Passport = 199321, DriverCard = 2784, Number = 2522290 },
             new Driver { DriverId = 16, FirstName = "Bill", LastName = "Pechorin", Patronymic = "Andeivich", Passport = 300965, DriverCard = 1234, Number = 3668090 },
        };
        var routes = new List<Classes.Route>
        { 
            new Classes.Route{ RouteId = 100, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("08:00:00"), TimeFrom = TimeSpan.Parse("17:30:00"), TransportId = 1, DriverId = 11},//, transports[0], drivers[0]
            new Classes.Route{ RouteId = 111, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("09:00:00"), TimeFrom = TimeSpan.Parse("16:00:00"), TransportId = 2, DriverId = 12},//, transports[1], drivers[1]
            new Classes.Route{ RouteId = 112, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("16:30:00"), TimeFrom = TimeSpan.Parse("22:30:00"), TransportId = 2, DriverId = 13},//, transports[1], drivers[2]
            new Classes.Route{ RouteId = 123, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("07:30:00"), TimeFrom = TimeSpan.Parse("14:30:00"), TransportId = 3, DriverId = 14},//, transports[2], drivers[3]
            new Classes.Route{ RouteId = 133, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("15:00:00"), TimeFrom = TimeSpan.Parse("23:00:00"), TransportId = 4, DriverId = 14},//, transports[3], drivers[3]
            new Classes.Route{ RouteId = 144, Date = new DateTime(2022, 02, 11), TimeTo = TimeSpan.Parse("06:00:00"), TimeFrom = TimeSpan.Parse("18:00:00"), TransportId = 5, DriverId = 15},//, transports[4], drivers[4]
            new Classes.Route{ RouteId = 155, Date = new DateTime(2022, 02, 12), TimeTo = TimeSpan.Parse("06:30:00"), TimeFrom = TimeSpan.Parse("18:00:00"), TransportId = 6, DriverId = 16},//, transports[5], drivers[5]
        };
        modelBuilder.Entity<Driver>().HasData(drivers);
        modelBuilder.Entity<Transport>().HasData(transports);
        modelBuilder.Entity<Route>().HasData(routes);
    }
}