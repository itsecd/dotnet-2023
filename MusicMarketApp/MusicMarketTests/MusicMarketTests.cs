namespace MusicMarketTests;

using System.Linq;

public class MusicMarketTest : IClassFixture<MusicMarketFixture>
{
    private MusicMarketFixture _fixture;

    public MusicMarketTest(MusicMarketFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Первый запрос: Вывести информацию о всех проданных виниловых пластинках.
    /// </summary>
    [Fact]
    public void VinylRecordsInfoTest()
    {
        var fixtureProduct = _fixture.FixtureProducts.ToList();
        var request = (from product in fixtureProduct
                       where (product.TypeOfCarrier == "vinyl record") && (product.Status == "sold")
                       select product).Count();
        Assert.Equal(2, request);
    }

    /// <summary>
    /// Второй запрос: Вывести информацию о всех товарах указанного продавца, упорядочить по цене.
    /// </summary>
    [Fact]
    public void ProductBySeller()
    {
        var fixtureProduct = _fixture.FixtureProducts.ToList();
        var request = (from product in fixtureProduct
                       where (product.IdSeller == 2)
                       orderby product.Price
                       select product).Count();
        Assert.Equal(3, request);
    }
    /// <summary>
    /// Третий запрос: Вывести информацию о продаваемых дисковых изданиях       
    /// альбомов указанного исполнителя, состояние аудионосителя и упаковки 
    /// которых не хуже "хорошее".
    /// </summary>

    [Fact]
    public void GoodDisksInfo()
    {
        var fixtureProduct = _fixture.FixtureProducts.ToList();
        var request = (from product in fixtureProduct
                       where (product.TypeOfCarrier == "disc") && (product.Status == "sale") && (product.PublicationType == "album")
                       && (product.Creator == "Monetochka") && (product.MediaStatus == "new" || product.MediaStatus == "excellent" || product.MediaStatus == "good")
                       select product).Count();


        Assert.Equal(1, request);
    }

    /// <summary>
    /// Четветый запрос: Вывести информацию о количестве проданных на торговой площадке
    /// товаров каждого типа аудионосителя.
    /// </summary>

    [Fact]
    public void AidioCarriersInfo()
    {
        var fixtureProduct = _fixture.FixtureProducts.ToList();
        // диски,
        var request0 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "disc") && (product.Status == "sold")
                        select product).Count();
        // кассеты,
        var request1 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "cassette") && (product.Status == "sold")
                        select product).Count();
        // виниловые пластинки.
        var request2 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "vinyl record") && (product.Status == "sold")
                        select product).Count();

        Assert.Equal(2, request0);
        Assert.Equal(2, request1);
        Assert.Equal(2, request2);
    }

    /// <summary>
    /// Пятый запрос: Вывести информацию о топ 5 покупателях 
    /// по средней стоимости совершенных покупок с учетом стоимости доставки.
    /// </summary>
    [Fact]
    public void TopFiveTest()
    {
        var customers = _fixture.FixtureCustomers.ToList();
        var purchases = _fixture.FixturePurchases.ToList();
        var products = _fixture.FixtureProducts.ToList();
        var sellers = _fixture.FixtureSellers.ToList();

        var customerPurchases =
            from customer in customers
            from purchase in customer.IdPurchase
            select new
            {
                customer.Id,
                PurchaseCost = purchase.Products.Sum(product => product.Price + product.Seller?.Price)
            };
        var customerAvgPurchases =
            from customerPurchase in customerPurchases
            group customerPurchase by customerPurchase.Id into customer
            select new
            {
                customer.Key,
                AvgCost = customer.Average(cust => cust.PurchaseCost)
            };
        var top5 = customerAvgPurchases.OrderBy(customer => customer.AvgCost).Take(5);
        var max = top5.Max(a => a.AvgCost);
        Assert.Equal(7240, max);
    }

    /// <summary>
    /// Шестой запрос: Вывести информацию о количестве проданных товаров каждым продавцом 
    /// за последние две недели.
    /// </summary>

    [Fact]
    public void SoldProducsInTwoWeeks()
    {
        var now = DateTime.Now;


        var purchases = _fixture.FixturePurchases.ToList();

        var request = (from purchase in purchases
                       where purchase.Date >= now.AddDays(-14)
                       select new
                       {
                           seller = purchase.Products[0].IdSeller,
                           count = purchase.Products.Count
                       }).ToList();

        var selCount = (from sel in request
                        group sel by sel.seller.ShopName into g
                        select new
                        {
                            seller = g.Key,
                            count = g.Sum(x => x.count)
                        }).ToList();

        Assert.Equal(1, selCount[0].count);
        Assert.Equal(1, selCount[1].count);
    }


}
