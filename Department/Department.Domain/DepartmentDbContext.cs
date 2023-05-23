using Microsoft.EntityFrameworkCore;

namespace Department.Domain;
public class DepartmentDbContext : DbContext
{
    /// <summary>
    /// Collection of groups
    /// </summary>
    public DbSet<Group>? Groups { get; set; }

    /// <summary>
    /// Collection of teachers
    /// </summary>
    public DbSet<Teacher>? Teachers { get; set; }

    /// <summary>
    /// Collection of subjects
    /// </summary>
    public DbSet<Subject>? Subjects { get; set; }

    /// <summary>
    /// Collection of courses
    /// </summary>
    public DbSet<Course>? Courses { get; set; }

    public DepartmentDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
