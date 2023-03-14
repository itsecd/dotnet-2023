namespace Enterprise.Data.Tests;

using System.Linq;

public class EnterpriseTestsClass
{
    /// <summary>
    ///     First Query:
    ///     displays information about the company's products, sorted by product name
    /// </summary>
    [Fact]
    public void AllProductSortebByTitle()
    {
        var allProducts = EnterpriseFixture.ProductFixture;
        var products = (from product in allProducts orderby product.Title select product).ToList();

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
        var query = (from invoice in EnterpriseFixture.InvoiceFixture
                     from infoProduct in invoice.Products
                     where invoice.ShipmentDate == new DateOnly(2023, 02, 11)
                     join product in EnterpriseFixture.ProductFixture on infoProduct.Key equals product.ItemNumber
                     select product).ToList();
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
        var query = (from warehouse in EnterpriseFixture.StorageCellFixture
                     from productWarehouse in warehouse.ItemNumberProducts
                     join product in EnterpriseFixture.ProductFixture on productWarehouse equals product.ItemNumber
                     orderby warehouse.Number
                     select new { number = warehouse.Number, productIN = product.ItemNumber, productTitle = product.Title, quntityProduct = product.Quntity }).ToList();

        Assert.Equal(9, query.Count);
        Assert.Equal("Картонная коробка 40*30*30", query[0].productTitle);
        Assert.Equal("Кувшин для воды из стекла 4л", query[7].productTitle);
        Assert.True(query[0].quntityProduct == 100);
        Assert.True(query[7].quntityProduct == 10);
    }

    /// <summary>
    ///     Fourt Query:
    ///     displays information about the organizations that received the maximum volume products for a given period
    /// </summary>
    [Fact]
    public void InfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod()
    {
        var query = (from invoice in EnterpriseFixture.InvoiceFixture
                     from product in invoice.Products
                     where invoice.ShipmentDate > new DateOnly(2023, 02, 1) && invoice.ShipmentDate < new DateOnly(2023, 02, 15)
                     group invoice by new
                     {
                         invoice.NameOrganizationn,
                         invoice.AdressOrganization
                     } into grp
                     select new
                     {
                         grp.Key.NameOrganizationn,
                         grp.Key.AdressOrganization,
                         quntity = grp.Sum(x => x.Products.Sum(x => x.Value))
                     }).ToList();
        var max = query.Max(x => x.quntity);
        foreach (var q in query)
        {
            if (q.quntity == max)
            {
                Assert.Equal("Посуда Центр", q.NameOrganizationn);
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
        var query = (from product in EnterpriseFixture.ProductFixture orderby product.Quntity descending select product).Take(5).ToList();
        Assert.Equal(5, query.Count);
        Assert.True(query[0].Quntity == 100);
        Assert.True(query[1].Quntity == 50);
        Assert.True(query[2].Quntity == 50);
        Assert.True(query[3].Quntity == 35);
        Assert.True(query[4].Quntity == 25);
    }

    /// <summary>
    ///     Sixth Query:
    ///     displays information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    [Fact]
    public void InfoAboutTheQuantityGoodsDelivered()
    {
        var query = (from invoice in EnterpriseFixture.InvoiceFixture
                     from listProduct in invoice.Products
                     join product in EnterpriseFixture.ProductFixture on listProduct.Key equals product.ItemNumber
                     group invoice by new
                     {
                         invoice.NameOrganizationn,
                         invoice.AdressOrganization,
                         listProduct.Key,
                         product.Title
                     } into grp
                     select new
                     {
                         grp.Key.NameOrganizationn,
                         grp.Key.AdressOrganization,
                         grp.Key.Key,
                         grp.Key.Title,
                         quntity = grp.Sum(x => x.Products.Sum(x => x.Value))
                     }).ToList();
        Assert.Equal(4, query.Count);
        Assert.Contains(query, queryElem => queryElem.Key == 102302);
        Assert.Contains(query, queryElem => queryElem.Key == 101700);
        Assert.Contains(query, queryElem => queryElem.Key == 320510);
        Assert.Contains(query, queryElem => queryElem.Key == 103700);
        Assert.Contains(query, queryElem => queryElem.AdressOrganization == "г. Самара, ул. Партизанская, 17.");
        Assert.Contains(query, queryElem => queryElem.AdressOrganization == "г. Самара, ул. Луцкая, 16.");
        Assert.Contains(query, queryElem => queryElem.NameOrganizationn == "СамараПласт");
        Assert.Contains(query, queryElem => queryElem.NameOrganizationn == "Посуда Центр");
        Assert.DoesNotContain(query, queryElem => queryElem.Title == "Кастрюля алюм. с крышкой 5л");
        Assert.DoesNotContain(query, queryElem => queryElem.Key == 106302);
        Assert.DoesNotContain(query, queryElem => queryElem.Title == "Чайная ложка из нерж. стали");
    }
}
