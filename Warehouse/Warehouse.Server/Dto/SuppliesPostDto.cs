namespace Warehouse.Server.Dto;

/// <summary>
///     Class SupplyPostDto is used to store info about the supplies
/// </summary>
public class SuppliesPostDto
{
    /// <summary>  
    ///     Id - shows the supply id
    /// </summary>  
    public int Id { set; get; } = 0;
    /// <summary>
    ///     Quantity - shows amount of product
    /// </summary>  
    public int Quantity { set; get; } = 0;
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
