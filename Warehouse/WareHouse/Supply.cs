namespace Warehouse;
/// <summary>
/// Warehouse - a class that describes the company supply with goods
/// </summary>
public class Supply
{
    /// <summary>
    /// Count - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>
    /// CompanyName - contain name of company what get supply
    /// </summary>
    public string CompanyName { set; get; } = string.Empty;
    /// <summary>
    ///     CompanyAdress - address of the company what get supply
    /// </summary>
	public string CompanyAdress { get; set; } = string.Empty;
    /// <summary>  
    /// ID - shows the product's id
    /// </summary>  
    public int ID { set; get; }
    /// <summary>
    ///     SupplyDate - shipment date
    /// </summary>
    public DateOnly SupplyDate { get; set; } = DateOnly.MinValue;

    public Supply(int id, string companyName, string companyAdress, DateOnly supplyDate, int count)
    {
        ID = id;
        CompanyName = companyName;
        CompanyAdress = companyAdress;
        SupplyDate = supplyDate;
        ProductCount = count;
    }
}