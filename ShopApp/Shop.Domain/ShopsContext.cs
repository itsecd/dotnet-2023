using Microsoft.EntityFrameworkCore;

namespace Shops.Domain;
public class ShopsContext : DbContext
{
    public DbSet<Customer> Customers { get; set;} = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductGroup> ProductGroups { get; set; } = null!;
    public DbSet<ProductQuantity> ProductQuantity { get; set; } = null!;
    public DbSet<PurchaseRecord> PurchaseRecords { get; set; } = null!;
    public DbSet<Shop> Shops { get; set; } = null!;
    public ShopsContext(DbContextOptions options) : base(options)
    { 
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var shop1 = new Shop { Id = 1, Address = "Гагарина 2", Name = "Дом кота" };
        var shop2 = new Shop { Id = 2, Address = "Аврора 31", Name = "Овощебаза" };
        var shop3 = new Shop { Id = 3, Address = "Куйбышева 82", Name = "продукты" };
        modelBuilder.Entity<Shop>().HasData(new List<Shop> { shop1, shop2, shop3 });

        modelBuilder.Entity<ProductGroup>().HasData(new List<ProductGroup>{
                    new ProductGroup(1, "Молочный"),
                    new ProductGroup(2, "Мясной"),
                    new ProductGroup(3, "Рыбный"),
                    new ProductGroup(4, "Выпечка"),
                    new ProductGroup(5, "Бакалея"),
                    new ProductGroup(6, "Напитки"),
                    new ProductGroup(7, "Конфеты")});


        var products = new List<Product>() {
                new Product (1, "1", "Молоко", 1,  0.5, "штучный", 70, new DateTime(2023, 01, 30) ),
                new Product (2, "2", "Лапша", 5,  0.9, "штучный", 90, new DateTime(2033, 03, 30) ),
                new Product (3, "3", "Масло", 1,  0.25, "штучный", 80, new DateTime(2023, 04, 05) ),
                new Product (4, "4", "Свинина", 2,  1.0, "развесной", 350, new DateTime(2023, 03, 27) ),
                new Product (5, "5", "Яйца", 2,  0.35, "штучный", 99, new DateTime(2023, 04, 20) ),
                new Product (6, "6", "Хлеб", 4,  0.5, "штучный", 50, new DateTime(2023, 02, 25) ),
                new Product (7, "7", "Вода", 6,  1.5, "штучный", 50, new DateTime(2033, 03, 25) ),
                new Product (8, "8", "Форель", 3,  1.0, "развесной", 500, new DateTime(2023, 03, 27) ),
                new Product (9, "9", "Сникерс", 7,  0.035, "штучный", 40, new DateTime(2023, 09, 27) )};
        modelBuilder.Entity<Product>().HasData(products);

        modelBuilder.Entity<ProductQuantity>().HasData(new List<ProductQuantity>()
            {
            new ProductQuantity(1, 1, 1, 250),
            new ProductQuantity(2, 2, 1, 100),
            new ProductQuantity(3, 3, 1, 50),
            new ProductQuantity(4, 5, 1, 60),
            new ProductQuantity(5, 6, 1, 75),
            new ProductQuantity(6, 7, 1, 100),
            new ProductQuantity(7, 9, 1, 200),
            new ProductQuantity(8, 2, 2, 200),
            new ProductQuantity(9, 5, 2, 100),
            new ProductQuantity(10, 6, 2, 100),
            new ProductQuantity(11, 7, 2, 90),
            new ProductQuantity(12, 9, 2, 40),
            new ProductQuantity(13, 1, 3, 200),
            new ProductQuantity(14, 3, 3, 100),
            new ProductQuantity(15, 4, 3, 50),
            new ProductQuantity(16, 5, 3, 60),
            new ProductQuantity(17, 6, 3, 75),
            new ProductQuantity(18, 7, 3, 30),
            new ProductQuantity(19, 8, 3, 130)});

        modelBuilder.Entity<Customer>().HasData(new List<Customer>
                {
                    new Customer(1, "Максим", "Матросов", "Владимирович", "10000"),
                    new Customer(2, "Иван", "Иванов", "Иванович", "10001"),
                    new Customer(3, "Лиана", "Волкова", "Степановна", "10002"),
                    new Customer(4, "Екатерина", "Анисимова", "Александровна", "10003"),
                    new Customer(5, "Александр", "Фатьянов", "Игоревич", "10004")});

        modelBuilder.Entity<PurchaseRecord>().HasData(new List<PurchaseRecord> {
            new PurchaseRecord { Id = 1, ShopId = 1, CustomerId = 1, ProductId = 1, Quantity = 5, DateSale = new DateTime(2023, 03, 13), Sum =  products[0].Price * 5},
            new PurchaseRecord { Id = 2, ShopId = 2, CustomerId = 2, ProductId = 2, Quantity = 78, DateSale = new DateTime(2023, 03, 13), Sum = products[1].Price * 78},
            new PurchaseRecord { Id = 3, ShopId = 3, CustomerId = 3, ProductId = 3, Quantity = 41, DateSale = new DateTime(2023, 01, 14), Sum = products[2].Price * 41},
            new PurchaseRecord { Id = 4, ShopId = 1, CustomerId = 4, ProductId = 5, Quantity = 2, DateSale = new DateTime(2023, 01, 14), Sum = products[4].Price * 2},
            new PurchaseRecord { Id = 5, ShopId = 2, CustomerId = 5, ProductId = 6, Quantity = 4, DateSale = new DateTime(2023, 03, 13), Sum = products[5].Price * 4},
            new PurchaseRecord { Id = 6, ShopId = 3, CustomerId = 1, ProductId = 7, Quantity = 5, DateSale = new DateTime(2023, 03, 13), Sum = products[6].Price * 5},
            new PurchaseRecord { Id = 7, ShopId = 1, CustomerId = 2, ProductId = 9, Quantity = 8, DateSale = new DateTime(2023, 03, 14), Sum = products[8].Price * 8},
        });
    }
}
