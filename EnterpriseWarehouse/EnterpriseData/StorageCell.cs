using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     StorageCell - is a class linking the cell number and the product stored in it
/// </summary>
public class StorageCell
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    /// 
    [Key]
    [Column("cellNumber")]
    public uint Number { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product 
    /// </summary>
    [ForeignKey("Product")]
    [Column("productId")]
    public uint ItemNumberProducts { get; set; }
    public Product Product { get; set; }

    public StorageCell(uint number, Product product)
    {
        Number = number;
        Product = product;
    }
}