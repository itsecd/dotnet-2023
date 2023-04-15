namespace Warehouse.Test;
using System.Linq;

public class WarehouseTestsClass : IClassFixture<WarehouseFixture>
{
    private readonly WarehouseFixture _fixture;
    public WarehouseTestsClass(WarehouseFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    ///     First request - display information about the company's products, sorted by product name
    /// </summary>
    [Fact]
    public void FirstRequestTest()
    {
        var allGoods = _fixture.GoodsFixture;
        var goods = (from product in allGoods
                     orderby product.Name
                     select product).ToList();

        Assert.Equal(8, goods.Count);
        Assert.Equal("Ваза из стекла 3л", goods[0].Name);
        Assert.Equal("Ваза из стекла 4л", goods[1].Name);
        Assert.Equal("Вилка из нерж. стали", goods[2].Name);
        Assert.Equal("Гипсовая штукатурка 5кг", goods[3].Name);
        Assert.Equal("Картонная коробка 60*40*50", goods[4].Name);
        Assert.Equal("Контейнер 640мл с крышкой", goods[5].Name);
        Assert.Equal("Пищевая плёнка для упаковки 5м", goods[6].Name);
        Assert.Equal("Столовая ложка из нерж. стали", goods[7].Name);
    }
    /// <summary>
    ///     Second request - display information about the company's products received on the specified day by the recipient of products
    /// </summary>
    [Fact]
    public void SecondRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture
                     from supply in goods.Supply
                     where supply.SupplyDate == new DateTime(2023, 02, 11)
                     select goods).ToList();

        Assert.Equal(2, query.Count);
        Assert.Contains(query, queryElem => queryElem.Name == "Столовая ложка из нерж. стали");
        Assert.Contains(query, queryElem => queryElem.Id == 319510);
        Assert.Contains(query, queryElem => queryElem.Name == "Пищевая плёнка для упаковки 5м");
        Assert.Contains(query, queryElem => queryElem.Id == 106932);
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Контейнер 640мл с крышкой");
        Assert.DoesNotContain(query, queryElem => queryElem.Id == 103722);
    }
    /// <summary>
    ///     Third request - display the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    [Fact]
    public void ThirdRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture
                     from cell in goods.WarehouseCell
                     orderby cell.CellNumber
                     select new { number = cell.CellNumber, goodsTitle = goods.Name, goodsCount = goods.ProductCount }).ToList();

        Assert.Equal(11, query.Count);
        Assert.Equal("Контейнер 640мл с крышкой", query[0].goodsTitle);
        Assert.Equal("Ваза из стекла 3л", query[7].goodsTitle);
        Assert.True(query[0].goodsCount == 100);
        Assert.True(query[9].goodsCount == 10);
    }
    /// <summary>
    ///     Fourt request - display information about the organizations that received the maximum volume products for a given period
    /// </summary>
    [Fact]
    public void FourthRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture
                     from supply in goods.Supply
                     where supply.SupplyDate > new DateTime(2023, 02, 1) && supply.SupplyDate < new DateTime(2023, 03, 15)
                     group supply by new
                     {
                         supply.CompanyName,
                         supply.CompanyAddress
                     } into grp
                     select new
                     {
                         grp.Key.CompanyName,
                         grp.Key.CompanyAddress,
                         goodsCount = grp.Sum(x => x.SupplyCount)
                     }).ToList();

        var max = query.Max(x => x.goodsCount);
        foreach (var q in query)
        {
            if (q.goodsCount == max)
            {
                Assert.Equal("Fix Price", q.CompanyName);
                Assert.Equal("г. Самара, ул. Спортивная, 20.", q.CompanyAddress);
            }
        }
    }
    /// <summary>
    ///     Fifth request - display the top 5 products by stock availability
    /// </summary>
    [Fact]
    public void FifthRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture
                     orderby goods.ProductCount descending
                     select goods).Take(5).ToList();

        Assert.Equal(5, query.Count);
        Assert.True(query[0].ProductCount == 100);
        Assert.True(query[1].ProductCount == 50);
        Assert.True(query[2].ProductCount == 35);
        Assert.True(query[3].ProductCount == 25);
        Assert.True(query[4].ProductCount == 15);
    }
    /// <summary>
    ///     Sixth request - display information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    [Fact]
    public void SixthRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture
                     from supply in goods.Supply
                     group supply by new
                     {
                         supply.CompanyName,
                         supply.CompanyAddress,
                         goods.Id,
                         goods.Name
                     } into grp
                     select new
                     {
                         grp.Key.CompanyName,
                         grp.Key.CompanyAddress,
                         grp.Key.Id,
                         grp.Key.Name,
                         quntity = grp.Sum(x => x.SupplyCount)
                     }).ToList();

        Assert.Equal(4, query.Count);
        Assert.Contains(query, queryElem => queryElem.Id == 103722);
        Assert.Contains(query, queryElem => queryElem.Id == 218302);
        Assert.Contains(query, queryElem => queryElem.Id == 319510);
        Assert.Contains(query, queryElem => queryElem.Id == 106932);
        Assert.Contains(query, queryElem => queryElem.CompanyAddress == "г. Самара, ул. Луцкая, 16.");
        Assert.Contains(query, queryElem => queryElem.CompanyAddress == "г. Самара, ул. Олимпийская, 73а.");
        Assert.Contains(query, queryElem => queryElem.CompanyAddress == "г. Самара, ул. Спортивная, 20.");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "СамараПласт");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "Самара Строй Комплект");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "Fix Price");
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Картонная коробка 60*40*50");
        Assert.DoesNotContain(query, queryElem => queryElem.Id == 161708);
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Ваза из стекла 3л");
    }
}