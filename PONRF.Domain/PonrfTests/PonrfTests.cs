namespace PonrfTests;

public class UnitTest : IClassFixture<PonrfFixture>
{
    private PonrfFixture _fixture;
    public UnitTest(PonrfFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ViewAllCistomers()
    {
        var customers = _fixture.CustomersFixture.ToList();
        var request = (from customer in customers
                       select customer).ToList().Count();
        Assert.Equal(6, request);
    }

    [Fact]
    public void AuctionsWithoutFullSales()
    {
        var auctions = _fixture.AuctionsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from auction in auctions
                       join countPrivBuild in (from privatizedBuilding in privatizedBuildings
                                               group privatizedBuilding by privatizedBuilding.Auction?.IDAuction into privBuild
                                               select new
                                               {
                                                   privBuild.First().Auction?.IDAuction,
                                                   count = privBuild.Count()
                                               })
                                                on auction.IDAuction equals countPrivBuild.IDAuction
                       where countPrivBuild.count != auction.Lot.Count
                       select auction).ToList().Count();
        Assert.Equal(1, request);
    }

    [Fact]
    public void CustomersAndBuildingsInDistrict()
    {
        var customers = _fixture.CustomersFixture.ToList();
        var buildings = _fixture.BuildingsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request1 = (from customer in customers
                        join privatizedBuilding in privatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                        join building in buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                        where building.District == "Кировский"
                        orderby customer.FIO
                        select customer).ToList().Count();
        Assert.Equal(2, request1);
        var request2 = (from privatizedBuilding in privatizedBuildings
                        join customer in customers on privatizedBuilding.Customer?.Passport equals customer.Passport
                        join building in buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                        where building.District == "Кировский"
                        select privatizedBuilding.SecondCost).Sum();
        Assert.Equal(1050000, request2);
    }

    [Fact]
    public void AddressesOfAuctionParticipants()
    {
        var date = DateTime.Parse("2023-02-02");
        var customers = _fixture.CustomersFixture.ToList();
        var auctions = _fixture.AuctionsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from customer in customers
                       join privatizedBuilding in privatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                       join auction in auctions on privatizedBuilding.Auction?.IDAuction equals auction.IDAuction
                       where auction.Date == date
                       select customer.Address).ToList().Count();
        Assert.Equal(2, request);
    }

    [Fact]
    public void TopFive()
    {
        var customers = _fixture.CustomersFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from customer in customers
                       join privatizedBuilding in privatizedBuildings on customer.Passport equals privatizedBuilding.Customer?.Passport
                       group privatizedBuilding by new { privatizedBuilding.Customer?.FIO } into privBuild
                       select new
                       {
                           privBuild.Key.FIO,
                           Total = privBuild.Sum(s => s.SecondCost)
                       }).OrderByDescending(t => t.Total).Take(5).ToList();
        Assert.Equal("Турец И. П.", request[0].FIO);
        Assert.Equal("Раскольникова С. М.", request[4].FIO);
    }

    [Fact]
    public void MostProfitableAuctions()
    {
        var auctions = _fixture.AuctionsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from auction in auctions
                       join privatizedBuilding in privatizedBuildings on auction.IDAuction equals privatizedBuilding.Auction?.IDAuction
                       group privatizedBuilding by new { privatizedBuilding.Auction?.Organizer } into privBuild
                       select new
                       {
                           privBuild.Key.Organizer,
                           Profit = privBuild.Sum(s => s.SecondCost - s.FirstCost)
                       }).OrderByDescending(p => p.Profit).Take(2).ToList();
        Assert.Equal("Сириус", request[0].Organizer);
        Assert.Equal("Аргентум", request[1].Organizer);
    }
}