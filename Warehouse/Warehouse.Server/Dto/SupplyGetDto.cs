namespace Warehouse.Server.Dto;
public class SupplyGetDto
{
    /// <summary>  
    ///     Id - shows the supply id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     SupplyCount - shows amount of product
    /// </summary>  
    public int SupplyCount { set; get; }
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
