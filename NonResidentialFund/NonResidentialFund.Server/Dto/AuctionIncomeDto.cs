namespace NonResidentialFund.Server.Dto;
/// <summary>
/// AuctionIncomeDto - used to provide information about the id of the auction and its income.
/// </summary>
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
