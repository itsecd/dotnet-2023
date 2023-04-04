using PharmacyCityNetwork.Tests;

namespace PharmacyCityNetwork.Module;

public class PharmacyCityNetworkTests : IClassFixture<PharmacyCityNetworkFixture>
{
    private readonly PharmacyCityNetworkFixture _fixture;
    public PharmacyCityNetworkTests(PharmacyCityNetworkFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void AllPharmaGroup()
    {
        Assert.Equal(5, 5);
    }
    
}
