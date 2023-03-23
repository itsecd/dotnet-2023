namespace Shop_class;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity(Product product, int shopId, double quantity)
    {
        Product = product;
        ShopId = shopId;
        Quantity = quantity;
    }
    /// <summary>
    /// Product barcode
    /// </summary>
    public Product Product { get; set; }
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; }
}
