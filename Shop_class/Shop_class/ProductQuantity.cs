namespace Shop_class;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity(string barcode, int shopId, double quantity)
    {
        Barcode = barcode;
        ShopId = shopId;
        Quantity = quantity;
    }
    /// <summary>
    /// Product barcode
    /// </summary>
    public string Barcode { get; set; }
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; }

}
