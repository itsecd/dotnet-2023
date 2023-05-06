using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// Auction - a class that describes characteristics of a auction
/// </summary>
public class Auction
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    [Key]
    public int AuctionId { get; set; }
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    [ForeignKey(nameof(Auction))]
    public int OrganizationId { get; set; }
    /// <summary>
    /// Buildings - List of buildings that were auctioned off
    /// </summary>
    [NotMapped]
    public List<BuildingAuctionConnection> Buildings { get; set; } = null!;
    /// <summary>
    /// Buyers - List of buyers participating in the auction
    /// </summary>
    [NotMapped]
    public List<BuyerAuctionConnection> Buyers { get; set; } = null!;

    public Auction() { }
    public Auction(int auctionId, DateTime date, int organizationId, List<BuildingAuctionConnection> buildings, List<BuyerAuctionConnection> buyers)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
        Buildings = buildings;
        Buyers = buyers;
    }
}