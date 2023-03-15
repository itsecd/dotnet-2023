namespace Warehouse;
/// <summary>
///     Warehouse - a class that describes the company supply with goods
/// </summary>
public class Supply
{
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
    public List<Goods> Goods { set; get; } = new List<Goods>();
    public Supply(string companyName, string companyAdress, DateTime supplyDate, int supplyCount)
    {
        CompanyName = companyName;
        CompanyAddress = companyAdress;
        SupplyDate = supplyDate;
        SupplyCount = supplyCount;
    }
    public Supply() { }
}