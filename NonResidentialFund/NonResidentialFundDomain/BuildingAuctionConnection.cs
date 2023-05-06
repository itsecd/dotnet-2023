using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// BuildingAuctionConnection - class that describes the relationship between the auction and the buildings offered at that auction
/// </summary>
public class BuildingAuctionConnection
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// BuildingId - The id of the building being auctioned off
    /// </summary>
    [ForeignKey(nameof(Building))]
    public int BuildingId { get; set; }
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>

    [ForeignKey(nameof(Auction))]
    public int AuctionId { get; set; }
    public BuildingAuctionConnection() { }

    public BuildingAuctionConnection(int buildingId, int auctionId)
    {
        BuildingId = buildingId;
        AuctionId = auctionId;
    }
}
