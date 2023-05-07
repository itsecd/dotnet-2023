using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace UniversityData.Domain;
public class UniversityDataDbContext : DbContext
{
    public UniversityDataDbContext(DbContextOptions options)
    {
        Database.EnsureCreated();
    }
    /// <summary>
    /// Коллекция объектов класса ConstructionProperty
    /// </summary>
    public DbSet<ConstructionProperty> ConstructionProperties { get; set; }
    /// <summary>
    /// Коллекция объектов класса Departments
    /// </summary>
    public DbSet<Department> Departments { get; set; }
    /// <summary>
    /// Коллекция объектов класса Faculty
    /// </summary>
    public DbSet<Faculty> Faculties { get; set; }
    /// <summary>
    /// Коллекция объектов класса Rector
    /// </summary>
    public DbSet<Rector> Rectors { get; set; }
    /// <summary>
    /// Коллекция объектов класса Specialty
    /// </summary>
    public DbSet<Specialty> Specialties { get; set; }
    /// <summary>
    /// Коллекция объектов класса SpecialtyTableNode
    /// </summary>
    public DbSet<SpecialtyTableNode> SpecialtyTableNodes { get; set; }
    /// <summary>
    /// Коллекция объектов класса University
    /// </summary>
    public DbSet<University> Universities { get; set; }
    /// <summary>
    /// Коллекция объектов класса UniversityProperty
    /// </summary>
    public DbSet<UniversityProperty> UniversityProperties { get; set; }
}
