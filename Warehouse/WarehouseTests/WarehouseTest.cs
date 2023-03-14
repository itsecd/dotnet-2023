namespace WarehouseTest;

using System.Linq;

public class WarehouseTestsClass : IClassFixture<WarehouseFixture>
{
    private readonly WarehouseFixture _fixture;
    public WarehouseTestsClass(WarehouseFixture fixture)
    {
        _fixture = fixture;

    }
    [Fact]

    /// <summary>
    ///     First request - display information about the company's products, sorted by product name
    /// </summary>
    public void FirstRequestTest()
    {
        var allGoods = _fixture.GoodsFixture;
        var goods = (from product in allGoods orderby product.Name select product).ToList();

        Assert.Equal(9, goods.Count);
        Assert.Equal("Вилка из нерж. стали", goods[0].Name);
        Assert.Equal("Гипсовая штукатурка 5кг", goods[1].Name);
        Assert.Equal("Картонная коробка 60*40*50", goods[2].Name);
        Assert.Equal("Контейнер 640мл с крышкой", goods[3].Name);
        Assert.Equal("Ваза из стекла 3л", goods[4].Name);
        Assert.Equal("Ваза из стекла 4л", goods[5].Name);
        Assert.Equal("Пищевая плёнка для упаковки 5м", goods[6].Name);
        Assert.Equal("Столовая ложка из нерж. стали", goods[7].Name);
        Assert.Equal("Чайная ложка из нерж. стали", goods[8].Name);
    }

    [Fact]

    /// <summary>
    ///     Second request - display information about the company's products received on the specified day by the recipient of products
    /// </summary>
    public void SecondRequestTest()
    {
        var query = (from supply in _fixture.SupplyFixture
                     where supply.SupplyDate == new DateOnly(2023, 02, 11)
                     join goods in _fixture.GoodsFixture on supply.ID equals goods.ID
                     select goods).ToList();
        Assert.Equal(2, query.Count);
        Assert.Contains(query, queryElem => queryElem.Name == "Пищевая плёнка для упаковки 5м");
        Assert.Contains(query, queryElem => queryElem.ID == 106932);
        Assert.Contains(query, queryElem => queryElem.Name == "Гипсовая штукатурка 5кг");
        Assert.Contains(query, queryElem => queryElem.ID == 218302);
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Контейнер 640мл с крышкой");
        Assert.DoesNotContain(query, queryElem => queryElem.ID == 103722);
    }

    [Fact]

    /// <summary>
    ///     Third request - display the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    public void ThirdRequestTest()
    {
        var query = (from warehouse in _fixture.WarehouseCellsFixture
                     join goods in _fixture.GoodsFixture on warehouse.ID equals goods.ID
                     orderby warehouse.CellNumber
                     select new { number = warehouse.CellNumber, goodsIN = goods.ID, goodsTitle = goods.Name, goodsCount = goods.ProductCount }).ToList();

        Assert.Equal(9, query.Count);
        Assert.Equal("Контейнер 640мл с крышкой", query[0].goodsTitle);
        Assert.Equal("Ваза из стекла 4л", query[7].goodsTitle);
        Assert.True(query[0].goodsCount == 100);
        Assert.True(query[7].goodsCount == 10);
    }

    [Fact]

    /// <summary>
    ///     Fourt request - display information about the organizations that received the maximum volume products for a given period
    /// </summary>
    public void FourthRequestTest()
    {
        var query = (from supply in _fixture.SupplyFixture
                     where supply.SupplyDate > new DateOnly(2023, 02, 1) && supply.SupplyDate < new DateOnly(2023, 02, 15)
                     group supply by new
                     {
                         supply.CompanyName,
                         supply.CompanyAdress
                     } into grp
                     select new
                     {
                         grp.Key.CompanyName,
                         grp.Key.CompanyAdress,
                         goodsCount = grp.Sum(x => x.ProductCount)
                     }).ToList();
        var max = query.Max(x => x.goodsCount);
        foreach (var q in query)
        {
            if (q.goodsCount == max)
            {
                Assert.Equal("Посуда Центр", q.CompanyName);
                Assert.Equal("г. Самара, ул. Партизанская, 17.", q.CompanyAdress);
            }
        }

    }

    [Fact]

    /// <summary>
    ///     Fifth request - display the top 5 products by stock availability
    /// </summary>
    public void FifthRequestTest()
    {
        var query = (from goods in _fixture.GoodsFixture orderby goods.ProductCount descending select goods).Take(5).ToList();
        Assert.Equal(5, query.Count);
        Assert.True(query[0].ProductCount == 100);
        Assert.True(query[1].ProductCount == 50);
        Assert.True(query[2].ProductCount == 50);
        Assert.True(query[3].ProductCount == 35);
        Assert.True(query[4].ProductCount == 25);
    }

    [Fact]

    /// <summary>
    ///     Sixth request - display information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    public void SixthRequestTest()
    {
        var query = (from supply in _fixture.SupplyFixture
                     join goods in _fixture.GoodsFixture on supply.ID equals goods.ID
                     group supply by new
                     {
                         supply.CompanyName,
                         supply.CompanyAdress,
                         supply.ID,
                         goods.Name
                     } into grp
                     select new
                     {
                         grp.Key.CompanyName,
                         grp.Key.CompanyAdress,
                         grp.Key.ID,
                         grp.Key.Name,
                         quntity = grp.Sum(x => x.ProductCount)
                     }).ToList();
        Assert.Equal(4, query.Count);
        Assert.Contains(query, queryElem => queryElem.ID == 103722);
        Assert.Contains(query, queryElem => queryElem.ID == 218302);
        Assert.Contains(query, queryElem => queryElem.ID == 312510);
        Assert.Contains(query, queryElem => queryElem.ID == 106932);
        Assert.Contains(query, queryElem => queryElem.CompanyAdress == "г. Самара, ул. Луцкая, 16.");
        Assert.Contains(query, queryElem => queryElem.CompanyAdress == "г. Самара, ул. Олимпийская, 73а.");
        Assert.Contains(query, queryElem => queryElem.CompanyAdress == "г. Самара, ул. Спортивная, 20.");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "СамараПласт");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "Самара Строй Комплект");
        Assert.Contains(query, queryElem => queryElem.CompanyName == "Fix Price");
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Картонная коробка 60*40*50");
        Assert.DoesNotContain(query, queryElem => queryElem.ID == 161708);
        Assert.DoesNotContain(query, queryElem => queryElem.Name == "Ваза из стекла 3л");

    }
}