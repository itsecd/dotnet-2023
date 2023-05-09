namespace NonResidentialFund.Server.Dto;
/// <summary>
/// AuctionPostDto - used to get information about the Auction object in the post-request to create it in the database.
/// </summary>
public class AuctionPostDto
{
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    public int OrganizationId { get; set; }
}
