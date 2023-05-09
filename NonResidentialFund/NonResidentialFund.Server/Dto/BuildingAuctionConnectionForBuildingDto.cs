namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuildingAuctionConnectionForBuildingDto - represents BuildingAuctionConnection object.
/// It used to obtain information on which auctions the specified building has been offered for sale.
/// </summary>
public class BuildingAuctionConnectionForBuildingDto
{
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }
}
