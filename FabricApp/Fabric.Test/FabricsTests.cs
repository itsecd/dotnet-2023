namespace Fabrics.Test;

public class FabricsTests : IClassFixture<FabricsFixture>
{
    private readonly FabricsFixture _fixture;

    public FabricsTests(FabricsFixture fixture)
    { _fixture = fixture; }
    /// <summary>
    /// First request: get information from one fabric.
    /// </summary>
    [Fact]
    public void FirstRequest()
    {
        var fixtureFabrics = _fixture.FixtureFabrics;
        var request = (from fabric in fixtureFabrics
                       where fabric.Id == 2
                       select fabric).ToList().Count();
        Assert.Equal(1, request);
    }
    /// <summary>
    /// Second request: all providers who delivered goods during the given interval.
    /// </summary>
    [Fact]
    public void SecondRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var firstDate = new DateTime(2022, 5, 21);
        var secondDate = new DateTime(2022, 9, 21);
        var request = (from shipment in fixtureShipments
                       where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                       select shipment).ToList().Count();
        Assert.Equal(3, request);
    }
    /// <summary>
    /// Third request: the number of fabrics that each providers works with.
    /// </summary>
    [Fact]
    public void ThirdRequest()
    {
        var shipments = _fixture.FixtureShipments;
        var fabrics = _fixture.FixtureFabrics;
        var providers = _fixture.FixtureProviders;
        var request = (from provider in providers
                       join shipment in shipments on provider.Id equals shipment.ProviderId
                       join fabric in fabrics on shipment.FabricId equals fabric.Id
                       group fabric by provider into g
                       select new
                       {
                           provider = g.Key,
                           count = g.Count()
                       }).ToList();
        Assert.Equal(2, request.First(r => r.provider.Id == 2).count);
        Assert.Equal(2, request.First(r => r.provider.Id == 4).count);
        Assert.Equal(1, request.First(r => r.provider.Id == 3).count);
        Assert.Equal(1, request.First(r => r.provider.Id == 1).count);
    }
    /// <summary>
    /// Fourth request: information about the number of providers for each form of ownership of fabric.
    /// </summary>
    [Fact]
    public void FourthRequest()
    {
        var shipments = _fixture.FixtureShipments;
        var fabrics = _fixture.FixtureFabrics;
        var providers = _fixture.FixtureProviders;
        var request = (from fabric in fabrics
                       join shipment in shipments on fabric.Id equals shipment.FabricId
                       join provider in providers on shipment.ProviderId equals provider.Id
                       group provider by fabric.FormOfOwnership into g
                       select new
                       {
                           Form = g.Key,
                           Count = g.Count()
                       }).ToList();
        Assert.Equal(2, request.First(x => x.Form == "ТОО").Count);
    }
    /// <summary>
    /// Fifth request: top 5 of providers by the number of shipments
    /// </summary>
    [Fact]
    public void FifthRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var numbersOfProviders = (from shipment in fixtureShipments
                                  group shipment by shipment.ProviderId into g
                                  select new
                                  {
                                      provider = g.Key,
                                      Count = g.Count()
                                  }).ToList();
        var request = (from num in numbersOfProviders
                       orderby num.Count descending
                       select num).Take(5).ToList();
        var firstItem = request.First();
        Assert.Equal(2, firstItem.provider);
    }
    /// <summary>
    /// Sixth request: information about providers who delivered the maximum quantity of goods during the given interval.
    /// </summary>
    [Fact]
    public void SixthRequest()
    {
        var fixtureShipments = _fixture.FixtureShipments;
        var firstDate = new DateTime(2022, 5, 21);
        var secondDate = new DateTime(2022, 9, 21);
        var shipmentsInInterval = (from shipment in fixtureShipments
                                   where shipment.Date.CompareTo(firstDate) > 0 && shipment.Date.CompareTo(secondDate) < 0
                                   select new
                                   {
                                       provider = shipment.ProviderId,
                                       number = shipment.NumberOfGoods
                                   }).ToList();
        var request = (from prov in shipmentsInInterval
                       where prov.number == shipmentsInInterval.Max(x => x.number)
                       select prov.provider).ToList().Count();
        Assert.Equal(2, request);
    }
}