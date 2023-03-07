namespace Non_residentialFundDomain;
public class BuyerAuctionConnection
{
    public int BuyerId { get; set; } = 0;
    public int AuctionId { get; set;} = 0;

    public BuyerAuctionConnection(int buyerId, int auctionId)
    {
        BuyerId = buyerId;
        AuctionId = auctionId;
    }
}
