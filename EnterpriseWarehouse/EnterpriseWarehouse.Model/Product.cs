using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseWarehouse.Model;

/// <summary>
///     Product - is a class that stores information about a product
/// </summary>
[Table("product")]
public class Product
{
    /// <summary>
    ///     Id - identifier of the product in database
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    [Column("item_number")]
    public int ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	[Column("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    ///     CellNumber - number of the cell in which the product is stored
    /// </summary>
	[Column("cell_number")]
    public ICollection<StorageCell> StorageCell { get; set; } = new List<StorageCell>();

    /// <summary>
    ///     InvoicesContent - invoice information
    /// </summary>
	[Column("invoice_content")]
    public IList<InvoiceContent> InvoicesContent { get; } = new List<InvoiceContent>();

    public Product(int itemNumber, string title, int quantity)
    {
        ItemNumber = itemNumber;
        Title = title;
        Quantity = quantity;
    }

    public Product() { }
}
