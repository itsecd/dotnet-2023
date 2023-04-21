using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Domain;

/// <summary>
/// Relationship between a product, a sale, and the quantity of that product
/// </summary>
public class ProductSale
{
    /// <summary>
    /// CustomerId
    /// </summary>
    public int Id { get; set; } = -1;
    /// <summary>
    /// Product ID
    /// </summary>
    [ForeignKey("ProductId")]
    public int ProductId { get; set; } = -1;

    /// <summary>
    /// Sale ID
    /// </summary>
    [ForeignKey("SaleId")]
    public int SaleId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
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

