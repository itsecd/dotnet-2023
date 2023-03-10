namespace Warehouse;
/// <summary>
/// Warehouse - a class that describes the company supply with goods
/// </summary>
public class Supply
{
    /// <summary>
    /// Count - shows amount of product
    /// </summary>  
    public int Count { set; get; }
    /// <summary>
    /// CompanyName - contain string of company what get supply
    /// </summary>
    public List<Supply> CompanyName { set; get; } = new List<Supply>();
    /// <summary>  
    /// ID - shows the product's id
    /// </summary>  
    public int ID { set; get; }
    /// <summary><
    /// Name - a string that stores company name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}