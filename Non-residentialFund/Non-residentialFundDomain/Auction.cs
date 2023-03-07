namespace Non_residentialFundDomain;
public class Auction
{
    public int AuctionId { get; set; }
    public DateOnly Date { get; set; } = new DateOnly();
    public int OrganizationId { get; set; } = 0;

    public Auction(int auctionId, DateOnly date, int organizationId)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
    }
}