namespace Non_residentialFundDomain;
/// <summary>
/// Auction - a class that describes characteristics of a auction
/// </summary>
public class Auction
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    public int AuctionId { get; set; }
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateOnly Date { get; set; } = new DateOnly();
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    public int OrganizationId { get; set; } = 0;

    public Auction(int auctionId, DateOnly date, int organizationId)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
    }
}