using Microsoft.EntityFrameworkCore;

namespace Polyclinic.Domain;
public class PolyclinicDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Completion> Completions { get; set; }

    public DbSet<Registration> Registrations { get; set; }

    public DbSet<Specializations> Specializations { get; set; }

    public PolyclinicDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
