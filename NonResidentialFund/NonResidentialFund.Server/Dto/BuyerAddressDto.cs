namespace NonResidentialFund.Server.Dto;

public class BuyerAddressDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; } = 0;

    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
