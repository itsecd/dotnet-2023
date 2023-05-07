using Microsoft.EntityFrameworkCore;

namespace Warehouse.Domain;

/// <summary>
///     Class represented a DbContext of Warehouse
/// </summary>
public sealed class WarehouseDbContext : DbContext
{
    public DbSet<Products>? Products { get; set; }
    public DbSet<Supplies>? Supplies { get; set; }
    public DbSet<WarehouseCells>? Cells { get; set; }
    public WarehouseDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var firstRoute = new Supplies { Id = 1, CompanyName = "СамараПласт", CompanyAddress = "г. Самара, ул. Луцкая, 16.", SupplyDate = new DateTime(2023, 02, 20), Quantity = 10 };
        var secondRoute = new Supplies { Id = 2, CompanyName = "Самара Строй Комплект", CompanyAddress = "г. Самара, ул. Олимпийская, 73а.", SupplyDate = new DateTime(2023, 03, 01), Quantity = 5 };
        var thirdRoute = new Supplies { Id = 3, CompanyName = "Fix Price", CompanyAddress = "г. Самара, ул. Спортивная, 20.", SupplyDate = new DateTime(2023, 02, 11), Quantity = 10 };
        var fourthRoute = new Supplies { Id = 4, CompanyName = "Fix Price", CompanyAddress = "г. Самара, ул. Спортивная, 20.", SupplyDate = new DateTime(2023, 02, 11), Quantity = 10 };

        var firstProduction = new Products { Id = 103722, Name = "Контейнер 640мл с крышкой", Quantity = 100 };
        var secondProduction = new Products { Id = 164302, Name = "Картонная коробка 60*40*50", Quantity = 50 };
        var thirdProduction = new Products { Id = 106932, Name = "Пищевая плёнка для упаковки 5м", Quantity = 5 };
        var fourthProduction = new Products { Id = 218302, Name = "Гипсовая штукатурка 5кг", Quantity = 10 };
        var fifthProduction = new Products { Id = 319510, Name = "Столовая ложка из нерж. стали", Quantity = 35 };
        var sixthProduction = new Products { Id = 320513, Name = "Вилка из нерж. стали", Quantity = 25 };
        var seventhProduction = new Products { Id = 161708, Name = "Ваза из стекла 4л", Quantity = 10 };
        var eighthProduction = new Products { Id = 103410, Name = "Ваза из стекла 3л", Quantity = 15 };

        var firstCell = new WarehouseCells { CellNumber = 1, ProductId = 103722 };
        var secondCell = new WarehouseCells { CellNumber = 2, ProductId = 164302 };
        var thirdCell = new WarehouseCells { CellNumber = 3, ProductId = 106932 };
        var fourthCell = new WarehouseCells { CellNumber = 4, ProductId = 218302 };
        var fifthCell = new WarehouseCells { CellNumber = 5, ProductId = 319510 };
        var sixthCell = new WarehouseCells { CellNumber = 6, ProductId = 320513 };
        var seventhCell = new WarehouseCells { CellNumber = 7, ProductId = 161708 };
        var eighthCell = new WarehouseCells { CellNumber = 8, ProductId = 103410 };
        var ninthCell = new WarehouseCells { CellNumber = 9, ProductId = 103410 };
        var tenthCell = new WarehouseCells { CellNumber = 10, ProductId = 218302 };
        var eleventhCell = new WarehouseCells { CellNumber = 11, ProductId = 218302 };

        modelBuilder.Entity<WarehouseCells>()
            .HasOne(cell => cell.Product)
            .WithMany(product => product.WarehouseCell)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Products>().HasData(new List<Products> {
            firstProduction,
            secondProduction,
            thirdProduction,
            fourthProduction,
            fifthProduction,
            sixthProduction,
            seventhProduction,
            eighthProduction
        });

        modelBuilder.Entity<Supplies>().HasData(new List<Supplies> {
            firstRoute,
            secondRoute,
            thirdRoute,
            fourthRoute
        });

        modelBuilder.Entity<WarehouseCells>().HasData(new List<WarehouseCells> {
            firstCell,
            secondCell,
            thirdCell,
            fourthCell,
            fifthCell,
            sixthCell,
            seventhCell,
            eighthCell,
            ninthCell,
            tenthCell,
            eleventhCell
        });
    }
}