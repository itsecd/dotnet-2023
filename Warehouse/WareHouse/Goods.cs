namespace Warehouse;
/// <summary>
///     Warehouse - a class that describes the company supply with goods
/// </summary>
public class Goods
{
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>  
    ///     Id - shows the product's id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
    public List<Supply> Supply { set; get; } = new List<Supply>();
    public List<WarehouseCells> WarehouseCell { set; get; } = new List<WarehouseCells>();
    public Goods(int id, string name, int count)
    {
        Id = id;
        Name = name;
        ProductCount = count;
    }
    public Goods() { }
}