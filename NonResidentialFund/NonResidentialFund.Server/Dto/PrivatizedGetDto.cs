namespace NonResidentialFund.Server.Dto;

public class PrivatizedGetDto
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
    /// AuctionId - The id of the auction at which the building was sold
    /// </summary>
    public int AuctionId { get; set; } = 0;
    /// <summary>
    /// SaleDate - Date of sale of the building 
    /// </summary>
    public DateTime SaleDate { get; set; } = new DateTime();
    /// <summary>
    /// StartPrice - The starting price for this building at the auction
    /// </summary>
    public double StartPrice { get; set; } = 0.0;
    /// <summary>
    /// EndPrice - The final price of this building at the auction
    /// </summary>
    public double EndPrice { get; set; } = 0.0;
}
