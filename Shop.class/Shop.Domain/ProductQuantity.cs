namespace Shops.Domain;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity() { }

    public ProductQuantity(string barcode, int shopId, double quantity)
    {
        Barcode = barcode;
        ShopId = shopId;
        Quantity = quantity;
    }
    /// <summary>
    /// Product barcode
    /// </summary>
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; } = 0;
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; } = 0.0;
}
