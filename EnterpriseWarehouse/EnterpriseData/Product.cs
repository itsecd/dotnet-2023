using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     Product - is a class that stores information about a product
/// </summary>
public class Product
{
    /// <summary>
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    [Key]
    [Column("id")]
    public uint ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	[Column("quantity")]
    public uint Quantity { get; set; }

    /// <summary>
    ///     CellNumber - number of the cell in which the product is stored
    /// </summary>
	[Column("cellNumber")]
    public List<StorageCell> StorageCell { get; set; } = new List<StorageCell>();

    /// <summary>
    ///     CellNumber - number of the cell in which the product is stored
    /// </summary>
	[Column("invoiceContent")]
    public List<InvoiceContent> InvoiceContent { get; set; } = new List<InvoiceContent>();

    public Product(uint itemNumber, string title, uint quantity)
    {
        ItemNumber = itemNumber;
        Title = title;
        Quantity = quantity;
    }

}
