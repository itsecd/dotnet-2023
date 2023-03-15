namespace TEST;

using MusicMarket;
using System.Linq;
using System.Net.WebSockets;

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
                       where (product.Seller != null && product.Seller.ShopName == "StopRobot")
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
    //[Fact]
    //public void TopFiveTest()
    //{
    //var tickets = (from flight in _fixture.FixtureFlights
    //               from ticket in flight.Tickets
    //               where flight.Source == "Moscow"
    //               select ticket.BaggageWeight).ToList();
    //var max = tickets.Max();
    //var avg = tickets.Average();


    //    var fixtureCard = _fixture.FixtureCard.ToList();
    //    var date = new DateOnly(2023, 3, 1);
    //    var numOfReaders = (from card in fixtureCard
    //                        from reader in card.IdReader
    //                        where card.DateOfReturn < date
    //                        group card by reader.Id into g
    //                        select new
    //                        {
    //                            readers = g.Key,
    //                            count = g.Count()
    //                        }).ToList();
    //    var request = (from reader in numOfReaders
    //                   orderby reader.count descending
    //                   select reader).Take(5).ToList();
    //    var first = request.First();

    //    Assert.Equal(1, first.readers);
    //    Assert.Equal(5, request.Count);
    //}

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
                           seller = purchase.Products[0].Seller,
                           count = purchase.Products.Count
                       }).ToList();

        var selCount = (from sel in request
                        group sel by sel.seller.ShopName into g
                        select new
                        {
                            seller = g.Key,
                            count = g.Sum(x => x.count)
                        }).ToList();

        Assert.Equal(2, selCount[0].count);
        Assert.Equal(1, selCount[1].count);
    }


}