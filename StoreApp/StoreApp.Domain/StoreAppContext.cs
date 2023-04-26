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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer(1, "Michelle Padilla", 111111),
            new Customer(2, "Manuel Gomez", 222222),
            new Customer(3, "Raymond Oliver", 333333),
            new Customer(4, "Enrique Morgan", 444444),
            new Customer(5, "Walter Mullins", 555555));

        modelBuilder.Entity<Product>().HasData(
            new Product(1, 1, "Milk", 0.940, false, 89.0, "23.02.2023"),
            new Product(2, 1, "Butter", 0.940, false, 159.0, "21.05.2023"),
            new Product(3, 2, "Pasta", 0.400, true, 109.0, "10.01.2023"),
            new Product(4, 3, "Eggs", 0.600, false, 96.0, "09.05.2023"),
            new Product(5, 3, "Bread", 0.440, false, 36.0, "23.02.2023"));

        modelBuilder.Entity<ProductSale>().HasData(
            new ProductSale(1, 1, 1, 1),
            new ProductSale(2, 2, 1, 1),
            new ProductSale(3, 3, 1, 1),
            new ProductSale(4, 4, 2, 1),
            new ProductSale(5, 5, 2, 1),
            new ProductSale(6, 1, 2, 1),
            new ProductSale(7, 2, 3, 1),
            new ProductSale(8, 3, 3, 1),
            new ProductSale(9, 4, 3, 1),
            new ProductSale(10, 5, 4, 1),
            new ProductSale(11, 1, 4, 1),
            new ProductSale(12, 2, 4, 1),
            new ProductSale(13, 3, 5, 1),
            new ProductSale(14, 4, 5, 1),
            new ProductSale(15, 5, 5, 1),
            new ProductSale(16, 2, 6, 1),
            new ProductSale(17, 3, 6, 1),
            new ProductSale(18, 4, 6, 1),
            new ProductSale(19, 5, 7, 1),
            new ProductSale(20, 1, 7, 1),
            new ProductSale(21, 4, 7, 1));

        modelBuilder.Entity<ProductStore>().HasData(
            new ProductStore(1, 1, 2, 10),
            new ProductStore(2, 2, 2, 2),
            new ProductStore(3, 3, 2, 5),
            new ProductStore(4, 3, 3, 15),
            new ProductStore(5, 4, 2, 0),
            new ProductStore(6, 4, 3, 20));

        modelBuilder.Entity<Sale>().HasData(
            new Sale(1, "03.03.2023", 2, 1, 357.0),
            new Sale(2, "03.01.2023", 1, 2, 221.0),
            new Sale(3, "15.02.2023", 2, 1, 364.0),
            new Sale(4, "18.02.2023", 3, 3, 284.0),
            new Sale(5, "16.02.2023", 4, 4, 241.0),
            new Sale(6, "28.02.2023", 5, 2, 364.0),
            new Sale(7, "01.03.2023", 5, 1, 284.0));

        modelBuilder.Entity<Store>().HasData(
            new Store(1, "Walmart", "Polevaya 123"),
            new Store(2, "Pyaterochka", "Pushkina 1837"),
            new Store(3, "Shestorochka", "Kolotushkina 0"),
            new Store(4, "Magnit", "Moskovskoye shosse 666"),
            new Store(5, "Perekrestok", "Revolyutsionnaya 1917"));

    }
}
