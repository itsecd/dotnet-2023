using Microsoft.EntityFrameworkCore;

namespace Airlines.Domain;
/// <summary>
/// Class represented a DbContext of Airlines
/// </summary>
public sealed class AirlinesContext : DbContext
{
    public DbSet<Airplane> Airplanes { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Passenger> Passengers { get; set; } = null!;
    public AirlinesContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>().HasData(new Airplane
        {
            Id = 1,
            Model = "Boing777",
            CarryingCapacity = 1,
            Capability = 1,
            SeatingCapacity = 10
        });

        modelBuilder.Entity<Airplane>().HasData(new Airplane
        {
            Id = 2,
            Model = "Boing767",
            CarryingCapacity = 2,
            Capability = 2,
            SeatingCapacity = 20
        });

        modelBuilder.Entity<Airplane>().HasData(new Airplane
        {
            Id = 3,
            Model = "Boing737",
            CarryingCapacity = 3,
            Capability = 3,
            SeatingCapacity = 30
        });

        var names = new List<string> { "Kirill Petrov", "Vladimir Ivanov", "Anna Dmitrieva", "Stepan Dumov", "Oleg Fillipov" };

        for (var i = 0; i < 5; i++)
        {
            modelBuilder.Entity<Passenger>().HasData(new Passenger
            {
                Id = i + 1,
                PassportNumber = (i * 10 + i).ToString() + i.GetHashCode().ToString(),
                Name = names[i]
            }); ;
        }

        modelBuilder.Entity<Flight>().HasData(new Flight
        {
            Id = 1,
            AirplaneId = 1,
            FlightCode = "1",
            Source = "Moscow",
            Destination = "Kazan",
            DepartureDate = new DateTime(2023, 02, 11),
            ArrivalDate = new DateTime(2023, 02, 11),
            FlightDuration = 1,
            AirplaneType = "Cargo"
        });

        modelBuilder.Entity<Flight>().HasData(new Flight
        {
            Id = 2,
            AirplaneId = 2,
            FlightCode = "2",
            Source = "Samara",
            Destination = "Saint-Petersburg",
            DepartureDate = new DateTime(2023, 02, 23),
            ArrivalDate = new DateTime(2023, 02, 23),
            FlightDuration = 1.5,
            AirplaneType = "Cargo"
        });

        modelBuilder.Entity<Flight>().HasData(new Flight
        {
            Id = 3,
            AirplaneId = 3,
            FlightCode = "3",
            Source = "Ufa",
            Destination = "Samara",
            DepartureDate = new DateTime(2023, 04, 01),
            ArrivalDate = new DateTime(2023, 04, 01),
            FlightDuration = 1.2,
            AirplaneType = "Passenger"
        });

        for (var i = 1; i < 6; i++)
        {
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                Id = i,
                PassengerId = i,
                FlightId = (i - 1) % 3 + 1,
                TicketNumber = i,
                SeatNumber = "1A",
                BaggageWeight = i - 1
            });
        }
    }
}