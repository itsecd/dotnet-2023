using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Model;
/// <summary>
/// BuyerAuctionConnection - class that describes the relationship between the auction and the buyers participating in the auction
/// </summary>
public class BuyerAuctionConnection
{
    /// <summary>
    /// Id - id of the BuyerAuctionConnection object
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// BuyerId - the id of the buyer participating in the auction
    /// </summary>
    [ForeignKey(nameof(Buyer))]
    public int BuyerId { get; set; }

    /// <summary>
    /// Buyer - The navigation property is a link to the Buyer object
    /// </summary>
    public Buyer Buyer { get; set; }

    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    [ForeignKey(nameof(Auction))]
    public int AuctionId { get; set; }

    /// <summary>
    /// Auction - The navigation property is a link to the Auction object
    /// </summary>
    public Auction Auction { get; set; }

    public BuyerAuctionConnection() { }

    public BuyerAuctionConnection(int buyerId, int auctionId)
    {
        BuyerId = buyerId;
        AuctionId = auctionId;
    }
}
