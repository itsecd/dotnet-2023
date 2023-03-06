namespace Non_residentialFundDomain;
public class Auction
{
    public int AuctionId { get; set; }
    public DateOnly Date { get; set; } = new DateOnly();
    public int OrganizationId { get; set; } = 0;
    public List<Building> Lots { get; set; } = new List<Building>();
    public List<Buyer> Buyers { get; set; } = new List<Buyer>();

    public Auction(int auctionId, DateOnly date, int organizationId, List<Building> lots, List<Buyer> buyers)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
        Lots = lots;
        Buyers = buyers;
    }
}