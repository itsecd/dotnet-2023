namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuildingAuctionConnectionForAuctionDto - represents BuildingAuctionConnection object.
/// It used to get information about which buildings were offered for sale for the specified auction.
/// </summary>
public class BuildingAuctionConnectionForAuctionDto
{
    /// <summary>
    /// BuildingId - The id of the building being auctioned off
    /// </summary>
    public int BuildingId { get; set; }
}
