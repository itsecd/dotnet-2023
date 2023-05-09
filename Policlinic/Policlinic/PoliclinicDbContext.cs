using Microsoft.EntityFrameworkCore;

namespace Policlinic;
/// <summary>
/// DbContext for Policlinic
/// </summary>
public class PoliclinicDbContext : DbContext
{
    /// <summary>
    /// Store specializations
    /// </summary>
    public DbSet<Specialization>? Specializations { get; set; }
    /// <summary>
    /// Store doctors
    /// </summary>
    public DbSet<Doctor>? Doctors { get; set; }
    /// <summary>
    /// Store patients
    /// </summary>
    public DbSet<Patient>? Patients { get; set; }
    /// <summary>
    /// Store receptions
    /// </summary>
    public DbSet<Reception>? Receptions { get; set; }
    /// <summary>
    /// Create the database
    /// </summary>
    /// <param name="options"></param>
    public PoliclinicDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    /// <summary>
    /// Data for database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var specialization1 = new Specialization { Id = 1, NameSpecialization = "Psychotherapist" };
        var specialization2 = new Specialization { Id = 2, NameSpecialization = "Dermatologist" };

        modelBuilder.Entity<Specialization>().HasData(new List<Specialization> { specialization1, specialization2 });

        modelBuilder.Entity<Reception>().HasData(new List<Reception> {
            new Reception { Id = 1, DateAndTime = new DateTime(2023, 2, 1, 12, 0, 0), Status = "On treatment", DoctorId = 1, PatientId = 1, Conclusion = "Nervousness" },
            new Reception { Id = 2, DateAndTime = new DateTime(2023, 2, 1, 12, 15, 0), Status = "Healthy", DoctorId = 1, PatientId = 2, Conclusion = "" },
            new Reception { Id = 3, DateAndTime = new DateTime(2023, 2, 2, 11, 0, 0), Status = "Healthy", DoctorId = 2, PatientId = 3, Conclusion = "" },
            new Reception { Id = 4, DateAndTime = new DateTime(2023, 2, 3, 13, 45, 0), Status = "On treatment", DoctorId = 3, PatientId = 4, Conclusion = "Psoriasis" },
            new Reception { Id = 5, DateAndTime = new DateTime(2023, 2, 1, 12, 30, 0), Status = "Healthy", DoctorId = 2, PatientId = 2, Conclusion = "" }
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor> {
            new Doctor { Id = 1, Fio = "Ivanov Ivan Ivanovich", BirthDate = new DateTime(1975, 12, 1), WorkExperience = 7, Passport = 1234567890, SpecializationId = 1 },
            new Doctor { Id = 2, Fio = "Petrov Peter Petrovich", BirthDate = new DateTime(1960, 10, 10), WorkExperience = 15, Passport = 4321567890, SpecializationId = 2 },
            new Doctor { Id = 3, Fio = "Smirnov Alexander Alexandrovich", BirthDate = new DateTime(1980, 1, 1), WorkExperience = 3, Passport = 2341567890, SpecializationId = 1}
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient> {
            new Patient { Id = 1, Passport = 4231123456, Fio = "Ivanov Pyotr Vladimirovich", BirthDate = new DateTime(2000, 2, 2), Address = "Moskovskoe highway 34b" },
            new Patient { Id = 2, Passport = 1234123456, Fio = "Belov Evgeny Maksimovich", BirthDate = new DateTime(1990, 7, 6), Address = "231 Kirov Street" },
            new Patient { Id = 3, Passport = 1423123456, Fio = "Kirov Lukas Markovich", BirthDate = new DateTime(1993, 8, 8), Address = "Michurina Street 15" },
            new Patient { Id = 4, Passport = 4321123456, Fio = "Krylov Vladimir Petrovich", BirthDate = new DateTime(1985, 1, 1), Address = "17 Banykin Street"}
        });
    }
}
