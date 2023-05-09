namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuyerAddressDto - Represents information about the buyer's id and address.
/// </summary>
public class BuyerAddressDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }

    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
