namespace Warehouse;
/// <summary>
/// Warehouse - a class that describes the company supply with goods
/// </summary>
public class Goods
{
    /// <summary>
    /// Count - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>  
    /// ID - shows the product's id
    /// </summary>  
    public int ID { set; get; }
    /// <summary>
    /// Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
    /// <summary>
    ///     Cell - number of the cell in which the product is stored
    /// </summary>
	public int CellNumber { get; set; }

    public Goods(int id, string name, int count, int cells)
    {
        ID = id;
        Name = name;
        ProductCount = count;
        CellNumber = cells;
    }
}