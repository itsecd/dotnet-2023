using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Domain;

/// <summary>
///     Class Goods is used to store info about the products
/// </summary>
public class Products
{
    /// <summary>  
    ///     Id - shows the product id
    /// </summary>  
    [Key]
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    [Column("name")]
    public string Name { set; get; } = string.Empty;
    /// <summary>
    ///     Quantity - shows quantity of product
    /// </summary>  
    [Column("quantity")]
    public int Quantity { set; get; }
    /// <summary>
    ///     Supply - list of supply routes with product 
    /// </summary>
    public List<Supplies> Supply { set; get; } = new List<Supplies>();
    /// <summary>
    ///     WarehouseCell - list of cells with product 
    /// </summary>
    public List<WarehouseCells> WarehouseCell { set; get; } = new List<WarehouseCells>();
    public Products(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
    public Products() { }
}