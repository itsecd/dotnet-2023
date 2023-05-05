using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Domain;

public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
{
    public LibraryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=student;Database=library_db;Pwd=P@ssw0rd");

        return new LibraryDbContext(optionsBuilder.Options);
    }
}
