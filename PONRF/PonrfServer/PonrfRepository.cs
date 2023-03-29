using PonrfDomain;
using System.IO;
using System.Net;

namespace PonrfServer;

public class PonrfRepository
{
    public List<Customer> Customers
    {
        get
        {
            var customers = new List<Customer>()
            {
                new Customer(1, "23 47 345689", "Раскольникова С. М.", "пр. Чехова, 94"),
                new Customer(2, "67 56 123456", "Рудаков Р. Р.", "пр. Гагарина, 7"),
                new Customer(3, "21 47 867535", "Каневский Л. С.", "пер. Будапештсткий, 35"),
                new Customer(4, "23 42 345123", "Саламандрова А. А.", "пр. Ленина, 68"),
                new Customer(5, "23 45 340987", "Морская Н. П.", "спуск Ломоносова, 16"),
                new Customer(6, "98 47 345689", "Турец И. П.", "пл. Славы, 44"),
            };
            return customers;
        }
    }

    public List<Building> Buildings
    {
        get
        {
            var buildings = new List<Building>()
            {
                new Building(1, "30:45:423298:13", "Кировский", "Домодедовская", 76, 120, 2, DateTime.Parse("2001-09-05"), new List<PrivatizedBuilding>()),
                new Building(2, "30:67:345783:14", "Кировский", "Домодедовская", 1, 75, 1, DateTime.Parse("2003-10-16"), new List<PrivatizedBuilding>()),
                new Building(3, "67:45:423298:15", "Самарский", "Самарская", 42, 235, 3, DateTime.MinValue, new List<PrivatizedBuilding>()),
                new Building(4, "45:46:123096:16", "Железнодорожный", "Гоголя", 53, 68, 1, DateTime.Parse("2018-02-09"), new List<PrivatizedBuilding>()),
                new Building(5, "98:34:345678:17", "Промышленный", "Гагарина", 7, 2100, 5, DateTime.Parse("2018-02-09"), new List<PrivatizedBuilding>()),
                new Building(6, "45:23:423298:18", "Железнодорожный", "Студенческий", 12, 540, 3, DateTime.Parse("1997-10-30"), new List<PrivatizedBuilding>()),
            };
            return buildings;
        }
    }

    public List<Auction> Auctions
    {
        get
        {
            var auctions = new List<Auction>()
            {
                new Auction(1, DateTime.Parse("2023-02-02"),"Аргентум", new List<PrivatizedBuilding>()),
                new Auction(2, DateTime.Parse("2022-09-11"),"Сириус", new List<PrivatizedBuilding>()),
                new Auction(3, DateTime.Parse("2023-03-03"),"Вечность", new List <PrivatizedBuilding>()),
            };
            return auctions;
        }
    }

    public List<PrivatizedBuilding> PrivatizedBuildings
    {
        get
        {
            var customers = Customers;
            var buildings = Buildings;
            var auctions = Auctions;
            var privatizedBuildings = new List<PrivatizedBuilding>()
            {
                new PrivatizedBuilding(1, DateTime.Parse("2023-02-02"), 100000, 300000, customers[0], auctions[0], buildings[0]),
                new PrivatizedBuilding(2, DateTime.Parse("2023-02-02"), 178000, int.MinValue, null, auctions[0], buildings[2]),
                new PrivatizedBuilding(3, DateTime.Parse("2003-02-02"), 400000, 750000, customers[1], auctions[0], buildings[1]),
                new PrivatizedBuilding(4, DateTime.Parse("2023-03-04"), 560000, 640000, customers[1], auctions[2], buildings[3]),
                new PrivatizedBuilding(5, DateTime.Parse("2023-03-03"), 600000, 650000, customers[2], auctions[2], buildings[2]),
                new PrivatizedBuilding(6, DateTime.Parse("2023-09-11"), 303000, 708000, customers[3], auctions[1], buildings[5]),
                new PrivatizedBuilding(7, DateTime.Parse("2023-09-11"), 3100000, 6700000, customers[5], auctions[1], buildings[4]),
            };

            auctions[0].PrivatizedBuilding.Add(privatizedBuildings[0]);
            auctions[0].PrivatizedBuilding.Add(privatizedBuildings[1]);
            auctions[0].PrivatizedBuilding.Add(privatizedBuildings[2]);
            auctions[1].PrivatizedBuilding.Add(privatizedBuildings[3]);
            auctions[1].PrivatizedBuilding.Add(privatizedBuildings[4]);
            auctions[2].PrivatizedBuilding.Add(privatizedBuildings[5]);
            auctions[2].PrivatizedBuilding.Add(privatizedBuildings[6]);

            buildings[0].PrivatizedBuilding.Add(privatizedBuildings[0]);
            buildings[2].PrivatizedBuilding.Add(privatizedBuildings[1]);
            buildings[1].PrivatizedBuilding.Add(privatizedBuildings[2]);
            buildings[2].PrivatizedBuilding.Add(privatizedBuildings[5]);
            buildings[3].PrivatizedBuilding.Add(privatizedBuildings[6]);
            buildings[4].PrivatizedBuilding.Add(privatizedBuildings[4]);
            buildings[5].PrivatizedBuilding.Add(privatizedBuildings[3]);

            return privatizedBuildings;
        }
    }
}