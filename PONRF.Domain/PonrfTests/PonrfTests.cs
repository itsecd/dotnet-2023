namespace PonrfTests;

public class UnitTest : IClassFixture<PonrfFixture>
{
    private PonrfFixture _fixture;
    public UnitTest(PonrfFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ViewAllCustomers()
    {
        var customers = _fixture.CustomersFixture.ToList();
        Assert.Equal(6, customers.Count);
    }

    [Fact]
    public void AuctionsWithoutFullSales()
    {
        var auctions = _fixture.AuctionsFixture.ToList();
        var buildings = _fixture.BuildingsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from auction in auctions
                       join privatizedBuilding in privatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
                       join building in buildings on privatizedBuilding.Building?.RegistNum equals building.RegistNum
                       where privatizedBuilding.Customer?.Passport == null
                       group auction by auction.Organizer into auct
                       select auct).ToList().Count();
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
                        orderby customer.Fio
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
                       join auction in auctions on privatizedBuilding.Auction?.Id equals auction.Id
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
                       group privatizedBuilding by new { privatizedBuilding.Customer?.Fio } into privBuild
                       select new
                       {
                           privBuild.Key.Fio,
                           Total = privBuild.Sum(s => s.SecondCost)
                       }).OrderByDescending(t => t.Total).Take(5).ToList();
        Assert.Equal("Турец И. П.", request[0].Fio);
        Assert.Equal("Раскольникова С. М.", request[4].Fio);
    }

    [Fact]
    public void MostProfitableAuctions()
    {
        var auctions = _fixture.AuctionsFixture.ToList();
        var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
        var request = (from auction in auctions
                       join privatizedBuilding in privatizedBuildings on auction.Id equals privatizedBuilding.Auction?.Id
                       where privatizedBuilding.SecondCost != int.MinValue
                       group privatizedBuilding by new { privatizedBuilding.Auction?.Organizer } into privBuild
                       select new
                       {
                           privBuild.Key.Organizer,
                           Profit = privBuild.Sum(s => s.SecondCost - s.FirstCost)
                       }).OrderByDescending(p => p.Profit).Take(2).ToList();
        Assert.Equal("Сириус", request[0].Organizer);
        Assert.Equal("Аргентум", request[1].Organizer);
    }

    [Fact]
    public void AddressOfBuildings()
    {
        var buildings = _fixture.BuildingsFixture.ToList();
        var request = (from building in buildings select building.GetAddress()).ToList();
        Assert.Equal("р-н Кировский, ул. Домодедовская, 76", request[0]);
    }
}