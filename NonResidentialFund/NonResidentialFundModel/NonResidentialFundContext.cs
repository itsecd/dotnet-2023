using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NonResidentialFund.Model;
/// <summary>
/// NonResidentialFundContext - represents a DbContext for the application
/// </summary>
public sealed class NonResidentialFundContext : DbContext
{
    /// <summary>
    /// Auctions - Represents a collection of Auction objects in the database
    /// </summary>
    public DbSet<Auction> Auctions { get; set; }

    /// <summary>
    /// Buildings - Represents a collection of Building objects in the database
    /// </summary>
    public DbSet<Building> Buildings { get; set; }

    /// <summary>
    /// BuildingAuctionConnections - Represents a collection of BuildingAuctionConnections objects in the database
    /// </summary>
    public DbSet<BuildingAuctionConnection> BuildingAuctionConnections { get; set; }

    /// <summary>
    /// Buyers - Represents a collection of Buyer objects in the database
    /// </summary>
    public DbSet<Buyer> Buyers { get; set; }

    /// <summary>
    /// BuyerAuctionConnections - Represents a collection of BuyerAuctionConnection objects in the database
    /// </summary>
    public DbSet<BuyerAuctionConnection> BuyerAuctionConnections { get; set; }

    /// <summary>
    /// Districts - Represents a collection of District objects in the database
    /// </summary>
    public DbSet<District> Districts { get; set; }

    /// <summary>
    /// Organizations - Represents a collection of Organizations objects in the database
    /// </summary>
    public DbSet<Organization> Organizations { get; set; }

    /// <summary>
    /// Privatized - Represents a collection of Privatized buildings objects in the database
    /// </summary>
    public DbSet<Privatized> Privatized { get; set; }

    /// <summary>
    /// Constructor of NonResidentialFundContext
    /// </summary>
    /// <param name="options">Parameter for NonResidentialFundContext</param>
    public NonResidentialFundContext(DbContextOptions options) : base(options)
    {
        try{
            Database.EnsureCreated();
        }
        catch{
        }
    }

    /// <summary>
    /// DistrictRepository - collection of Distruct objects, which is used to be add into database when it created
    /// </summary>
    private List<District> DistrictRepository
    {
        get
        {
            return new List<District> {
                new District
                {
                    DistrictId = 1,
                    DistrictName = "Промышленный"
                },
                new District
                {
                    DistrictId = 2,
                    DistrictName = "Кировский"
                },
                new District
                {
                    DistrictId = 3,
                    DistrictName = "Советский"
                },
                new District
                {
                    DistrictId = 4,
                    DistrictName = "Октябрьский"
                },
                new District
                {
                    DistrictId = 5,
                    DistrictName = "Куйбышевский"
                },
                new District
                {
                    DistrictId = 6,
                    DistrictName = "Железнодорожный"
                }
            };
        }
    }

    /// <summary>
    /// OrganizationRepository - collection of Organization objects, which is used to be add into database when it created
    /// </summary>
    private List<Organization> OrganizationRepository
    {
        get
        {
            return new List<Organization>{
                new Organization
                {
                    OrganizationId = 1,
                    OrganizationName = "СамараИнвест"
                },
                new Organization
                {
                    OrganizationId = 2,
                    OrganizationName = "ОАО Аукцион"
                },
                new Organization
                {
                    OrganizationId = 3,
                    OrganizationName = "Имущественные торги"
                },
                new Organization
                {
                    OrganizationId = 4,
                    OrganizationName = "Самара Тендер"
                },
                new Organization
                {
                    OrganizationId = 5,
                    OrganizationName = "АО Сбербанк-АСТ"
                },
                new Organization
                {
                    OrganizationId = 6,
                    OrganizationName = "АО ЕЭТП"
                }
            };
        }
    }

    /// <summary>
    /// BuyerRepository - collection of Buyer objects, which is used to be add into database when it created
    /// </summary>
    private List<Buyer> BuyerRepository
    {
        get
        {
            return new List<Buyer>
            {
                new Buyer
                {
                    BuyerId = 1,
                    LastName = "Мизягин",
                    FirstName = "Евгений",
                    MiddleName = "Викторович",
                    PassportSeries = "3716",
                    PassportNumber = "928715",
                    Address = "г. Самара ул. Московское шоссе 252 кв. 186"
                },
                new Buyer
                {
                    BuyerId = 2,
                    LastName = "Грачев",
                    FirstName = "Михаил",
                    MiddleName = "Александрович",
                    PassportSeries = "6251",
                    PassportNumber = "629574",
                    Address = "г. Сызрань ул. Советская 15 кв. 3"
                },
                new Buyer
                {
                    BuyerId = 3,
                    LastName = "Подлипаев",
                    FirstName = "Олег",
                    MiddleName = "Викторович",
                    PassportSeries = "6295",
                    PassportNumber = "746153",
                    Address = "г. Новокуйбышевск ул. Советская 71 кв. 13"
                },
                new Buyer
                {
                    BuyerId = 4,
                    LastName = "Корнеев",
                    FirstName = "Николай",
                    MiddleName = "Игоревич",
                    PassportSeries = "9462",
                    PassportNumber = "745625",
                    Address = "г. Самара ул. Ново-садовая 25 кв. 77"
                },
                new Buyer
                {
                    BuyerId = 5,
                    LastName = "Чубрин",
                     FirstName = "Александр",
                    MiddleName = "Андреевич",
                    PassportSeries = "8572",
                    PassportNumber = "547296",
                    Address = "г. Самара ул. Авроры 52 кв. 11"
                },
                new Buyer
                {
                    BuyerId = 6,
                    LastName = "Сомова",
                     FirstName = "Надежда",
                    MiddleName = "Николаевна",
                    PassportSeries = "6356",
                    PassportNumber = "782546",
                    Address = "г. Новокуйбышевск ул. Карла Маркса 81 кв. 39"
                },
                new Buyer
                {
                    BuyerId = 7,
                    LastName = "Мочалов",
                     FirstName = "Андрей",
                    MiddleName = "Сергеевич",
                    PassportSeries = "6567",
                    PassportNumber = "856456",
                    Address = "г. Сызрань ул. Подшипниковая 12 кв. 2"
                },
                new Buyer
                {
                    BuyerId = 8,
                    LastName = "Аскерова",
                    FirstName = "Вера",
                    MiddleName = "Игоревна",
                    PassportSeries = "7145",
                    PassportNumber = "624256",
                    Address = "г. Самара ул. Фадеева 1 кв. 54"
                }
            };
        }
    }

    /// <summary>
    /// BuildingRepository - collection of Building objects, which is used to be add into database when it created
    /// </summary>
    private List<Building> BuildingRepository
    {
        get
        {
            return new List<Building>{
                new Building
                {
                    RegistrationNumber = 1,
                    Address = "Ул. Московскосе шоссе д. 22 кв. 8",
                    DistrictId = 1,
                    Area = 43.9,
                    FloorCount = 9,
                    BuildDate =  new DateTime(1980, 1, 10)
                },
                new Building
                {
                    RegistrationNumber = 2,
                    Address = "Ул. Ново-вокзальная д. 1 кв. 19",
                    DistrictId = 1,
                    Area = 63.0,
                    FloorCount = 9,
                    BuildDate = new DateTime(1988, 10, 21)
                },
                new Building
                {
                    RegistrationNumber = 3,
                    Address = "Ул. Фадеева д. 62",
                    DistrictId = 1,
                    Area = 1243.9,
                    FloorCount =  2,
                    BuildDate =  new DateTime(1966, 6, 1)
                },
                new Building
                {
                    RegistrationNumber = 4,
                    Address = "Ул. Стара-Загора д. 78 кв. 41",
                    DistrictId = 1,
                    Area = 98.3,
                    FloorCount = 12,
                    BuildDate = new DateTime(1978, 6,13)
                },
                new Building
                {
                    RegistrationNumber = 5,
                    Address = "Ул. Cолнечная д. 30",
                    DistrictId = 1,
                    Area = 298.3,
                    FloorCount = 12,
                    BuildDate = new DateTime(2006, 3, 1)
                },
                new Building
                {
                    RegistrationNumber = 6,
                    Address = "Ул. Ставропольская д. 214 кв. 8",
                    DistrictId = 2,
                    Area = 33.9,
                    FloorCount = 16,
                    BuildDate = new DateTime(2007,10,11)
                },
                new Building
                {
                    RegistrationNumber = 7,
                    Address = "Ул. Советская д. 119 кв. 1",
                    DistrictId = 2,
                    Area = 43.0,
                    FloorCount = 2,
                    BuildDate = new DateTime(1941, 3, 3)
                },
                new Building
                {
                    RegistrationNumber = 8,
                    Address = "Ул. Мирная д. 165",
                    DistrictId = 2,
                    Area = 283.9,
                    FloorCount = 2,
                    BuildDate = new DateTime(2003, 7, 13)
                },
                new Building
                {
                    RegistrationNumber = 9,
                    Address = "Ул. Черемшанская д. 158 кв. 41",
                    DistrictId = 2,
                    Area = 112.3,
                    FloorCount = 5,
                    BuildDate = new DateTime(1973, 5, 30)
                },
                new Building
                {
                    RegistrationNumber = 10,
                    Address = "Ул. Юнных пионеров д. 154А",
                    DistrictId = 2,
                    Area = 2482.3,
                    FloorCount = 3,
                    BuildDate = new DateTime(1969, 12, 30)
                }
            };
        }
    }

    /// <summary>
    /// PrivatizedRepository - collection of Privatized building objects, which is used to be add into database when it created
    /// </summary>
    private List<Privatized> PrivatizedRepository
    {
        get
        {
            return new List<Privatized>
        {
            new Privatized
            {
                RegistrationNumber = 1,
                BuyerId = 1,
                AuctionId = 1,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 615827.99,
                EndPrice = 1297618.13
            },
            new Privatized
            {
                RegistrationNumber = 2,
                BuyerId = 4,
                AuctionId = 2,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 862100.93,
                EndPrice = 1231971.10
            },
            new Privatized
            {
                RegistrationNumber = 3,
                BuyerId = 8,
                AuctionId = 3,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 1062109.00,
                EndPrice = 14301872.17
            },
            new Privatized
            {
                RegistrationNumber = 7,
                BuyerId = 2,
                AuctionId = 5,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 1846378.72,
                EndPrice = 2647635.37
            },
            new Privatized
            {
                RegistrationNumber = 8,
                BuyerId = 1,
                AuctionId = 8,
                SaleDate = new DateTime(2022, 3, 20),
                StartPrice = 628476.17,
                EndPrice = 964372.09
            },
            new Privatized
            {
                RegistrationNumber = 9,
                BuyerId = 8,
                AuctionId = 7,
                SaleDate = new DateTime(2022, 3, 19),
                StartPrice = 2657387.93,
                EndPrice = 4726478.00
            }
        };
        }
    }

    /// <summary>
    /// AuctionRepository - collection of Auction objects, which is used to be add into database when it created
    /// </summary>
    private List<Auction> AuctionRepository
    {
        get
        {
            return new List<Auction>
            {
                new Auction
                {
                    AuctionId = 1,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 1
                },
                new Auction
                {
                    AuctionId = 2,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 3
                },
                new Auction
                {
                    AuctionId = 3,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 7
                },
                new Auction
                {
                    AuctionId = 4,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 8
                },
                new Auction
                {
                    AuctionId = 5,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 4
                },
                new Auction
                {
                    AuctionId = 6,
                    Date = new DateTime(2022, 3, 17),
                    OrganizationId = 2
                },
                new Auction
                {
                    AuctionId = 7,
                    Date = new DateTime(2022, 3, 19),
                    OrganizationId = 1
                },
                new Auction
                {
                    AuctionId = 8,
                    Date = new DateTime(2022, 3, 20),
                    OrganizationId = 7
                },
                new Auction
                {
                    AuctionId = 9,
                    Date = new DateTime(2022, 3, 21),
                    OrganizationId = 2
                },
                new Auction
                {
                    AuctionId = 10,
                    Date = new DateTime(2022, 3, 21),
                    OrganizationId = 3
                }
            };
        }
    }

    /// <summary>
    /// BuildingAuctionConnectionRepository - collection of BuildingAuctionConnection objects, which is used to be add into database when it created
    /// </summary>
    private List<BuildingAuctionConnection> BuildingAuctionConnectionRepository
    {
        get
        {
            return new List<BuildingAuctionConnection>
            {
                new BuildingAuctionConnection{Id = 1, BuildingId = 1, AuctionId = 1 },
                new BuildingAuctionConnection{Id = 2, BuildingId = 2, AuctionId = 2 },
                new BuildingAuctionConnection{Id = 3, BuildingId = 3, AuctionId = 3 },
                new BuildingAuctionConnection{Id = 4, BuildingId = 4, AuctionId = 5 },
                new BuildingAuctionConnection{Id = 5, BuildingId = 5, AuctionId = 4 },
                new BuildingAuctionConnection{Id = 6, BuildingId = 5, AuctionId = 10 },
                new BuildingAuctionConnection{Id = 7, BuildingId = 7, AuctionId = 5 },
                new BuildingAuctionConnection{Id = 8, BuildingId = 8, AuctionId = 6 },
                new BuildingAuctionConnection{Id = 9,  BuildingId = 8, AuctionId = 8 },
                new BuildingAuctionConnection{Id = 10,  BuildingId = 9, AuctionId = 1 },
                new BuildingAuctionConnection{Id = 11,  BuildingId = 9, AuctionId = 7 },
                new BuildingAuctionConnection{Id = 12,  BuildingId = 10, AuctionId = 4 },
                new BuildingAuctionConnection{Id = 13,  BuildingId = 10, AuctionId = 9 }
            };
        }
    }

    /// <summary>
    /// BuyerAuctionConnectionRepository - collection of BuyerAuctionConnection objects, which is used to be add into database when it created
    /// </summary>
    private List<BuyerAuctionConnection> BuyerAuctionConnectionRepository
    {
        get
        {
            return new List<BuyerAuctionConnection>
            {
                new BuyerAuctionConnection{Id = 1, BuyerId = 1, AuctionId = 1 },
                new BuyerAuctionConnection{Id = 2, BuyerId = 1, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 3, BuyerId = 1, AuctionId = 6 },
                new BuyerAuctionConnection{Id = 4, BuyerId = 1, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 5, BuyerId = 1, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 6, BuyerId = 1, AuctionId = 10},
                new BuyerAuctionConnection{Id = 7, BuyerId = 2, AuctionId = 1 },
                new BuyerAuctionConnection{Id = 8, BuyerId = 2, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 9, BuyerId = 2, AuctionId = 6 },
                new BuyerAuctionConnection{Id = 10, BuyerId = 2, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 11, BuyerId = 2, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 12, BuyerId = 3, AuctionId = 4 },
                new BuyerAuctionConnection{Id = 13, BuyerId = 3, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 14, BuyerId = 3, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 15, BuyerId = 3, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 16, BuyerId = 3, AuctionId = 9 },
                new BuyerAuctionConnection{Id = 17, BuyerId = 4, AuctionId = 2 },
                new BuyerAuctionConnection{Id = 18, BuyerId = 4, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 19, BuyerId = 4, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 20, BuyerId = 4, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 21, BuyerId = 4, AuctionId = 10 },
                new BuyerAuctionConnection{Id = 22, BuyerId = 5, AuctionId = 2 },
                new BuyerAuctionConnection{Id = 23, BuyerId = 5, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 24, BuyerId = 5, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 25, BuyerId = 5, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 26, BuyerId = 6, AuctionId = 4 },
                new BuyerAuctionConnection{Id = 27, BuyerId = 6, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 28, BuyerId = 6, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 29, BuyerId = 6, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 30, BuyerId = 7, AuctionId = 3 },
                new BuyerAuctionConnection{Id = 31, BuyerId = 7, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 32, BuyerId = 7, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 33, BuyerId = 7, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 34, BuyerId = 7, AuctionId = 9 },
                new BuyerAuctionConnection{Id = 35, BuyerId = 8, AuctionId = 3 },
                new BuyerAuctionConnection{Id = 36, BuyerId = 8, AuctionId = 5 },
                new BuyerAuctionConnection{Id = 37, BuyerId = 8, AuctionId = 7 },
                new BuyerAuctionConnection{Id = 38, BuyerId = 8, AuctionId = 8 },
                new BuyerAuctionConnection{Id = 39, BuyerId = 8, AuctionId = 10 }
            };
        }
    }

    /// <summary>
    /// Configures structure of database
    /// Inserts data into the database
    /// </summary>
    /// <param name="modelBuilder">Object for configuring the database</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuildingAuctionConnection>().HasKey(connection => new { connection.BuildingId, connection.AuctionId });

        foreach (var district in DistrictRepository)
        {
            modelBuilder.Entity<District>().HasData(district);
        }
        foreach (var organization in OrganizationRepository)
        {
            modelBuilder.Entity<Organization>().HasData(organization);
        }
        foreach (var buyer in BuyerRepository)
        {
            modelBuilder.Entity<Buyer>().HasData(buyer);
        }
        foreach (var building in BuildingRepository)
        {
            modelBuilder.Entity<Building>().HasData(building);
        }
        foreach (var privatized in PrivatizedRepository)
        {
            modelBuilder.Entity<Privatized>().HasData(privatized);
        }
        foreach (var auction in AuctionRepository)
        {
            modelBuilder.Entity<Auction>().HasData(auction);
        }
        foreach (var buildingAuctionConnection in BuildingAuctionConnectionRepository)
        {
            modelBuilder.Entity<BuildingAuctionConnection>().HasData(buildingAuctionConnection);
        }
        foreach (var buyerAuctionRepository in BuyerAuctionConnectionRepository)
        {
            modelBuilder.Entity<BuyerAuctionConnection>().HasData(buyerAuctionRepository);
        }
    }
};