using PharmacyCityNetwork.Tests;

namespace PharmacyCityNetwork.Module;

public class ClassesTest : IClassFixture<PharmacyCityNetworkFixture>
{
    private readonly PharmacyCityNetworkFixture _fixture;
    public ClassesTest(PharmacyCityNetworkFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void AllProductsFromPharmacy()
    {
        var request = (from pharmacy in _fixture.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacy
                       where pharmacy.PharmacyName == "Vita"
                       orderby productPharmacy.Product.ProductName
                       select productPharmacy.Product.ProductName).ToList();
        Assert.Equal("Espumizan", request[0]);
        Assert.Equal("Paracetamol", request[1]);


    }
    [Fact]
    public void ProductsFromPharmacy()//Вывести для данного препарата подробный список всех аптек
                                      //с указанием количества препарата в аптеках.
    {
        var requestPharmacy = (from pharmacy in _fixture.Pharmacys
                               from productPharmacy in pharmacy.ProductPharmacy
                               where productPharmacy.Product.ProductName == "Noshpa"
                               orderby productPharmacy.Product.ProductName descending
                               select pharmacy).ToList();
        var requestCountProduct = (from pharmacy in _fixture.Pharmacys
                                   from productPharmacy in pharmacy.ProductPharmacy
                                   where productPharmacy.Product.ProductName == "Noshpa"
                                   orderby productPharmacy.Product.ProductName descending
                                   select productPharmacy).ToList();
        Assert.Equal("Plus", requestPharmacy[0].PharmacyName);
        Assert.Equal("Alia", requestPharmacy[1].PharmacyName);
        Assert.Equal(4, requestCountProduct[0].ProductCount);
        Assert.Equal(3, requestCountProduct[1].ProductCount);
    }
    //[Fact]
    //public void FarmGroup() //Вывести информацию о средней стоимости препаратов
    //                        //каждой фармацевтической группе для каждой аптеки.
    //{
    //    var request = (from pharmaGroup in _fixture.PharmaGroups
    //                   from productPharmaGroup in pharmaGroup.ProductPharmaGroup
    //                   from productPharmacy in productPharmaGroup.Product.ProductPharmacy
    //                   group productPharmacy.ProductCost by productPharmaGroup.PharmaGroup into g
    //                   select new
    //                   {
    //                       PharmaGroup = g.Key,
    //                       ProductCost = g.Average(s => s.ProductCost)
    //                   }).ToList();

    //    select g.Key.ProductCost).ToList();
    //    Assert.Equal(10, request.Average());
    //    //Assert.Equal(12, request[0]);
    //}
    //Вывести топ 5 аптек по количеству и объёму продаж данного препарата за 
    //указанный период времени.
    [Fact]
    public void TopFivePharmacy()
    {
        var dateOne = new DateTime(2023, 1, 1);
        var dateTwo = new DateTime(2024, 1, 1);
        var request = (from pharmacy in _fixture.Pharmacys
                        from productPharmacy in pharmacy.ProductPharmacy
                        from sale in productPharmacy.Product.Sales
                        where sale.PaymentDate < dateTwo && sale.PaymentDate > dateOne
                        orderby productPharmacy.Product.Sales.Count 
                        select pharmacy.PharmacyName).Distinct().Take(5).ToList();
        Assert.Equal("Vita", request[0]);
        Assert.Equal("Plus", request[1]);
        Assert.Equal("Alia", request[2]);
    }
    //Вывести список аптек указанного района,
    //продавших заданный препарат более указанного объёма
    [Fact]
    public void PharmacyFromAdress()
    {
        var request = (from pharmacy in _fixture.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacy
                       from sale in productPharmacy.Product.Sales
                       where productPharmacy.Product.ProductName == "Noshpa" 
                       && productPharmacy.ProductCount > 2
                       && (String.Compare(pharmacy.PharmacyAddress, "S")) > 0
                       orderby pharmacy.PharmacyName 
                       select pharmacy.PharmacyName).Distinct().ToList();
        Assert.Equal("Alia", request[0]);
        Assert.Equal("Plus", request[1]);
    }
    //Вывести список аптек, в которых указанный препарат продается с минимальной ценой
    [Fact]
    public void PharmacyMinCost()
    {
        var minCost = (from product in _fixture.Products
                       from productPharmacy in product.ProductPharmacy
                       where product.ProductName == "Noshpa"
                       select productPharmacy.ProductCost).Min();
        var request = (from pharmacy in _fixture.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacy
                       where productPharmacy.Product.ProductName == "Noshpa" 
                       && productPharmacy.ProductCost == minCost
                       select pharmacy.PharmacyName).ToList();
        Assert.Equal("Plus", request[0]);
    }
    [Fact]
    public void Test() //Вывести информацию о средней стоимости препаратов
                       //каждой фармацевтической группе для каждой аптеки.
    {
        var request = (from pharmaGroup in _fixture.PharmaGroups
                       from t in pharmaGroup.ProductPharmaGroup
                       from y in t.Product.ProductPharmacy
                       select y.ProductCost).ToList();
        Assert.Equal(request[0], 300);
        Assert.Equal(request[1], 350);
        Assert.Equal(request[2], 250);
        Assert.Equal(request[3], 200);
        Assert.Equal(request[4], 180);
        Assert.Equal(request[5], 135);
        Assert.Equal(request[6], 135);


    }

}