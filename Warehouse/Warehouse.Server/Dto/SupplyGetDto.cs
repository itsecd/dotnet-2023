namespace Warehouse.Server.Dto;

/// <summary>
///     Class SupplyGetDto is used to store info about the supplies
/// </summary>
public class SupplyGetDto
{
    /// <summary>  
    ///     Id - shows the supply id
    /// </summary>  
    public int Id { set; get; } = 0;
    /// <summary>
    ///     SupplyCount - shows amount of product
    /// </summary>  
    public int SupplyCount { set; get; } = 0;
    /// <summary>
    ///     CompanyName - contain name of company what get supply
    /// </summary>
    public string CompanyName { set; get; } = string.Empty;
    /// <summary>
    ///     CompanyAdress - address of the company what get supply
    /// </summary>
	public string CompanyAddress { get; set; } = string.Empty;
    /// <summary>
    ///     SupplyDate - shipment date
    /// </summary>
    public DateTime SupplyDate { get; set; } = DateTime.MinValue;
}
