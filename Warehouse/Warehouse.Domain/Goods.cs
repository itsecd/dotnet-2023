namespace Warehouse.Domain;

/// <summary>
///     Class Goods is used to store info about the products
/// </summary>
public class Goods
{
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>  
    ///     Id - shows the product id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
    /// <summary>
    ///     Supply - list of supply routes with product 
    /// </summary>
    public List<Supply> Supply { set; get; } = new List<Supply>();
    /// <summary>
    ///     WarehouseCell - list of cells with product 
    /// </summary>
    public List<WarehouseCells> WarehouseCell { set; get; } = new List<WarehouseCells>();
    public Goods(int id, string name, int count)
    {
        Id = id;
        Name = name;
        ProductCount = count;
    }
    public Goods() { }
}