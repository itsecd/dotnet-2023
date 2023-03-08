namespace Fabric.Test;

public class FabricTests : IClassFixture<FabricFixture>
{
    private readonly FabricFixture _fixture;

    public FabricTests(FabricFixture fixture)
    { _fixture = fixture; }
    /// <summary>
    /// First request: get information from one fabric.
    /// </summary>
    [Fact]
    public void FirstRequest()
    {
        var fixtureFabrics = _fixture.FixtureFabrics;
        var request = (from fabric in fixtureFabrics
                       where (fabric.Id == 2)
                       select fabric).Count();
        Assert.Equal(1, request);
    }
    /// <summary>
    /// Second request: all providers who delivered goods during the given interval.
    /// </summary>
    [Fact]
    public void SecondRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var firstDate = new DateOnly(2022, 5, 21);
        var secondDate = new DateOnly(2022, 9, 21);
        var request = (from shipment in fixtureShipments
                       where (shipment.Date.CompareTo(firstDate) > 0) && (shipment.Date.CompareTo(secondDate) < 0)
                       select shipment).Count();
        Assert.Equal(3, request);
    }
    /// <summary>
    /// Third request: the number of fabrics that each providers works with.
    /// </summary>
    [Fact]
    public void ThirdRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var request = from shipment in fixtureShipments
                      join fabric in _fixture.FixtureFabrics on shipment.Fabric.Id equals fabric.Id
                      select new
                      {
                          provider = shipment.Provider,
                          count = fabric
                      };
        var firstItem = request.First();
        var lastItem = request.Last();
        Assert.Equal(3, firstItem.provider.Id);
    }
    /// <summary>
    /// Fifth request: top 5 of providers by the number of shipments
    /// </summary>
    [Fact]
    public void FifthRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var request = from shipment in fixtureShipments
                      where fixtureShipments.Count == fixtureShipments.Max(x => fixtureShipments.Count)
                      select new
                      {
                          provider = shipment.Provider
                      };
        var firstItem = request.First();
        Assert.Equal(3, firstItem.provider.Id);

    }
}