namespace Warehouse.Domain;

/// <summary>
///     Class Supple is used to store info about the supplies
/// </summary>
public class Supply
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
    /// <summary>
    ///     Goods - list of products, what shipment contains 
    /// </summary>
    public List<Goods> Goods { set; get; } = new List<Goods>();
    public Supply(int id, string companyName, string companyAdress, DateTime supplyDate, int supplyCount)
    {
        Id = id;
        CompanyName = companyName;
        CompanyAddress = companyAdress;
        SupplyDate = supplyDate;
        SupplyCount = supplyCount;
    }
    public Supply() { }
}