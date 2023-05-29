using Microsoft.EntityFrameworkCore;

namespace Realtor;
public class RealtorDbContext : DbContext
{
    public DbSet<House>? Houses { get; set; }
    public DbSet<Application>? Applications { get; set; }   
    public DbSet<Client>? Clients { get; set; }
    public RealtorDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

}
