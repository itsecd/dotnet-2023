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
        var allProducts = _fixture.ProductsFixture;
        var products = (from product in allProducts
                        orderby product.Name
                        select product).ToList();

        Assert.Equal(8, products.Count);
        Assert.Equal("Ваза из стекла 3л", products[0].Name);
        Assert.Equal("Ваза из стекла 4л", products[1].Name);
        Assert.Equal("Вилка из нерж. стали", products[2].Name);
        Assert.Equal("Гипсовая штукатурка 5кг", products[3].Name);
        Assert.Equal("Картонная коробка 60*40*50", products[4].Name);
        Assert.Equal("Контейнер 640мл с крышкой", products[5].Name);
        Assert.Equal("Пищевая плёнка для упаковки 5м", products[6].Name);
        Assert.Equal("Столовая ложка из нерж. стали", products[7].Name);
    }
    /// <summary>
    ///     Second request - display information about the company's products received on the specified day by the recipient of products
    /// </summary>
    [Fact]
    public void SecondRequestTest()
    {
        var query = (from products in _fixture.ProductsFixture
                     from supply in products.Supply
                     where supply.SupplyDate == new DateTime(2023, 02, 11)
                     select products).ToList();

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
        var query = (from products in _fixture.ProductsFixture
                     from cell in products.WarehouseCell
                     orderby cell.CellNumber
                     select new { number = cell.CellNumber, productsTitle = products.Name, productsQuantity = products.Quantity }).ToList();

        Assert.Equal(11, query.Count);
        Assert.Equal("Контейнер 640мл с крышкой", query[0].productsTitle);
        Assert.Equal("Ваза из стекла 3л", query[7].productsTitle);
        Assert.True(query[0].productsQuantity == 100);
        Assert.True(query[9].productsQuantity == 10);
    }
    /// <summary>
    ///     Fourt request - display information about the organizations that received the maximum volume products for a given period
    /// </summary>
    [Fact]
    public void FourthRequestTest()
    {
        var query = (from products in _fixture.ProductsFixture
                     from supply in products.Supply
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
                         productsQuantity = grp.Sum(x => x.Quantity)
                     }).ToList();

        var max = query.Max(x => x.productsQuantity);
        foreach (var q in query)
        {
            if (q.productsQuantity == max)
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
        var query = (from products in _fixture.ProductsFixture
                     orderby products.Quantity descending
                     select products).Take(5).ToList();

        Assert.Equal(5, query.Count);
        Assert.True(query[0].Quantity == 100);
        Assert.True(query[1].Quantity == 50);
        Assert.True(query[2].Quantity == 35);
        Assert.True(query[3].Quantity == 25);
        Assert.True(query[4].Quantity == 15);
    }
    /// <summary>
    ///     Sixth request - display information about the quantity of delivered products for each product and each organization
    /// </summary>
    [Fact]
    public void SixthRequestTest()
    {
        var query = (from products in _fixture.ProductsFixture
                     from supply in products.Supply
                     group supply by new
                     {
                         supply.CompanyName,
                         supply.CompanyAddress,
                         products.Id,
                         products.Name
                     } into grp
                     select new
                     {
                         grp.Key.CompanyName,
                         grp.Key.CompanyAddress,
                         grp.Key.Id,
                         grp.Key.Name,
                         quantity = grp.Sum(x => x.Quantity)
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