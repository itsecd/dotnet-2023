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
        Assert.Equal("Paracetamol", request[1]);
        Assert.Equal("Aka", request[0]);
    }

}
