using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// BuyerAuctionConnection - class that describes the relationship between the auction and the buyers participating in the auction
/// </summary>
public class BuyerAuctionConnection
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// BuyerId - the id of the buyer participating in the auction
    /// </summary>
    [ForeignKey(nameof(Buyer))]
    public int BuyerId { get; set; }
    public Buyer Buyer { get; set; }
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>

    [ForeignKey(nameof(Auction))]
    public int AuctionId { get; set; }
    public Auction Auction { get; set; }

    public BuyerAuctionConnection() { }
    public BuyerAuctionConnection(int buyerId, int auctionId)
    {
        BuyerId = buyerId;
        AuctionId = auctionId;
    }
}
