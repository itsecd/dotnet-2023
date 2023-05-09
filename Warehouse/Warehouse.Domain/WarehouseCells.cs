using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Domain;

/// <summary>
///     Class WarehouseCells is used to store info about the warehouse cells
/// </summary>
public class WarehouseCells
{
    /// <summary>
    ///     CellNumber - cell number 
    /// </summary>  
    [Key]
    [Column("cell_number")]
    public int CellNumber { set; get; }
    /// <summary>
    ///     Product - product, what contain in cell 
    /// </summary>
    public Products Product { set; get; }
    [ForeignKey("Product")]
    [Column("product_id")]
    public int ProductId { set; get; }
    public WarehouseCells(int cell, Products product)
    {
        CellNumber = cell;
        Product = product;
    }
    public WarehouseCells() { }
}