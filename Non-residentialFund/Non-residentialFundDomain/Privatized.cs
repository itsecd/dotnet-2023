namespace Non_residentialFundDomain;
/// <summary>
/// Privatized - a class that describes characteristics of a privatized building 
/// </summary>
public class Privatized
{
    /// <summary>
    /// RegistrationNumber - registration number of privatized building
    /// </summary>
    public int RegistrationNumber { get; set; }
    /// <summary>
    /// BuyerId - The buyer's id of building
    /// </summary>
    public int BuyerId { get; set; } = 0;
    /// <summary>
    /// 
    /// </summary>
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