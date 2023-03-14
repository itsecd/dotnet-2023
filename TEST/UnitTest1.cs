namespace TEST;

using System.Linq;



public class MusicMarketTest : IClassFixture<MusicMarketFixture>
{
    private readonly MusicMarketFixture _fixture;
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
        //var fixtureProduct = _fixture.FixtureProducts.ToList();
        var request = (from product in _fixture.FixtureProducts
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
        var request = (from product in _fixture.FixtureProducts
                       where (product.Seller.ShopName == "StopRobot")
                       orderby product.Price
                       select product).Count();
        Assert.Equal(3, request);
    }

    
}