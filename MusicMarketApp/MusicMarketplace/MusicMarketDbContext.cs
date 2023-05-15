using Microsoft.EntityFrameworkCore;
using MusicMarket;

namespace MusicMarketplace;
public class MusicMarketDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Seller> Sellers { get; set; } = null!;

    public DbSet<Purchase> Purchases { get; set; } = null!;

    public MusicMarketDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "The Curse of the Seas", TypeOfCarrier = "cassette", PublicationType = "album", Creator = "Aria", MadeIn = "Russia", MediaStatus = "bad", PackagingCondition = "satisfactory", Price = 1750, Status = "sale", IdSeller = 0 },
            new Product { Id = 2, Name = "Decorative and applied art", TypeOfCarrier = "disc", PublicationType = "album", Creator = "Monetochka", MadeIn = "Russia", MediaStatus = "new", PackagingCondition = "new", Price = 4890, Status = "sale", IdSeller = 0 },
            new Product { Id = 3, Name = "Aurora", TypeOfCarrier = "vinyl record", PublicationType = "album", Creator = "Leningrad", MadeIn = "Russia", MediaStatus = "excellent", PackagingCondition = "good", Price = 3750, Status = "sold", IdSeller = 0 },
            new Product { Id = 4, Name = "Forgive Me My Love", TypeOfCarrier = "disc", PublicationType = "single", Creator = "Zemfira", MadeIn = "Russia", MediaStatus = "satisfactory", PackagingCondition = "bad", Price = 1190, Status = "sold", IdSeller = 0 },
            new Product { Id = 5, Name = "Smoke + Mirrors", TypeOfCarrier = "cassette", PublicationType = "album", Creator = "Imagine Dragons", MadeIn = "USA", MediaStatus = "excellent", PackagingCondition = "excellent", Price = 6490, Status = "sold", IdSeller = 1 },
            new Product { Id = 6, Name = "Let Go", TypeOfCarrier = "vinyl record", PublicationType = "single", Creator = "Avril Lavigne", MadeIn = "UK & Europe", MediaStatus = "good", PackagingCondition = "excellent", Price = 5990, Status = "sold", IdSeller = 2 },
            new Product { Id = 7, Name = "PWR/UP", TypeOfCarrier = "cassette", PublicationType = "album", Creator = "AC/DC", MadeIn = "EU", MediaStatus = "excellent", PackagingCondition = "good", Price = 3990, Status = "sold", IdSeller = 2 },
            new Product { Id = 8, Name = "Rush!", TypeOfCarrier = "disc", PublicationType = "album", Creator = "Maneskin", MadeIn = "UK & Europe", MediaStatus = "new", PackagingCondition = "new", Price = 4990, Status = "sold", IdSeller = 2 }
        };
        modelBuilder.Entity<Product>().HasData(products);

        modelBuilder.Entity<Seller>().HasData(new List<Seller>
        {
            new Seller { Id = 1, ShopName = "Muzzona", CountryOfDelivery = "Russia", Price = 300},
            new Seller { Id = 2, ShopName = "Skifmusic", CountryOfDelivery = "UK", Price = 750},
            new Seller { Id = 3, ShopName = "StopRobot", CountryOfDelivery = "USA", Price = 680}

        });

        modelBuilder.Entity<Purchase>().HasData(new List<Purchase>
        {
            new Purchase { Id = 1, IdProduct = 8,IdCustomer = 1, Date = DateTime.Parse("2023/05/11")},
            new Purchase { Id = 2, IdProduct = 4,IdCustomer= 2, Date = DateTime.Parse("2023/05/4") },
            new Purchase { Id = 3, IdProduct = 5,IdCustomer = 3, Date = DateTime.Parse("2023/05/7") },
            new Purchase { Id = 4, IdProduct = 6,IdCustomer = 4, Date = DateTime.Parse("2023/05/8") },
            new Purchase { Id = 5, IdProduct = 7,IdCustomer = 5, Date = DateTime.Parse("2023/05/14") }
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer ( 1, "Tikhonov Mark Sergeevich", "Switzerland", "Aubonnestr. 18c 2672 Sembrancher"),
            new Customer ( 2, "Klimova Sofya Dmitrievna", "Russia", "522625, Kaliningrad region, the city of Pavlovsky Posad, Domodedovo str., 94"),
            new Customer ( 3, "Jason Knight", "USA", "9297 Graham Spur Apt. 585 Gaylordbury, LA 91851"),
            new Customer ( 4, "David Bush", "France", "8, avenue de Coste 24798 Costa"),
            new Customer ( 5, "Vasiliev Yaroslav Olegovich", "Russia", "179817, Ulyanovsk region, Krasnogorsk, Lenin Square, 23")
        });


    }
}

