using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsDomain;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity() { }
    public ProductQuantity(int id, int productId, int shopId, double quantity)
    {
        Id = id;
        ProductId = productId;
        ShopId = shopId;
        Quantity = quantity;
    }
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Product barcode
    /// </summary>
    [ForeignKey("Product")]
    public int ProductId { get; set; } = 0;
    /// <summary>
    /// Product is used to store information about the product
    /// </summary>
    public Product? Product { get; set; }
    /// <summary>
    /// Shop id
    /// </summary>
    [ForeignKey("Shop")]
    public int ShopId { get; set; } = 0;
    /// <summary>
    /// Shop is used to store information about the shop
    /// </summary>
    public Shop? Shop { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    [Required]
    public double Quantity { get; set; } = 0.0;
}
