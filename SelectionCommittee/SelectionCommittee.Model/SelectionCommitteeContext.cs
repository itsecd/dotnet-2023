using Microsoft.EntityFrameworkCore;

namespace SelectionCommittee.Model;

/// <summary>
/// База данных для сущностей социальной сети.
/// </summary>
public class SelectionCommitteeContext : DbContext
{
    /// <summary>
    /// Список абитуриентов.
    /// </summary>
    public DbSet<EnrolleeDbModel> Enrollees { get; set; }

    /// <summary>
    /// Список результатов экзамена.
    /// </summary>
    public DbSet<ExamResultDbModel> ExamResults { get; set; }

    /// <summary>
    /// Список факультетов.
    /// </summary>
    public DbSet<FacultyDbModel> Faculties { get; set; }

    /// <summary>
    /// Список специальностей.
    /// </summary>
    public DbSet<SpecializationDbModel> Specializations { get; set; }

    public SelectionCommitteeContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Заполняет таблицы данных.
    /// </summary>
    /// <param name="modelBuilder">Построитель моделей.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacultyDbModel>().HasData(new FacultyDbModel
        {
            Id = 1,
            Name = "Название1"
        });

        modelBuilder.Entity<SpecializationDbModel>().HasData(new SpecializationDbModel
        {
            Id = 1,
            Priority = 1,
            Name = "ИБАС",
            FacultyId = 1
        });

        for (var i = 1; i < 10; i++)
        {
            modelBuilder.Entity<EnrolleeDbModel>().HasData(new EnrolleeDbModel
            {
                Id = i,
                FirstName = $"FirstName {i}",
                LastName = $"LastName {i}",
                Patronymic = $"Patronymic {i}",
                Age = 18,
                BirthDate = DateTime.Now,
                Country = "Russia",
                City = "Samara",
                SpecializationId = 1
            });
        }

        modelBuilder.Entity<ExamResultDbModel>().HasData(new ExamResultDbModel
        {
            Id = 1,
            SubjectName = "Математика",
            Points = 96,
            EnrolleeId = 1,
        });
    }
}