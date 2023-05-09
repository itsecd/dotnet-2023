namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuyerExpensesDto - represents information about the buyer and his total expenses. 
/// </summary>
public class BuyerExpensesDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }

    /// <summary>
    /// Expenses cpent by the buyer
    /// </summary>
    public double Expenses { get; set; }
}
