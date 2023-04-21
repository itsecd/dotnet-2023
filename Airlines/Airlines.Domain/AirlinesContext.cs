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

}
