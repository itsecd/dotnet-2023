using PonrfDomain;
using System.Linq;

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
                       select customer).Count();
        Assert.Equal(3, request);
    }

    //[Fact]
    //public void AuctionsWithoutFullSales()
    //{
    //    var auctions = _fixture.AuctionsFixture.ToList();
    //    var lots = _fixture.LotsFixture.ToList();
    //    var privatizedBuildings = _fixture.PrivatizedBuildingsFixture.ToList();
    //    var request = (from auction in auctions
    //                   join lot in lots on auction.IDAuction equals lot.Auction?.IDAuction &&
    //                   join privatizedBuilding in privatizedBuildings on auction.IDAuction equals privatizedBuilding.Auction?.IDAuction
    //                   where
    //                   select auction).Count();
    //    Assert.Equal(1, request);
    //}

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
                       select customer).Count();
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
                        select customer.Address).Count();
        Assert.Equal(2, request);
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