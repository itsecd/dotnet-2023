namespace Enterprise.Data.Tests;

using System.Linq;

public class EnterpriseTestsClass : IClassFixture<EnterpriseFixture>
{
    private readonly EnterpriseFixture _fixture;

    public EnterpriseTestsClass(EnterpriseFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    ///     First Query:
    ///     displays information about the company's products, sorted by product name
    /// </summary>
    [Fact]
    public void AllProductSortebByTitle()
    {
        var products = (from product in _fixture.ProductsFixture orderby product.Title select product).ToList();
        Assert.Equal(9, products.Count);
        Assert.Equal("Вилка из нерж. стали", products[0].Title);
        Assert.Equal("Картонная коробка 40*30*30", products[1].Title);
        Assert.Equal("Картонная коробка 60*40*50", products[2].Title);
        Assert.Equal("Кастрюля алюм. с крышкой 5л", products[3].Title);
        Assert.Equal("Кувшин для воды из стекла 3л", products[4].Title);
        Assert.Equal("Кувшин для воды из стекла 4л", products[5].Title);
        Assert.Equal("Столовая ложка из нерж. стали", products[6].Title);
        Assert.Equal("Чайная ложка из нерж. стали", products[7].Title);
        Assert.Equal("Чайник из нерж. стали 3л", products[8].Title);
    }

    /// <summary>
    ///     Second Query:
    ///     displays information about the company's products received on the specified day by the recipient of products
    /// </summary>
    [Fact]
    public void InformationProductReceivedOnCertainDay()
    {
        var query = (from invoice in _fixture.InvoicesFixture
                     where invoice.ShipmentDate == new DateTime(2023, 2, 11)
                     from invoiceContent in invoice.InvoiceContent
                     select invoiceContent.Product).ToList();
        Assert.Equal(2, query.Count);
        Assert.Contains(query, queryElem => queryElem.Title == "Кувшин для воды из стекла 4л");
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 101700);
        Assert.Contains(query, queryElem => queryElem.Title == "Вилка из нерж. стали");
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 320510);
        Assert.DoesNotContain(query, queryElem => queryElem.Title == "Картонная коробка 40*30*30");
        Assert.DoesNotContain(query, queryElem => queryElem.ItemNumber == 102302);
    }

    /// <summary>
    ///     Third Query:
    ///     displays the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    [Fact]
    public void CurrentStateWarehouseWithCellNumbers()
    {
        var query = (from product in _fixture.ProductsFixture
                     from storageCell in product.StorageCell
                     orderby storageCell.Number
                     select new { number = storageCell.Number, productIN = product.ItemNumber, productTitle = product.Title, quantityProduct = product.Quantity }).ToList();
        Assert.Equal(16, query.Count);
        Assert.Equal("Картонная коробка 40*30*30", query[0].productTitle);
        Assert.Equal("Чайная ложка из нерж. стали", query[7].productTitle);
        Assert.Equal("Кувшин для воды из стекла 4л", query[10].productTitle);
        Assert.Equal("Кувшин для воды из стекла 4л", query[11].productTitle);
        Assert.Equal("Кувшин для воды из стекла 4л", query[12].productTitle);
        Assert.Equal("Кувшин для воды из стекла 4л", query[13].productTitle);
        Assert.Equal("Кувшин для воды из стекла 3л", query[14].productTitle);
        Assert.Equal("Кувшин для воды из стекла 3л", query[15].productTitle);
        Assert.True(query[0].quantityProduct == 100);
        Assert.True(query[7].quantityProduct == 50);
        Assert.True(query[10].quantityProduct == 10);
        Assert.True(query[11].quantityProduct == 10);
        Assert.True(query[12].quantityProduct == 10);
        Assert.True(query[13].quantityProduct == 10);
        Assert.True(query[14].quantityProduct == 15);
        Assert.True(query[15].quantityProduct == 15);
    }

    /// <summary>
    ///     Fourth Query:
    ///     displays information about the organizations that received the maximum volume products for a given period
    /// </summary>
    [Fact]
    public void InfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod()
    {
        var query = (from invoice in _fixture.InvoicesFixture
                     where invoice.ShipmentDate >= new DateTime(2023, 2, 1) && invoice.ShipmentDate <= new DateTime(2023, 2, 15)
                     from invoiceContent in invoice.InvoiceContent
                     join product in _fixture.ProductsFixture on invoiceContent.Product.ItemNumber equals product.ItemNumber
                     group invoiceContent by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization
                     } into grp
                     select new
                     {
                         grp.Key.NameOrganization,
                         grp.Key.AdressOrganization,
                         quantity = grp.Sum(x => x.Quantity)
                     }).ToList();
        var max = query.Max(x => x.quantity);
        foreach (var q in query)
        {
            if (q.quantity == max)
            {
                Assert.Equal("Посуда Центр", q.NameOrganization);
                Assert.Equal("г. Самара, ул. Партизанская, 17.", q.AdressOrganization);
            }
        }

    }

    /// <summary>
    ///     Fifth Query:
    ///     displays the top 5 products by stock availability
    /// </summary>
    [Fact]
    public void TopFiveProductsByStockAvailability()
    {
        var query = (from product in _fixture.ProductsFixture orderby product.Quantity descending select product).Take(5).ToList();
        Assert.Equal(5, query.Count);
        Assert.True(query[0].Quantity == 100);
        Assert.True(query[1].Quantity == 50);
        Assert.True(query[2].Quantity == 50);
        Assert.True(query[3].Quantity == 35);
        Assert.True(query[4].Quantity == 25);
    }

    /// <summary>
    ///     Sixth Query:
    ///     displays information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    [Fact]
    public void InfoAboutTheQuantityGoodsDelivered()
    {
        var query = (from invoice in _fixture.InvoicesFixture
                     from invoiceContent in invoice.InvoiceContent
                     join product in _fixture.ProductsFixture on invoiceContent.Product.ItemNumber equals product.ItemNumber
                     group invoiceContent by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization,
                         product.ItemNumber,
                         product.Title
                     } into grp
                     select new
                     {
                         grp.Key.NameOrganization,
                         grp.Key.AdressOrganization,
                         grp.Key.ItemNumber,
                         grp.Key.Title,
                         quantity = grp.Sum(x => x.Quantity)
                     }).ToList();
        Assert.Equal(4, query.Count);
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 102302);
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 101700);
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 320510);
        Assert.Contains(query, queryElem => queryElem.ItemNumber == 103700);
        Assert.Contains(query, queryElem => queryElem.AdressOrganization == "г. Самара, ул. Партизанская, 17.");
        Assert.Contains(query, queryElem => queryElem.AdressOrganization == "г. Самара, ул. Луцкая, 16.");
        Assert.Contains(query, queryElem => queryElem.NameOrganization == "СамараПласт");
        Assert.Contains(query, queryElem => queryElem.NameOrganization == "Посуда Центр");
        Assert.DoesNotContain(query, queryElem => queryElem.Title == "Кастрюля алюм. с крышкой 5л");
        Assert.DoesNotContain(query, queryElem => queryElem.ItemNumber == 106302);
        Assert.DoesNotContain(query, queryElem => queryElem.Title == "Чайная ложка из нерж. стали");
    }
}
