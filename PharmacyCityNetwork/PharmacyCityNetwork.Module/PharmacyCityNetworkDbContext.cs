using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace PharmacyCityNetwork;
public class PharmacyCityNetworkDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Pharmacy>? Pharmacys { get; set; }
    public DbSet<ProductPharmacy>? ProductPharmacys { get; set; }
    public DbSet<Group>? Groups { get; set; }
    public DbSet<Manufacturer>? Manufacturers { get; set; }
    public DbSet<PharmaGroup>? PharmaGroups { get; set; }
    public DbSet<ProductPharmaGroup>? ProductPharmaGroups { get; set; }
    public DbSet<Sale>? Sales { get; set; }
    public PharmacyCityNetworkDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var firstGroup = new Group { GroupName = "Syrup", Id = 1 };
        var secondGroup = new Group { GroupName = "Pill", Id = 2 };
        var thridGroup = new Group { GroupName = "Injection", Id = 3 };

        var firstManufacturer = new Manufacturer { ManufacturerName = "Novartis", Id = 1 };
        var secondManufacturer = new Manufacturer { ManufacturerName = "Merck", Id = 2 };

        var firstPharmaGroup = new PharmaGroup { PharmaGroupName = "Adrenolytic", Id = 1 };
        var secondPharmaGroup = new PharmaGroup { PharmaGroupName = "Hematotropic", Id = 2 };
        var thridPharmaGroup = new PharmaGroup { PharmaGroupName = "Homeopathic", Id = 3 };
        var fourthPharmaGroup = new PharmaGroup { PharmaGroupName = "Interviewers", Id = 4 };


        var firstPharmacy = new Pharmacy { Id = 1, PharmacyName = "Vita", PharmacyPhone = "8899606", PharmacyAddress = "Pushkina, 7", PharmacyDirector = "Yablokov" };
        var secondPharmacy = new Pharmacy { Id = 2, PharmacyName = "Plus", PharmacyPhone = "8844606", PharmacyAddress = "Turgeneva, 8", PharmacyDirector = "Pomelov" };
        var thridPharmacy = new Pharmacy { Id = 3, PharmacyName = "Alia", PharmacyPhone = "4499606", PharmacyAddress = "Tolstogo, 8", PharmacyDirector = "Slivin" };
        //var fourthPharmacy = new Pharmacy(4, "Apteka63", "4558602", "Polevay, 23", "Chikarev");
        var fifthPharmacy = new Pharmacy { Id = 5, PharmacyName = "Tabls", PharmacyPhone = "9229303", PharmacyAddress = "Gagarina, 67", PharmacyDirector = "Parshin" };

        var firstProduct = new Product { ProductName = "Paracetamol", Id = 1, GroupId = 1, ManufacturerId = 1 };
        var firstProductPharmacy = new ProductPharmacy { ProductCount = 1, ProductCost = 300, ProductId = 1, PharmacyId = 1, Id = 1 };

        var firstProductPharmaGroup = new ProductPharmaGroup { Id = 1, PharmaGroupId = 1, ProductId = 1 };

        var firstSale = new Sale { PaymentChoice = "Online", PaymentDate = new DateTime(2023, 1, 28), ProductId = 1, Id = 1 };

        var secondProduct = new Product { ProductName = "Espumizan", Id = 2, GroupId = 2, ManufacturerId = 2 };
        var secondProductPharmacy = new ProductPharmacy { ProductCount = 2, ProductCost = 250, ProductId = 2, PharmacyId = 1, Id = 2 };

        var secondProductPharmaGroup = new ProductPharmaGroup { Id = 2, PharmaGroupId = 2, ProductId = 2 };

        var secondSale = new Sale { PaymentChoice = "Cash", PaymentDate = new DateTime(2023, 4, 14), ProductId = 2, Id = 2 };

        var thridProduct = new Product { ProductName = "Noshpa", Id = 3, GroupId = 3, ManufacturerId = 2 };
        var thridProductPharmacy = new ProductPharmacy { ProductCount = 3, ProductCost = 200, ProductId = 3, PharmacyId = 3, Id = 3 };

        var sixthProductPharmacy = new ProductPharmacy { ProductCount = 4, ProductCost = 180, ProductId = 4, PharmacyId = 2, Id = 4 };

        var thridProductPharmaGroup = new ProductPharmaGroup { Id = 3, PharmaGroupId = 3, ProductId = 3 };

        var thridSale = new Sale { PaymentChoice = "Online", PaymentDate = new DateTime(2023, 3, 20), ProductId = 3, Id = 3 };

        var sixthSale = new Sale { PaymentChoice = "Online", PaymentDate = new DateTime(2023, 3, 20), ProductId = 3, Id = 6 };

        var fourthProduct = new Product { ProductName = "Analgin", Id = 4, GroupId = 3, ManufacturerId = 1 };
        var fourthProductPharmacy = new ProductPharmacy { ProductCount = 4, ProductCost = 135, ProductId = 4, PharmacyId = 2, Id = 4 };

        var fourthProductPharmaGroup = new ProductPharmaGroup { Id = 4, PharmaGroupId = 4, ProductId = 4 };

        var fourthSale = new Sale { PaymentChoice = "Online", PaymentDate = new DateTime(2022, 11, 18), ProductId = 4, Id = 4 };

        var fifthProduct = new Product { ProductName = "Nekst", Id = 5, GroupId = 1, ManufacturerId = 1 };
        var fifthProductPharmacy = new ProductPharmacy { ProductCount = 10, ProductCost = 350, ProductId = 5, PharmacyId = 5, Id = 5 };

        var fifthProductPharmaGroup = new ProductPharmaGroup { Id = 5, PharmaGroupId = 1, ProductId = 5 };

        var fifthSale = new Sale{PaymentChoice = "Online", PaymentDate = new DateTime(2022, 5, 23), ProductId = 5, Id = 5};
`       
        modelBuilder.Entity<Product>()
            .HasOne(product => product.Group)
            .WithMany(group => group.Products)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasOne(product => product.Manufacturer)
            .WithMany(manufacturer => manufacturer.Products)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductPharmacy>()
            .HasOne(productPharmacy => productPharmacy.Product)
            .WithMany(product => product.ProductPharmacys)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductPharmacy>()
           .HasOne(productPharmacy => productPharmacy.Product)
           .WithMany(product => product.ProductPharmacys)
           .OnDelete(DeleteBehavior.Cascade);

    }
}
