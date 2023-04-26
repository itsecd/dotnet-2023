using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StoreApp.Domain;

/// <summary>
/// Relationship between a product, a sale, and the quantity of that product
/// </summary>
public class ProductSale
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Product ID
    /// </summary>
    [ForeignKey("Product")]
    [Required]
    public int ProductId { get; set; } = -1;

    /// <summary>
    /// Sale ID
    /// </summary>
    [ForeignKey("Sale")]
    [Required]
    public int SaleId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    [Required] 
    public int Quantity { get; set; } = 0;

    public ProductSale() { }

    public ProductSale(int id, int productId, int saleId, int quantity)
    {
        Id = id;
        ProductId = productId;
        SaleId = saleId;
        Quantity = quantity;
    }
}

