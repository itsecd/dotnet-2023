namespace NonResidentialFund.Server.Dto;

public class AuctionIncomeDto
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    public int AuctionId { get; set; }

    /// <summary>
    /// The income that the auction received
    /// </summary>
    public double Income { get; set; }
}
