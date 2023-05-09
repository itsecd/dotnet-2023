namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuyerAuctionConnectionForBuyerDto - represents BuyerAuctionConnection object.
/// It used to obtain information on which auctions the specified buyer participated in.
/// </summary>
public class BuyerAuctionConnectionForBuyerDto
{
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }
}
