using PonrfDomain;

namespace PonrfTests;
public class PonrfFixture
{
    /// <summary>
    /// List of customers for testing
    /// </summary>
    public List<Customer> CustomersFixture
    {
        get
        {
            var customers = new List<Customer>()
            {
                new Customer(1, "Раскольникова С. М.", "пр. Чехова, 94"),
                new Customer(2, "Рудаков Р. Р.", "пр. Гагарина, 7"),
                new Customer(3, "'Каневский Л. С.", "пер. Будапештсткий, 35"),
            };
            return customers;
        }
    }
    /// <summary>
    /// List of buildings for testing
    /// </summary>
    public List<Building> BuildingsFixture
    {
        get
        {
            var buildings = new List<Building>()
            {
                new Building(1, "Кировский", "Домодедовская", 76, 120, 2, DateTime.Parse("2001-09-05")),
                new Building(2, "Кировский", "Домодедовская", 1, 75, 1, DateTime.Parse("2003-10-16")),
                new Building(3, "Самарский", "Самарская", 42, 235, 3, DateTime.MinValue),
            };
            return buildings;
        }
    }
    /// <summary>
    /// List of auctions for testing
    /// </summary>
    public List<Auction> AuctionFixture
    {
        get
        {
            var auction = new List<Auction>()
            {
                new Auction(1, DateTime.Parse("2023-02-02"),"Аргентум"),
                new Auction(2, DateTime.Parse("2022-09-11"),"Сириус"),
            };
            return auction;
        }
    }
    /// <summary>
    /// List of privatized buildings for testing
    /// </summary>
    public List<PrivatizedBuilding> PrivatizedBuildingsFixture
    {
        get
        {
            var customers = CustomersFixture;
            var buildings = BuildingsFixture;
            var auction = AuctionFixture;
            var privatizedBuildings = new List<PrivatizedBuilding>()
            {
                new PrivatizedBuilding(1, DateTime.Parse("2023-02-02"), 100000, 300000, customers[1], auction[1], buildings[1]),
                new PrivatizedBuilding(2, DateTime.Parse("2003-02-02"), 400000, 750000, customers[2], auction[1], buildings[2]),
            };
            return privatizedBuildings;
        }
    }
}