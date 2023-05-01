using Microsoft.EntityFrameworkCore;
using System;

namespace PonrfDomain;
/// <summary>
/// PonrfContex used to work with database
/// </summary>
public class PonrfContext : DbContext
{
    /// <summary>
    /// Collection of auctions
    /// </summary>
    public DbSet<Auction>? Auctions { get; set; } = null!;

    /// <summary>
    /// Collection of buildings
    /// </summary>
    public DbSet<Building>? Buildings { get; set; } = null!;

    /// <summary>
    /// Collection of customers
    /// </summary>
    public DbSet<Customer>? Customers { get; set; } = null!;

    /// <summary>
    /// Collection of privatized buildings
    /// </summary>
    public DbSet<PrivatizedBuilding>? PrivatizedBuildings { get; set; } = null!;

    /// <summary>
    /// Constructor for PonrfContext
    /// </summary>
    /// <param name="options"></param>
    public PonrfContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Creating data for DB
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var customers = new List<Customer>()
        {
            new Customer(){Id = 1, Passport = "23 47 345689", Fio = "Раскольникова С. М.", Address = "пр. Чехова, 94"},
            new Customer(){Id = 2, Passport = "67 56 123456", Fio = "Рудаков Р. Р.", Address = "пр. Гагарина, 7"},
            new Customer(){Id = 3, Passport = "21 47 867535", Fio = "Каневский Л. С.", Address = "пер. Будапештсткий, 35"},
            new Customer(){Id = 4, Passport = "23 42 345123", Fio = "Саламандрова А. А.", Address = "пр. Ленина, 68"},
            new Customer(){Id = 5, Passport = "23 45 340987", Fio = "Морская Н. П.", Address = "спуск Ломоносова, 16"},
            new Customer(){Id = 6, Passport = "98 47 345689", Fio = "Турец И. П.", Address = "пл. Славы, 44"},
        };

        var buildings = new List<Building>()
        {
            new Building(){Id = 1, RegistNum = "30:45:423298:13", District = "Кировский", Street = "Домодедовская", HouseNumber = 76, Area = 120, Floors = 2, DateOfBuild = DateTime.Parse("2001-09-05"), PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Building(){Id = 2, RegistNum = "30:67:345783:14", District = "Кировский", Street = "Домодедовская", HouseNumber = 1, Area = 75, Floors = 1, DateOfBuild = DateTime.Parse("2003-10-16"), PrivatizedBuilding = new List <PrivatizedBuilding>()},
            new Building(){Id = 3, RegistNum = "67:45:423298:15", District = "Самарский", Street = "Самарская", HouseNumber = 42, Area = 235, Floors = 3, DateOfBuild = DateTime.MinValue, PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Building(){Id = 4, RegistNum = "45:46:123096:16", District = "Железнодорожный", Street = "Гоголя", HouseNumber = 53, Area = 68, Floors = 1, DateOfBuild = DateTime.Parse("2018-02-09"), PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Building(){Id = 5, RegistNum = "98:34:345678:17", District = "Промышленный", Street = "Гагарина", HouseNumber = 7, Area = 2100, Floors = 5, DateOfBuild = DateTime.Parse("2018-02-09"), PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Building(){Id = 6, RegistNum = "45:23:423298:18", District = "Железнодорожный", Street = "Студенческий", HouseNumber = 12, Area = 540, Floors = 3, DateOfBuild = DateTime.Parse("1997-10-30"), PrivatizedBuilding = new List<PrivatizedBuilding>()},
        };

        var auctions = new List<Auction>()
        {
            new Auction(){Id = 1,Date = DateTime.Parse("2023-02-02"), Organizer = "Аргентум", PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Auction(){Id = 2, Date = DateTime.Parse("2022-09-11"), Organizer = "Сириус", PrivatizedBuilding = new List<PrivatizedBuilding>()},
            new Auction(){Id = 3, Date = DateTime.Parse("2023-03-03"), Organizer = "Вечность", PrivatizedBuilding = new List<PrivatizedBuilding>()},
        };

        var privatizedBuildings = new List<PrivatizedBuilding>()
        {
            new PrivatizedBuilding(){Id = 1, DateOfSale = DateTime.Parse("2023-02-02"), FirstCost = 100000, SecondCost = 300000, Customer = customers[0], Auction = auctions[0], Building = buildings[0]},
            new PrivatizedBuilding(){Id = 2, FirstCost =  178000, SecondCost = 0, Customer = null, Auction = auctions[0], Building = buildings[2]},
            new PrivatizedBuilding(){Id = 3, DateOfSale = DateTime.Parse("2003-02-02"), FirstCost = 400000, SecondCost = 750000, Customer = customers[1], Auction = auctions[0], Building = buildings[1]},
            new PrivatizedBuilding(){Id = 4, DateOfSale = DateTime.Parse("2023-03-04"), FirstCost = 560000, SecondCost = 640000, Customer = customers[1], Auction = auctions[2], Building = buildings[3]},
            new PrivatizedBuilding(){Id = 5, DateOfSale = DateTime.Parse("2023-03-03"), FirstCost = 600000, SecondCost = 650000, Customer = customers[2], Auction = auctions[2], Building = buildings[2]},
            new PrivatizedBuilding(){Id = 6, DateOfSale = DateTime.Parse("2023-09-11"), FirstCost = 303000, SecondCost = 708000, Customer = customers[3], Auction = auctions[1], Building = buildings[5]},
            new PrivatizedBuilding(){Id = 7, DateOfSale = DateTime.Parse("2023-09-11"), FirstCost = 3100000, SecondCost = 6700000, Customer = customers[5], Auction = auctions[1], Building = buildings[4]},
        };

        auctions[0].PrivatizedBuilding?.Add(privatizedBuildings[0]);
        auctions[0].PrivatizedBuilding?.Add(privatizedBuildings[1]);
        auctions[0].PrivatizedBuilding?.Add(privatizedBuildings[2]);
        auctions[1].PrivatizedBuilding?.Add(privatizedBuildings[3]);
        auctions[1].PrivatizedBuilding?.Add(privatizedBuildings[4]);
        auctions[2].PrivatizedBuilding?.Add(privatizedBuildings[5]);
        auctions[2].PrivatizedBuilding?.Add(privatizedBuildings[6]);

        buildings[0].PrivatizedBuilding?.Add(privatizedBuildings[0]);
        buildings[2].PrivatizedBuilding?.Add(privatizedBuildings[1]);
        buildings[1].PrivatizedBuilding?.Add(privatizedBuildings[2]);
        buildings[2].PrivatizedBuilding?.Add(privatizedBuildings[5]);
        buildings[3].PrivatizedBuilding?.Add(privatizedBuildings[6]);
        buildings[4].PrivatizedBuilding?.Add(privatizedBuildings[4]);
        buildings[5].PrivatizedBuilding?.Add(privatizedBuildings[3]);

        modelBuilder.Entity<Auction>().HasData(auctions);
        modelBuilder.Entity<Building>().HasData(buildings);
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<PrivatizedBuilding>().HasData(privatizedBuildings);
    }
}
