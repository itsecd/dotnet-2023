using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     InvoiceContent - is the class that links the quantity of goods purchased to the invoice
/// </summary>
public class InvoiceContent
{
    /// <summary>
    ///     Id - number of the invoice content
    /// </summary>
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    /// <summary>
    ///     InvoiceId - number of the invoice
    /// </summary>
    [ForeignKey("Invoice")]
    [Column("invoiceId")]
    public uint InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    /// <summary>
    ///     ProductItemNumber - item number of the product
    /// </summary>
    [ForeignKey("Product")]
    [Column("productId")]
    public uint ProductItemNumber { get; set; }
    public Product Product { get; set; }

    /// <summary>
    ///     Quantity - quantity of goods purchased
    /// </summary>
    [Column("quantity")]
    public uint Quantity { get; set; }

    public InvoiceContent(uint id, Invoice invoice, Product product, uint quantity)
    {
        Id = id;
        Invoice = invoice;
        Product = product;
        Quantity = quantity;
    }
}
