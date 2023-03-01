using System.Linq;

namespace PONRF.Tests;

public class UnitTest: IClassFixture<PonrfFixture>
{
    private readonly PonrfFixture _fixture;
    public UnitTest(PonrfFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetAddress()
    {

    }

    [Fact]
    public void Building()
    {

    }
}