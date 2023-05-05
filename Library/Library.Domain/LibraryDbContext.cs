using Microsoft.EntityFrameworkCore;

namespace Library.Domain;
/// <summary>
/// 
/// </summary>
public class LibraryDbContext : DbContext
{
    public DbSet<Book>? Books { get; set; }

    public DbSet<Card>? Cards { get; set; }

    public DbSet<Department>? Departments { get; set; }

    public DbSet<Reader>? Readers { get; set; }

    public DbSet<TypeDepartment>? TypesDepartment { get; set; }

    public DbSet<TypeEdition>? TypesEdition { get; set; }

    public LibraryDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
