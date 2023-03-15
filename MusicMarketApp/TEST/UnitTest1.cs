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
    /// ������ ������: ������� ���������� � ���� ��������� ��������� ����������.
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
    /// ������ ������: ������� ���������� � ���� ������� ���������� ��������, ����������� �� ����.
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
    /// ������ ������: ������� ���������� � ����������� �������� ��������       
    /// �������� ���������� �����������, ��������� ������������� � �������� 
    /// ������� �� ���� "�������".
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
    /// �������� ������: ������� ���������� � ���������� ��������� �� �������� ��������
    /// ������� ������� ���� �������������.
    /// </summary>

    [Fact]
    public void AidioCarriersInfo()
    {
        var fixtureProduct = _fixture.FixtureProducts.ToList();
        // �����,
        var request0 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "disc") && (product.Status == "sold")
                        select product).Count();
        // �������,
        var request1 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "cassette") && (product.Status == "sold")
                        select product).Count();
        // ��������� ���������.
        var request2 = (from product in fixtureProduct
                        where (product.TypeOfCarrier == "vinyl record") && (product.Status == "sold")
                        select product).Count();

        Assert.Equal(2, request0);
        Assert.Equal(2, request1);
        Assert.Equal(2, request2);
    }

    /// <summary>
    /// ����� ������: ������� ���������� � ��� 5 ����������� 
    /// �� ������� ��������� ����������� ������� � ������ ��������� ��������.
    /// </summary>
    //[Fact]
    public void TopFiveTest()
    {
        var customers = _fixture.Fixture�ustomers.ToList();

        var request = (from customer in customers


                       orderby customer.count descending
                       select customer).Take(5).ToList();

        Assert.Equal(5, request.Count());
    }

    /// <summary>
    /// ������ ������: ������� ���������� � ���������� ��������� ������� ������ ��������� 
    /// �� ��������� ��� ������.
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