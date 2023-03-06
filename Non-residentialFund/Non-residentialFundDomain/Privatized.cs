namespace Non_residentialFundDomain;
public class Privatized
{
    public int RegistrationNumber { get; set; }
    public int BuyerId { get; set; } = 0;
    public int AuctionId { get; set; } = 0;
    public DateOnly SaleDate { get; set; } = new DateOnly();
    public double StartPrice { get; set; } = 0.0;
    public double EndPrice { get; set; } = 0.0;
    public Privatized(int registrationNumber, int buyerId, int auctionId, DateOnly saleDate, double startPrice, double endPrice)
    {
        RegistrationNumber = registrationNumber;
        BuyerId = buyerId;
        AuctionId = auctionId;
        SaleDate = saleDate;
        StartPrice = startPrice;
        EndPrice = endPrice;
    }
}