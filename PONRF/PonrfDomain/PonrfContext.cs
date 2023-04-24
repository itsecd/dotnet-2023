using Microsoft.EntityFrameworkCore;

namespace PonrfDomain;
/// <summary>
/// PonrfContex used to work with database
/// </summary>
public class PonrfContext : DbContext
{
    /// <summary>
    /// Collection of auctions
    /// </summary>
    public DbSet<Auction> Auctions { get; set; } = null!;

    /// <summary>
    /// Collection of buildings
    /// </summary>
    public DbSet<Building> Buildings { get; set; } = null!;

    /// <summary>
    /// Collection of customers
    /// </summary>
    public DbSet<Customer> Customers { get; set; } = null!;

    /// <summary>
    /// Collection of privatized buildings
    /// </summary>
    public DbSet<PrivatizedBuilding> PrivatizedBuildings { get; set; } = null!;

    /// <summary>
    /// Constructor for PonrfContext
    /// </summary>
    /// <param name="options"></param>
    public PonrfContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
