namespace xUnitTest;

public class TestShop : IClassFixture<ShopFixtture>
{
    private readonly ShopFixtture _shopFixtture;
    public TestShop(ShopFixtture shopFixtture)
    {
        _shopFixtture = shopFixtture;
    }


    /// <summary>
    /// 1) ¬ывести сведени€ о всех товарах в заданном магазине.
    /// 1) Display information about all products in a given store.
    /// </summary>
    [Fact]
    public void Test1()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var query =
            (from shop in fixtureShop
             where shop.ShopId == 1
             select shop.Products).ToList()[0];
        Assert.Equal(7, query.Count());
    }

    /// <summary>
    /// 2) ƒл€ заданного товара вывести список магазинов, в котором он находитс€ в наличии.
    /// 2) For a given product, display a list of stores in which it is available.
    /// </summary>
    [Fact]
    public void Test2()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var query =
            (from shop in fixtureShop
             from Products in shop.Products
             where Products.Barcode == "1"
             select shop).ToList();
        Assert.Equal(2, query.Count());
    }
    /// <summary>
    /// 3) ¬ывести информацию о средней стоимости товаров каждой товарной группы дл€ каждого магазина.
    /// 3) Output information about the average cost of goods of each product group for each store
    /// </summary>
    [Fact]
    public void Test3()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var productList = _shopFixtture.Products.ToList();
        var prodectinshop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();

        var result =
            (from ps in prodectinshop
             join p in productList on ps.Barcode equals p.Barcode
             join s in fixtureShop on ps.ShopId equals s.ShopId
             group new { p, s } by new { p.PoductGroupCode, s.ShopId } into grp
             select new
             {
                 ShopId = grp.Key.ShopId,
                 PoductGroup = grp.Key.PoductGroupCode,
                 AvgPrice = grp.Average(x => x.p.Price)
             }
            ).ToList();
        Assert.Equal(16, result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.PoductGroup == 1 && x.AvgPrice == 75.0);
        Assert.Contains(result, x => x.ShopId == 3 && x.PoductGroup == 2 && x.AvgPrice == 224.5);
    }

    /// <summary>
    /// 4) ¬ывести топ 5 покупок по общей сумме продажи.
    /// 4) Output the top 5 purchases by the total amount of the sale.
    /// </summary>
    [Fact]
    public void Test4()
    {
        var customer = _shopFixtture.Customers.ToList();
        var fixtureShop = _shopFixtture.Shops.ToList();
        var toppurch =
            (from shop in fixtureShop
             from pr in shop.PurchaseRecords
             orderby pr.Sum descending
             select pr
            ).Take(5).ToList();


        Assert.Equal(5, toppurch.Count());
        Assert.Contains(toppurch, x => x.Sum == 1100 && x.Customer.CardCount == customer[0].CardCount);
        Assert.Contains(toppurch, x => x.Sum == 990 && x.Customer.CardCount == customer[0].CardCount);
        Assert.Contains(toppurch, x => x.Sum == 900 && x.Customer.CardCount == customer[3].CardCount);
        Assert.Contains(toppurch, x => x.Sum == 800 && x.Customer.CardCount == customer[2].CardCount);
        Assert.Contains(toppurch, x => x.Sum == 470 && x.Customer.CardCount == customer[4].CardCount);
    }

    /// <summary>
    /// 5) ¬ывести все сведени€ о товарах, превышающих предельную дату хранени€, с указанием магазина.
    /// 5) Display all information about goods exceeding the storage limit date,indicating the store.
    /// </summary>
    [Fact]
    public void Test5()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
        var productList = _shopFixtture.Products.ToList();
        var prodectinshop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();
        var expiredProduct =
            (from ps in prodectinshop
             join p in productList on ps.Barcode equals p.Barcode
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
        Assert.Contains(expiredProduct, x => x.ProductBarcode == "1" && x.ShopId == 1 && x.ProductName == "ћолоко");
        Assert.Contains(expiredProduct, x => x.ProductBarcode == "6" && x.ShopId == 3 && x.ProductName == "’леб");
    }

    /// <summary>
    /// 6) ¬ывести список магазинов, в которых за мес€ц было продано товаров на сумму, превышающую заданную.
    /// 6) Display a list of stores in which goods were sold for a month in excess of the specified amount.
    /// </summary>

    [Fact]
    public void Test6()
    {
        var fixtureShop = _shopFixtture.Shops.ToList();
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
            } into ShopSales
            where ShopSales.SumSale >= 1400.0
            select new
            {
                ShopId = ShopSales.ShopId,
                SumSale = ShopSales.SumSale,
            }
            ).ToList();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.ShopId == 1 && x.SumSale == 1400);
        Assert.Contains(result, x => x.ShopId == 3 && x.SumSale == 1790);
    }


}