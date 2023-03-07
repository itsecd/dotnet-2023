namespace Non_residentialFundDomain;
public class BuildingAuctionConnection{
    public int BuildingId { get; set; } = 0;
    public int AuctionId { get; set;} = 0;

    public BuildingAuctionConnection(int buildingId, int auctionId)
    {
        BuildingId = buildingId;
        AuctionId = auctionId;
    }
}
