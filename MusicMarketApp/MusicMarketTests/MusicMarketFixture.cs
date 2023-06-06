namespace MusicMarketTests;

using MusicMarketplace;
using System;
using System.Collections.Generic;

public class MusicMarketFixture
{
    /// <summary>
    /// Returns the list of products in a Market
    /// </summary>
    public List<Product> FixtureProducts
    {
        get
        {
            var products = new List<Product>();

            var product0 = new Product();
            var product1 = new Product();
            var product2 = new Product();
            var product3 = new Product();
            var product4 = new Product();
            var product5 = new Product();
            var product6 = new Product();
            var product7 = new Product();

            product0.Id = 1;
            product1.Id = 2;
            product2.Id = 3;
            product3.Id = 4;
            product4.Id = 5;
            product5.Id = 6;
            product6.Id = 7;
            product7.Id = 8;

            product0.Name = "The Curse of the Seas";
            product1.Name = "Decorative and applied art";
            product2.Name = "Aurora";
            product3.Name = "Forgive Me My Love";
            product4.Name = "Smoke + Mirrors";
            product5.Name = "Let Go";
            product6.Name = "PWR/UP";
            product7.Name = "Rush!";

            product0.TypeOfCarrier = "cassette";
            product1.TypeOfCarrier = "disc";
            product2.TypeOfCarrier = "vinyl record";
            product3.TypeOfCarrier = "disc";
            product4.TypeOfCarrier = "cassette";
            product5.TypeOfCarrier = "vinyl record";
            product6.TypeOfCarrier = "cassette";
            product7.TypeOfCarrier = "disc";

            product0.PublicationType = "album";
            product1.PublicationType = "album";
            product2.PublicationType = "album";
            product3.PublicationType = "single";
            product4.PublicationType = "album";
            product5.PublicationType = "single";
            product6.PublicationType = "album";
            product7.PublicationType = "album";

            product0.Creator = "Aria";
            product1.Creator = "Monetochka";
            product2.Creator = "Leningrad";
            product3.Creator = "Zemfira";
            product4.Creator = "Imagine Dragons";
            product5.Creator = "Avril Lavigne";
            product6.Creator = "AC/DC";
            product7.Creator = "Maneskin";

            product0.MadeIn = "Russia";
            product1.MadeIn = "Russia";
            product2.MadeIn = "Russia";
            product3.MadeIn = "Russia";
            product4.MadeIn = "USA";
            product5.MadeIn = "UK & Europe";
            product6.MadeIn = "EU";
            product7.MadeIn = "UK & Europe";

            product0.MediaStatus = "bad";
            product1.MediaStatus = "new";
            product2.MediaStatus = "excellent";
            product3.MediaStatus = "satisfactory";
            product4.MediaStatus = "excellent";
            product5.MediaStatus = "good";
            product6.MediaStatus = "excellent";
            product7.MediaStatus = "new";

            product0.PackagingCondition = "satisfactory";
            product1.PackagingCondition = "new";
            product2.PackagingCondition = "good";
            product3.PackagingCondition = "bad";
            product4.PackagingCondition = "excellent";
            product5.PackagingCondition = "excellent";
            product6.PackagingCondition = "good";
            product7.PackagingCondition = "new";

            product0.Price = 1750;
            product1.Price = 4890;
            product2.Price = 3750;
            product3.Price = 1190;
            product4.Price = 6490;
            product5.Price = 5990;
            product6.Price = 3990;
            product7.Price = 4990;

            product0.Status = "sale";
            product1.Status = "sale";
            product2.Status = "sold";
            product3.Status = "sold";
            product4.Status = "sold";
            product5.Status = "sold";
            product6.Status = "sold";
            product7.Status = "sold";

            product0.IdSeller = 1;
            product1.IdSeller = 1;
            product2.IdSeller = 1;
            product3.IdSeller = 1;
            product4.IdSeller = 2;
            product5.IdSeller = 3;
            product6.IdSeller = 3;
            product7.IdSeller = 3;

            products.Add(product0);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);

            return products;
        }
    }

    public List<Seller> FixtureSellers
    {
        get
        {
            var products = FixtureProducts;

            var sellers = new List<Seller>();
            var seller0 = new Seller();
            var seller1 = new Seller();
            var seller2 = new Seller();

            seller0.Id = 1;
            seller1.Id = 2;
            seller2.Id = 3;

            seller0.ShopName = "Muzzona";
            seller1.ShopName = "Skifmusic";
            seller2.ShopName = "StopRobot";

            seller0.CountryOfDelivery = "Russia";
            seller1.CountryOfDelivery = "UK";
            seller2.CountryOfDelivery = "USA";

            seller0.Price = 300;
            seller1.Price = 750;
            seller2.Price = 680;

            sellers.Add(seller0);
            sellers.Add(seller1);
            sellers.Add(seller2);

            return sellers;
        }
    }

    public List<Purchase> FixturePurchases
    {
        get
        {
            var products = FixtureProducts;

            var purchases = new List<Purchase>();

            var purchase0 = new Purchase();
            var purchase1 = new Purchase();
            var purchase2 = new Purchase();
            var purchase4 = new Purchase();
            var purchase3 = new Purchase();


            purchase0.Id = 1;
            purchase1.Id = 2;
            purchase2.Id = 3;
            purchase3.Id = 4;
            purchase4.Id = 5;


            purchase0.IdProduct = 7;
            purchase1.IdProduct = 3;
            purchase2.IdProduct = 4;
            purchase3.IdProduct = 5;
            purchase4.IdProduct = 6;

            purchase0.IdCustomer = 1;
            purchase1.IdProduct = 2;
            purchase2.IdProduct = 3;
            purchase3.IdProduct = 4;
            purchase4.IdProduct = 5;

            purchase0.Date = DateTime.Parse("2023/05/21");
            purchase1.Date = DateTime.Parse("2023/05/4");
            purchase2.Date = DateTime.Parse("2023/05/9");
            purchase3.Date = DateTime.Parse("2023/05/19");
            purchase4.Date = DateTime.Parse("2023/05/11");

            purchases.Add(purchase0);
            purchases.Add(purchase1);
            purchases.Add(purchase2);
            purchases.Add(purchase3);
            purchases.Add(purchase4);
            return purchases;
        }
    }

    public List<Customer> FixtureCustomers
    {
        get
        {
            var purchases = FixturePurchases;
            var customers = new List<Customer>();
            var customer0 = new Customer();
            var customer1 = new Customer();
            var customer2 = new Customer();
            var customer3 = new Customer();
            var customer4 = new Customer();

            customer0.Id = 1;
            customer1.Id = 2;
            customer2.Id = 3;
            customer3.Id = 4;
            customer4.Id = 5;


            customer0.Name = "Tikhonov Mark Sergeevich";
            customer1.Name = "Klimova Sofya Dmitrievna";
            customer2.Name = "Jason Knight";
            customer3.Name = "David Bush";
            customer4.Name = "Vasiliev Yaroslav Olegovich";

            customer0.Country = "Switzerland";
            customer1.Country = "Russia";
            customer2.Country = "USA";
            customer3.Country = "France";
            customer4.Country = "Russia";

            customer0.Address = "Aubonnestr. 18c 2672 Sembrancher";
            customer1.Address = "522625, Kaliningrad region, the city of Pavlovsky Posad, Domodedovo str., 94";
            customer2.Address = "9297 Graham Spur Apt. 585 Gaylordbury, LA 91851";
            customer3.Address = "8, avenue de Coste 24798 Costa";
            customer4.Address = "179817, Ulyanovsk region, Krasnogorsk, Lenin Square, 23";


            customers.Add(customer0);
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            customers.Add(customer4);

            return customers;
        }
    }

}
