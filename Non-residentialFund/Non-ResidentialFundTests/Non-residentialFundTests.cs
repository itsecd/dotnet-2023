using Non_residentialFundDomain;

namespace Non_ResidentialFundTests;
public class Non_residentialFundTests
{
    private NonResidentialFundFixture _fixture = new();

    /// <summary>
    /// First request: display information about all customers
    /// </summary>
    [Fact]
    public void FirstRequestTest()
    {
        var fictureBuyers = _fixture.FixtureBuyers;
        var buyers = (from buyer in fictureBuyers select buyer).ToList();
        
        Assert.Equal(8, fictureBuyers.Count);
    }

    /// <summary>
    /// Second request: Output information on auctions in which all auctioned buildings were not sold.
    /// </summary>
    [Fact]
    public void SecondRequestTest()
    {
        var result = (from auction in _fixture.FixtureAuctions
                     join countBoughtInAuction in (from privatized in _fixture.FixturePrivatized
                                                   group privatized by privatized.AuctionId into privGroup
                                                   select new { AuctionId = privGroup.First().AuctionId, countBought = privGroup.Count() })
                                                   on auction.AuctionId equals countBoughtInAuction.AuctionId
                     join countTrySaleInAuction in (from buildingAuction in _fixture.FixtureBuildingAuctionConnections
                                                    group buildingAuction by buildingAuction.AuctionId into buildingsInAuction
                                                    select new { AuctionId = buildingsInAuction.First().AuctionId, countTrySale = buildingsInAuction.Count() })
                                                   on auction.AuctionId equals countTrySaleInAuction.AuctionId
                     where countBoughtInAuction.countBought == countTrySaleInAuction.countTrySale
                     select auction.AuctionId).ToList();
        
        Assert.Equal(4, result.Count);
    }

    /// <summary>
    /// Third request: Output the information about the buyers who received the nonresidential fund for a certain the district of the city, 
    /// and the total amount of privatized fund of the district. Arrange by full name
    /// </summary>
    [Fact]
    public void ThirdRequestTest()
    {
        var result = (from buyer in _fixture.FixtureBuyers
                     join privatized in _fixture.FixturePrivatized on buyer.BuyerId equals privatized.BuyerId
                     join building in _fixture.FixtureBuildings on privatized.RegistrationNumber equals building.RegistrationNumber
                     where building.DistrictId == 1
                     orderby buyer.LastName, buyer.FirstName
                     select new {buyer.BuyerId, buyer.LastName, buyer.FirstName, buyer.MiddleName}).ToList();
        
        Assert.Equal(3, result.Count);
    }

    /// <summary>
    /// Fourth request: Find the addresses of all buyers participating in the auction of the specified date
    /// </summary>
    [Fact]
    public void FourthRequestTest() 
    {
        var result = (from buyerAuction in _fixture.FixtureBuyerAuctionConnections
                     join auction in _fixture.FixtureAuctions on buyerAuction.AuctionId equals auction.AuctionId
                     join buyer in _fixture.FixtureBuyers on buyerAuction.BuyerId equals buyer.BuyerId
                     where auction.Date == new DateOnly(2022, 3, 20)
                     select new { buyer.BuyerId, buyer.Address, buyer.LastName, buyer.FirstName }).ToList();

        Assert.Equal(8, result.Count);
    }

    /// <summary>
    /// Fifth request: Find the top 5 buyers who spent the most money
    /// </summary>
    [Fact]
    public void FifthRequestTest()
    {
        var result = (from privatized in _fixture.FixturePrivatized
                      join buyer in _fixture.FixtureBuyers on privatized.BuyerId equals buyer.BuyerId
                      group privatized by privatized.BuyerId into privGRoup
                      orderby privGRoup.Sum(privatized => privatized.EndPrice) descending
                      select new { BuyerId = privGRoup.First().BuyerId, expenses = privGRoup.Sum(privatized => privatized.EndPrice) }).Take(5).ToList();
        
        Assert.Equal(4, result.Count);
    }

    /// <summary>
    /// Sixth requrst: Output the data on the auctions that brought the most profit
    /// </summary>
    [Fact]
    public void SixthRequestTest()
    {
        var result = (from privatized in _fixture.FixturePrivatized
                     join auction in _fixture.FixtureAuctions on privatized.AuctionId equals auction.AuctionId
                     group privatized by privatized.AuctionId into privGRoup
                     orderby privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) descending
                     select new { AuctionId = privGRoup.First().AuctionId, income = 
                     privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) }).ToList();
        
        Assert.Equal(6, result.Count);
    }
}