namespace MusicMarketTests;

using MusicMarket;
using System.Collections.Generic;
using System;

public class MusicMarketFixture
{
    /// <summary>
    /// Returns the list of products in a Market
    /// </summary>
    public List<Product> FixtureProducts
    {
        get
        {
            var Products = new List<Product>();

            var product0 = new Product();
            var product1 = new Product();
            var product2 = new Product();
            var product3 = new Product();
            var product4 = new Product();
            var product5 = new Product();
            var product6 = new Product();
            var product7 = new Product();

            product0.Id = 0;
            product1.Id = 1;
            product2.Id = 2;
            product3.Id = 3;
            product4.Id = 4;
            product5.Id = 5;
            product6.Id = 6;
            product7.Id = 7;

            product0.Name = "The Curse of the Seas" ;
            product1.Name = "Decorative and applied art";
            product2.Name = "Aurora";
            product3.Name = "Forgive Me My Love";
            product4.Name = "Smoke + Mirrors";
            product5.Name = "Let Go";
            product6.Name = "PWR/UP";
            product7.Name = "Rush!";

            product0.TypeOfCarrier = "disc";
            product1.TypeOfCarrier = "cassette";
            product2.TypeOfCarrier = "vinyl record";
            product3.TypeOfCarrier = "disc";
            product4.TypeOfCarrier = "cassette";
            product5.TypeOfCarrier = "vinyl record";
            product6.TypeOfCarrier = "cassette";
            product7.TypeOfCarrier = "disc";

            product0.PublicationType = "album";
            product1.PublicationType = "single";
            product2.PublicationType = "album";
            product3.PublicationType = "single";
            product4.PublicationType = "album";
            product5.PublicationType = "single";
            product6.PublicationType = "album";
            product7.PublicationType = "single";

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

            product0.Seller = Sellers[0];
            product1.Seller = Sellers[0];
            product2.Seller = Sellers[0];
            product3.Seller = Sellers[0];
            product4.Seller = Sellers[1];
            product5.Seller = Sellers[2];
            product6.Seller = Sellers[2];
            product7.Seller = Sellers[2];

            Products.Add(product0);
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);
            Products.Add(product5);
            Products.Add(product6);
            Products.Add(product7);

            return Products;
        }
    }

    public List<Seller> FixtureSellers
    {
        get
        {
            var Products = FixtureProducts;

            var Sellers = new List<Seller>();
            var seller0 = new Seller();
            var seller1 = new Seller();
            var seller2 = new Seller();

            seller0.Id = 0;
            seller1.Id = 1;
            seller2.Id = 2;

            seller0.ShopName = "Muzzona";
            seller1.ShopName = "Skifmusic";
            seller2.ShopName = "StopRobot";

            seller0.CountryOfDelivery = "Russia";
            seller1.CountryOfDelivery = "UK" ;
            seller2.CountryOfDelivery = "USA";

            seller0.Price = 300;
            seller1.Price = 750;
            seller2.Price = 680;

            seller0.Products.Add(Products[0]);
            seller0.Products.Add(Products[1]);
            seller0.Products.Add(Products[2]);
            seller0.Products.Add(Products[3]);
            seller1.Products.Add(Products[4]);
            seller2.Products.Add(Products[5]);
            seller2.Products.Add(Products[6]);
            seller2.Products.Add(Products[7]);
            

            Sellers.Add(seller0);
            Sellers.Add(seller1);
            Sellers.Add(seller2);
            
            return Sellers;
        }
    }

    public List<Purchase> FixturePurchases
    {
        get
        {
            var Products = FixtureProducts;

            var Purchases = new List<Purchase>();

            var purchase0 = new Purchase();
            var purchase1 = new Purchase();
            var purchase2 = new Purchase();
            var purchase4 = new Purchase();
            var purchase3 = new Purchase();
            

            purchase0.Id = 0;
            purchase1.Id = 1;
            purchase2.Id = 2;
            purchase3.Id = 3;
            purchase4.Id = 4;


            purchase0.Products.Add(Products[7]);
            purchase1.Products.Add(Products[3]);
            purchase2.Products.Add(Products[4]);
            purchase3.Products.Add(Products[5]);
            purchase4.Products.Add(Products[6]);

            purchase0.Date = 25.03.2022 8:44:23; 
            purchase1.Date = 10.08.2022 11:31:56; 
            purchase2.Date = 12.02.2023 19:20:29;
            purchase3.Date = 21.10.2022 13:46:41;
            purchase4.Date = 7.09.2023 22:10:33;

            Purchases.Add(purchase0);
            Purchases.Add(purchase1);
            Purchases.Add(purchase2);
            Purchases.Add(purchase3);
            Purchases.Add(purchase4);
            return Purchases;
        }
    }

    public List<—ustomer> Fixture—ustomers
    {
        get
        {

            var —ustomers = new List<—ustomer>();
            var customer0 = new —ustomer();
            var customer1= new —ustomer();
            var customer2 = new —ustomer();
            var customer3 = new —ustomer();
            var customer4 = new —ustomer();

            customer0.Id = 0;
            customer1.Id = 1;
            customer2.Id = 2;
            customer3.Id = 3;
            customer4.Id = 4;


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
         
            customer0.Adress = "Aubonnestr. 18c 2672 Sembrancher";
            customer1.Adress = "522625, Kaliningrad region, the city of Pavlovsky Posad, Domodedovo str., 94";
            customer2.Adress = "9297 Graham Spur Apt. 585 Gaylordbury, LA 91851";
            customer3.Adress = "8, avenue de Coste 24798 Costa";
            customer4.Adress = "179817, Ulyanovsk region, Krasnogorsk, Lenin Square, 23";

            customer0.Purchases.Add(Purchases[0]);
            customer1.Purchases.Add(Purchases[1]);
            customer2.Purchases.Add(Purchases[2]);
            customer3.Purchases.Add(Purchases[3]);
            customer4.Purchases.Add(Purchases[4]);

            —ustomers.Add(customer0);
            —ustomers.Add(customer1);
            —ustomers.Add(customer2);
            —ustomers.Add(customer3;
            —ustomers.Add(customer4);

            return —ustomers;
        }
    }
    
}
