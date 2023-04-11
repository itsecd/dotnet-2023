using MusicMarket;

namespace MusicMarketServer.Repository;

public class MusicMarketRepository : IMusicMarketRepository
{

    private readonly List<Customer> _customers;
    private readonly List<Seller> _sellers;
    private readonly List<Purchase> _purchases;
    private readonly List<Product> _products;

    public MusicMarketRepository()
    {
        _products = new List<Product>();

        for (var i = 0; i < 8; ++i)
        {
            _products.Add(new Product());
            _products[i].Id = i;
        }

        _products[0].Name = "The Curse of the Seas";
        _products[1].Name = "Decorative and applied art";
        _products[2].Name = "Aurora";
        _products[3].Name = "Forgive Me My Love";
        _products[4].Name = "Smoke + Mirrors";
        _products[5].Name = "Let Go";
        _products[6].Name = "PWR/UP";
        _products[7].Name = "Rush!";

        _products[0].TypeOfCarrier = "cassette";
        _products[1].TypeOfCarrier = "disc";
        _products[2].TypeOfCarrier = "vinyl record";
        _products[3].TypeOfCarrier = "disc";
        _products[4].TypeOfCarrier = "cassette";
        _products[5].TypeOfCarrier = "vinyl record";
        _products[6].TypeOfCarrier = "cassette";
        _products[7].TypeOfCarrier = "disc";

        _products[0].PublicationType = "album";
        _products[1].PublicationType = "album";
        _products[2].PublicationType = "album";
        _products[3].PublicationType = "single";
        _products[4].PublicationType = "album";
        _products[5].PublicationType = "single";
        _products[6].PublicationType = "album";
        _products[7].PublicationType = "album";

        _products[0].Creator = "Aria";
        _products[1].Creator = "Monetochka";
        _products[2].Creator = "Leningrad";
        _products[3].Creator = "Zemfira";
        _products[4].Creator = "Imagine Dragons";
        _products[5].Creator = "Avril Lavigne";
        _products[6].Creator = "AC/DC";
        _products[7].Creator = "Maneskin";

        _products[0].MadeIn = "Russia";
        _products[1].MadeIn = "Russia";
        _products[2].MadeIn = "Russia";
        _products[3].MadeIn = "Russia";
        _products[4].MadeIn = "USA";
        _products[5].MadeIn = "UK & Europe";
        _products[6].MadeIn = "EU";
        _products[7].MadeIn = "UK & Europe";

        _products[0].MediaStatus = "bad";
        _products[1].MediaStatus = "new";
        _products[2].MediaStatus = "excellent";
        _products[3].MediaStatus = "satisfactory";
        _products[4].MediaStatus = "excellent";
        _products[5].MediaStatus = "good";
        _products[6].MediaStatus = "excellent";
        _products[7].MediaStatus = "new";

        _products[0].PackagingCondition = "satisfactory";
        _products[1].PackagingCondition = "new";
        _products[2].PackagingCondition = "good";
        _products[3].PackagingCondition = "bad";
        _products[4].PackagingCondition = "excellent";
        _products[5].PackagingCondition = "excellent";
        _products[6].PackagingCondition = "good";
        _products[7].PackagingCondition = "new";

        _products[0].Price = 1750;
        _products[1].Price = 4890;
        _products[2].Price = 3750;
        _products[3].Price = 1190;
        _products[4].Price = 6490;
        _products[5].Price = 5990;
        _products[6].Price = 3990;
        _products[7].Price = 4990;

        _products[0].Status = "sale";
        _products[1].Status = "sale";
        _products[2].Status = "sold";
        _products[3].Status = "sold";
        _products[4].Status = "sold";
        _products[5].Status = "sold";
        _products[6].Status = "sold";
        _products[7].Status = "sold";

        _products[0].Seller = new Seller(0, "Muzzona", "Russia", 300);
        _products[1].Seller = new Seller(1, "Muzzona", "Russia", 300);
        _products[2].Seller = new Seller(2, "Muzzona", "Russia", 300);
        _products[3].Seller = new Seller(3, "Muzzona", "Russia", 300);
        _products[4].Seller = new Seller(4, "Skifmusic", "UK", 750);
        _products[5].Seller = new Seller(5, "StopRobot", "USA", 680);
        _products[6].Seller = new Seller(6, "StopRobot", "USA", 680);
        _products[7].Seller = new Seller(7, "StopRobot", "USA", 680);

        _products[0].SellerId = 0;
        _products[1].SellerId = 0;
        _products[2].SellerId = 0;
        _products[3].SellerId = 0;
        _products[4].SellerId = 1;
        _products[5].SellerId = 2;
        _products[6].SellerId = 2;
        _products[7].SellerId = 2;


        _sellers = new List<Seller>();

        for (var i = 0; i < 3; ++i)
        {
            _sellers.Add(new Seller());
            _sellers[i].Id = i;
        }

        _sellers[0].ShopName = "Muzzona";
        _sellers[1].ShopName = "Skifmusic";
        _sellers[2].ShopName = "StopRobot";

        _sellers[0].CountryOfDelivery = "Russia";
        _sellers[1].CountryOfDelivery = "UK";
        _sellers[2].CountryOfDelivery = "USA";

        _sellers[0].Price = 300;
        _sellers[1].Price = 750;
        _sellers[2].Price = 680;

        _sellers[0].Products.Add(_products[0]);
        _sellers[0].Products.Add(_products[1]);
        _sellers[0].Products.Add(_products[2]);
        _sellers[0].Products.Add(_products[3]);
        _sellers[1].Products.Add(_products[4]);
        _sellers[2].Products.Add(_products[5]);
        _sellers[2].Products.Add(_products[6]);
        _sellers[2].Products.Add(_products[7]);


        _purchases = new List<Purchase>();
        for (var i = 0; i < 5; ++i)
        {
            _purchases.Add(new Purchase());
            _purchases[i].Id = i;
        }

        _purchases[0].Products.Add(_products[7]);
        _purchases[1].Products.Add(_products[3]);
        _purchases[2].Products.Add(_products[4]);
        _purchases[3].Products.Add(_products[5]);
        _purchases[4].Products.Add(_products[6]);

        _purchases[0].Date = DateTime.Parse("2023/04/11");
        _purchases[1].Date = DateTime.Parse("2023/04/4");
        _purchases[2].Date = DateTime.Parse("2023/04/9");
        _purchases[3].Date = DateTime.Parse("2023/04/10");
        _purchases[4].Date = DateTime.Parse("2023/04/11");

        _customers = new List<Customer>();
        for (var i = 0; i < 5; ++i)
        {
            _customers.Add(new Customer());
            _customers[i].Id = i;
        }


        _customers[0].Name = "Tikhonov Mark Sergeevich";
        _customers[1].Name = "Klimova Sofya Dmitrievna";
        _customers[2].Name = "Jason Knight";
        _customers[3].Name = "David Bush";
        _customers[4].Name = "Vasiliev Yaroslav Olegovich";

        _customers[0].Country = "Switzerland";
        _customers[1].Country = "Russia";
        _customers[2].Country = "USA";
        _customers[3].Country = "France";
        _customers[4].Country = "Russia";

        _customers[0].Address = "Aubonnestr. 18c 2672 Sembrancher";
        _customers[1].Address = "522625, Kaliningrad region, the city of Pavlovsky Posad, Domodedovo str., 94";
        _customers[2].Address = "9297 Graham Spur Apt. 585 Gaylordbury, LA 91851";
        _customers[3].Address = "8, avenue de Coste 24798 Costa";
        _customers[4].Address = "179817, Ulyanovsk region, Krasnogorsk, Lenin Square, 23";

        _customers[0].Purchases.Add(_purchases[0]);
        _customers[1].Purchases.Add(_purchases[1]);
        _customers[2].Purchases.Add(_purchases[2]);
        _customers[3].Purchases.Add(_purchases[3]);
        _customers[4].Purchases.Add(_purchases[4]);
    }

    public List<Customer> Customers => _customers;
    public List<Seller> Sellers => _sellers;
    public List<Purchase> Purchases => _purchases;
    public List<Product> Products => _products;

}

