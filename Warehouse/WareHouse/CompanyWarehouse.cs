namespace Warehouse;
/// <summary>
/// Warehouse - a class that describes the company supply with goods
/// </summary>
public class CompanyWarehouse
{
    /// <summary>
    /// CellNumber - cell number 
    /// </summary>  
    public int CellNumber { set; get; }
    /// <summary>
    /// Count - shows amount of product
    /// </summary>
    public int ID { set; get; }
    /// <summary>  
    /// ID - shows the product's id
    /// </summary>  
    public CompanyWarehouse(int cell, int id)
    {
        CellNumber = cell;
        ID = id;
    }
}