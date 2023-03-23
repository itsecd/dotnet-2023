namespace xUnitTest;

public class TestShop : IClassFixture<ShopFixture>
{
    private readonly ShopFixture _shopFixtture;
    public TestShop(ShopFixture shopFixtture)
    {
        _shopFixtture = shopFixtture;
    }


    /// <summary>
    /// 1) Display information about all products in a given store.
    /// </summary>
    [Fact]
    public void ProductInShop()
    {
        var fixtureShop = _shopFixtture.Shops;
        var query =
            (from shop in fixtureShop
             where shop.ShopId == 1
             select shop.Products).ToList()[0];
        Assert.Equal(7, query.Count());
    }

    /// <summary>
    /// 2) For a given product, display a list of stores in which it is available.
    /// </summary>
    [Fact]
    public void ProductAvailable()
    {
        var fixtureShop = _shopFixtture.Shops;
        var query =
            (from shop in fixtureShop
             from products in shop.Products
             where products.Product.Barcode == "1"
             select shop).ToList();
        Assert.Equal(2, query.Count());
    }
    /// <summary>
    /// 3) Output information about the average cost of goods of each product group for each store
    /// </summary>
    [Fact]
    public void AvgPriceProductGroup()
    {
        var fixtureShop = _shopFixtture.Shops;
        var productList = _shopFixtture.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();

        var result =
            (from ps in productInShop
             join p in productList on ps.Product.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.ShopId
             group new { p, s } by new { p.ProductGroupCode, s.ShopId } into grp
             select new
             {
                 ShopId = grp.Key.ShopId,
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
        var customer = _shopFixtture.Customers;
        var fixtureShop = _shopFixtture.Shops;
        var topPurch =
            (from shop in fixtureShop
             from pr in shop.PurchaseRecords
             orderby pr.Sum descending
             select pr
            ).Take(5).ToList();


        Assert.Equal(5, topPurch.Count());
        Assert.Contains(topPurch, x => x.Sum == 1100 && x.Customer.CardCount == customer[0].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 990 && x.Customer.CardCount == customer[0].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 900 && x.Customer.CardCount == customer[3].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 800 && x.Customer.CardCount == customer[2].CardCount);
        Assert.Contains(topPurch, x => x.Sum == 470 && x.Customer.CardCount == customer[4].CardCount);
    }

    /// <summary>
    /// 5) Display all information about goods exceeding the storage limit date,indicating the store.
    /// </summary>
    [Fact]
    public void ProductDelay()
    {
        var fixtureShop = _shopFixtture.Shops;
        var productList = _shopFixtture.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();
        var expiredProduct =
            (from ps in productInShop
             join p in productList on ps.Product.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.ShopId
             where p.StorageLimitDate < DateTime.Now
             select new
             {
                 ShopId = s.ShopId,
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
        var fixtureShop = _shopFixtture.Shops;
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
                ShopId = sgrp.Key.ShopId,
                SumSale = sgrp.Sum(purchase => purchase.Sale)
            } into shopSales
            where shopSales.SumSale >= 1400.0
            select new
            {
                ShopId = shopSales.ShopId,
                SumSale = shopSales.SumSale,
            }
            ).ToList();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.SumSale == 1400);
        Assert.Contains(result, x => x.ShopId == 3 && x.SumSale == 1790);
    }


}