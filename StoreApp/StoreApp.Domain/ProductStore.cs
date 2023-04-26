using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StoreApp.Domain;

/// <summary>
/// Relationship between a product, a store, and the quantity of that product
/// </summary>
public class ProductStore
{
    /// <summary>
    /// CustomerId
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
    /// Store ID
    /// </summary>
    [ForeignKey("Store")]
    [Required]
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    [Required] 
    public int Quantity { get; set; } = 0;

    public ProductStore() { }

    public ProductStore(int id, int productId, int storeId, int quantity)
    {
        Id = id;
        ProductId = productId;
        StoreId = storeId;
        Quantity = quantity;
    }
}

