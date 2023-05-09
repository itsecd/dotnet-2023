namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuyerAuctionConnectionForAuctionDto - represents BuyerAuctionConnection object.
/// It used to obtain information about which buyers participated in the specified auction.
/// </summary>
public class BuyerAuctionConnectionForAuctionDto
{
    /// <summary>
    /// BuyerId - the id of the buyer participating in the auction
    /// </summary>
    public int BuyerId { get; set; } = 0;
}
