namespace Shops.Domain;
/// <summary>
/// ProductQuantity - class describing quantity of products in stores
/// </summary>
public class ProductQuantity
{
    public ProductQuantity() { }
    public ProductQuantity(Product product, Shop shop, double quantity)
    {
        Product = product;
        Barcode = product.Barcode;
        Shop = shop;
        ShopId = shop.Id;
        Quantity = quantity;
    }
    /// <summary>
    /// What product 
    /// </summary>
    public Product Product { get; set; } = new Product();
    /// <summary>
    /// Product barcode
    /// </summary>
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// What shop
    /// </summary>
    public Shop Shop { get; set; } = new Shop();
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; } = 0.0;
}
