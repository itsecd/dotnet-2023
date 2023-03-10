namespace Warehouse;
/// <summary>
/// Warehouse - a class that describes the company supply with goods
/// </summary>
public class CompanyWarehouse
{
    /// <summary>
    /// Cells - show product cell number 
    /// </summary>  
    public string Cells { set; get; } = string.Empty;
    /// <summary>
    /// Count - shows amount of product
    /// </summary>
    public List<Goods> Count { set; get; } = new List<Goods>();
    /// <summary>  
    /// ID - shows the product's id
    /// </summary>  
    public List<Goods> ID { set; get; } = new List<Goods>();
    /// <summary><
    /// Name - a string that stores product name 
    /// </summary>
    public List<Goods> Name { set; get; } = new List<Goods>();
    /// <summary><
    /// CompanyName - a string that stores company name what get supply
    /// </summary>
    public List<Goods> CompanyName { set; get; } = new List<Goods>();
}