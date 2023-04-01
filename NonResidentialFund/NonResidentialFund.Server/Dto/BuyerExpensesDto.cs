namespace NonResidentialFund.Server.Dto;

public class BuyerExpensesDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; } = 0;

    /// <summary>
    /// Expenses cpent by the buyer
    /// </summary>
    public double Expenses { get; set; } = 0.0;
}
