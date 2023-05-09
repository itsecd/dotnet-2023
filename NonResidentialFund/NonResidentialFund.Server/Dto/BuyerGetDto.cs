namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuyerGetDto - used to represent the Buyer object in the get-request.
/// </summary>
public class BuyerGetDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }
    /// <summary>
    /// LastName - buyer's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// FirstName - buyer's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// MiddleName - buyer's middle name
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// PassportSeries - buyer's passport series
    /// </summary>
    public string PassportSeries { get; set; } = string.Empty;
    /// <summary>
    /// PassportNumber - buyer's passpoer number
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;
    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
