namespace Shops.Test;

public class TestShop : IClassFixture<ShopFixture>
{
    private readonly ShopFixture _shopFixture;
    public TestShop(ShopFixture shopFixture)
    {
        _shopFixture = shopFixture;
    }


    /// <summary>
    /// 1) Display information about all products in a given store.
    /// </summary>
    [Fact]
    public void ProductInShop()
    {
        var fixtureShop = _shopFixture.ShopsList;
        var query =
            (from shop in fixtureShop
             where shop.Id == 1
             select shop.Products).ToList()[0];
        Assert.Equal(7, query.Count());
    }

    /// <summary>
    /// 2) For a given product, display a list of stores in which it is available.
    /// </summary>
    [Fact]
    public void ProductAvailable()
    {
        var fixtureShop = _shopFixture.ShopsList;
        var query =
            (from shop in fixtureShop
             from products in shop.Products
             where products.Barcode == "1"
             select shop).ToList();
        Assert.Equal(2, query.Count());
    }
    /// <summary>
    /// 3) Output information about the average cost of goods of each product group for each store
    /// </summary>
    [Fact]
    public void AvgPriceProductGroup()
    {
        var fixtureShop = _shopFixture.ShopsList;
        var productList = _shopFixture.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();

        var result =
            (from ps in productInShop
             join p in productList on ps.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.Id
             group new { p, s } by new { p.ProductGroupCode, s.Id } into grp
             select new
             {
                 ShopId = grp.Key.Id,
                 PoductGroup = grp.Key.ProductGroupCode,
                 AvgPrice = grp.Average(x => x.p.Price)
             }
            ).ToList();
        Assert.Equal(16, result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.PoductGroup == 1 && x.AvgPrice == 75.0);
        Assert.Contains(result, x => x.ShopId == 3 && x.PoductGroup == 2 && x.AvgPrice == 224.5);
    }

    /// <summary>
    /// 4) Output the top 5 purchases by the total amount of the sale.
    /// </summary>
    [Fact]
    public void Top5Purchases()
    {
        var customer = _shopFixture.Customers;
        var fixtureShop = _shopFixture.ShopsList;
        var topPurch =
            (from shop in fixtureShop
             from pr in shop.PurchaseRecords
             orderby pr.Sum descending
             select pr
            ).Take(5).ToList();


        Assert.Equal(5, topPurch.Count());
        Assert.Contains(topPurch, x => x.Sum == 2100 && x.Customer.CardCount == customer[4].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 1750 && x.Customer.CardCount == customer[0].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 1400 && x.Customer.CardCount == customer[3].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 1050 && x.Customer.CardCount == customer[1].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 700 && x.Customer.CardCount == customer[4].CardCount);
    }

    /// <summary>
    /// 5) Display all information about goods exceeding the storage limit date,indicating the store.
    /// </summary>
    [Fact]
    public void ProductDelay()
    {
        var fixtureShop = _shopFixture.ShopsList;
        var productList = _shopFixture.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();
        var expiredProduct =
            (from ps in productInShop
             join p in productList on ps.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.Id
             where p.StorageLimitDate < DateTime.Now
             select new
             {
                 ShopId = s.Id,
                 ProductBarcode = p.Barcode,
                 ProductName = p.Name,
             }
            ).ToList();
        Assert.Equal(5, expiredProduct.Count());
        Assert.Contains(expiredProduct, x => x.ProductBarcode == "1" && x.ShopId == 1 && x.ProductName == "Молоко");
        Assert.Contains(expiredProduct, x => x.ProductBarcode == "6" && x.ShopId == 3 && x.ProductName == "Хлеб");
    }

    /// <summary>
    /// 6) Display a list of stores in which goods were sold for a month in excess of the specified amount.
    /// </summary>

    [Fact]
    public void ShopEarnedMore()
    {
        var fixtureShop = _shopFixture.ShopsList;
        var purchases =
           (from shop in fixtureShop
            from pr in shop.PurchaseRecords
            select new
            {
                Shop = shop,
                DateSale = pr.DateSale,
                Sale = pr.Sum
            }
            ).ToList();
        var result =
           (from purchase in purchases
            where purchase.DateSale >= new DateTime(2023, 03, 01) && purchase.DateSale <= new DateTime(2023, 04, 01)
            group purchase by purchase.Shop into sgrp
            select new
            {
                ShopId = sgrp.Key.Id,
                SumSale = sgrp.Sum(purchase => purchase.Sale)
            } into shopSales
            where shopSales.SumSale >= 1400.0
            select new
            {
                ShopId = shopSales.ShopId,
                SumSale = shopSales.SumSale,
            }
            ).ToList();

        Assert.Equal(3, result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.SumSale == 2170);
        Assert.Contains(result, x => x.ShopId == 2 && x.SumSale == 2290);
        Assert.Contains(result, x => x.ShopId == 3 && x.SumSale == 5460);
    }


}