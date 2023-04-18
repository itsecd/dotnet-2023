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
    public void ProductsFromPharmacy()
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
    [Fact]
    public void FarmGroup()
    {
        var request = (from pharmaGroup in _fixture.PharmaGroups
                       from productPharmaGroup in pharmaGroup.ProductPharmaGroup
                       from productPharmacy in productPharmaGroup.Product.ProductPharmacy
                       group productPharmacy by new
                        {
                            productPharmaGroup.PharmaGroup.PharmaGroupId,
                            productPharmacy.Pharmacy.PharmacyName
                        } into pharmacyGroups
                        select new
                        {
                            PharmaGroup = pharmacyGroups.Key.PharmaGroupId,
                            Pharmacy = pharmacyGroups.Key.PharmacyName,
                            ProductCost = pharmacyGroups.Average(s => s.ProductCost)
                        }
               ).ToList();
        Assert.Equal(300, request[0].ProductCost);
        Assert.Equal(1, request[0].PharmaGroup);
        Assert.Equal("Vita", request[0].Pharmacy);
        Assert.Equal(350, request[1].ProductCost);
        Assert.Equal(1, request[1].PharmaGroup);
        Assert.Equal("Tabls", request[1].Pharmacy);
        Assert.Equal(250, request[2].ProductCost);
        Assert.Equal(2, request[2].PharmaGroup);
        Assert.Equal("Vita", request[2].Pharmacy);
    }
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
}