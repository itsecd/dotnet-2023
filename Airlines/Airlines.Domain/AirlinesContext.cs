using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Domain;
public sealed class AirlinesContext: DbContext
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
