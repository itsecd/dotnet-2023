using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Model;

/// <summary>
/// Class for storing instances of database entities
/// </summary>
public class AdmissionCommitteeContext : DbContext
{
    /// <summary>
    /// Entrant data seet
    /// </summary>
    public DbSet<Entrant> Entrants { get; set; } = null!;

    /// <summary>
    /// EntrantResult data set
    /// </summary>
    public DbSet<EntrantResult> EntrantResults { get; set; } = null!;

    /// <summary>
    /// Result data set
    /// </summary>
    public DbSet<Result> Results { get; set; } = null!;

    /// <summary>
    /// Statement data set
    /// </summary>
    public DbSet<Statement> Statements { get; set; } = null!;

    /// <summary>
    /// StatementSpecialties data set
    /// </summary>
    public DbSet<StatementSpecialty> StatementSpecialties { get; set; } = null!;

    /// <summary>
    /// Specialties data set
    /// </summary>
    public DbSet<Specialty> Specialties { get; set; } = null!;

    /// <summary>
    /// link to a class with initial data
    /// </summary>
    public InitialData _initialData;

    public AdmissionCommitteeContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _initialData = new InitialData();

        modelBuilder.Entity<Entrant>().HasData(_initialData.Entrants);
        modelBuilder.Entity<EntrantResult>().HasData(_initialData.EntrantResults);
        modelBuilder.Entity<Result>().HasData(_initialData.Results);

        modelBuilder.Entity<Statement>().HasData(_initialData.Statements);
        modelBuilder.Entity<StatementSpecialty>().HasData(_initialData.StatementSpecialties);
        modelBuilder.Entity<Specialty>().HasData(_initialData.Specialties);

        //install links
        modelBuilder.Entity<Entrant>()
            .HasOne(entrant => entrant.Statement)
            .WithOne(statement => statement.Entrant)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Entrant>()
            .HasMany(entrant => entrant.EntrantResults)
            .WithOne(etrantResult => etrantResult.Entrant)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EntrantResult>()
            .HasOne(entrantResult => entrantResult.Result)
            .WithMany(result => result.EntrantResults)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Statement>()
            .HasMany(statement => statement.StatementSpecialties)
            .WithOne(statementSpeciality => statementSpeciality.Statement)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StatementSpecialty>()
            .HasOne(statementSpeciality => statementSpeciality.Specialty)
            .WithMany(specialty => specialty.StatementSpecialties)
            .OnDelete(DeleteBehavior.Cascade);

        //install PrimaryKey
        modelBuilder.Entity<Entrant>().HasKey(entrant => entrant.IdEntrant);
        modelBuilder.Entity<EntrantResult>().HasKey(entrantResult => entrantResult.IdEntrantResult);
        modelBuilder.Entity<Result>().HasKey(result => result.IdResult);
        modelBuilder.Entity<Statement>().HasKey(statement => statement.IdStatement);
        modelBuilder.Entity<StatementSpecialty>().HasKey(statementSpeciality => statementSpeciality.IdStatementSpecialty);
        modelBuilder.Entity<Specialty>().HasKey(speciality => speciality.IdSpecialty);
    }
}