namespace NonResidentialFund.Server.Dto;
/// <summary>
/// AuctionGetDto - used to represent the Auction object in the get-request.
/// </summary>
public class AuctionGetDto
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    public int AuctionId { get; set; }
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    public int OrganizationId { get; set; }
}
