using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     StorageCell - is a class linking the cell number and the product stored in it
/// </summary>
[Table("storage_cell")]
public class StorageCell
{
    /// <summary>
    ///     Id - identifier of the storage cell in database
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    ///     Number - cell number
    /// </summary>
    [Column("cell_number")]
    public int Number { get; set; }

    /// <summary>
    ///     ProductID - unique identifier of the product 
    /// </summary>
    public int ProductID { get; set; }
    [ForeignKey("ProductID")]
    [Column("product_id")]
    public Product Product { get; set; }

    public StorageCell(int number, Product product)
    {
        Number = number;
        Product = product;
    }
    public StorageCell() { }
}