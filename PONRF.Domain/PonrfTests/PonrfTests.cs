using PonrfDomain;

namespace PonrfTests;

public class UnitTest : IClassFixture<PonrfFixture>
{
    private PonrfFixture _fixture;
    public UnitTest(PonrfFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void First()
    {
        var request = (from
                        where
                        select ).Count;
        Assert.Equal(1, request);
    }

    [Fact]
    public void Second()
    {

    }

    [Fact]
    public void Third()
    {

    }

    [Fact]
    public void Fourth()
    {

    }

    [Fact]
    public void Fifth()
    {

    }

    [Fact]
    public void Sixth()
    {

    }
}