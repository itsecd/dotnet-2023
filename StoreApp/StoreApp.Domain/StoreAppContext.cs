using Microsoft.EntityFrameworkCore;

namespace StoreApp.Domain;
public class StoreAppContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductStore> ProductStores { get; set; } = null!;
    public DbSet<ProductSale> ProductSales { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public StoreAppContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
