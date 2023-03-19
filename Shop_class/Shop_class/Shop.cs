
namespace Shop_class;
/// <summary>
/// Shop - class describes shop 
/// </summary>
public class Shop
{
    /// <summary>
    /// shop id
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// products in shop
    /// </summary>
    public List<Product> Products { get; set; } 

    public Shop(int shopid, List<Product> products)
    {
        ShopId = shopid;
        Products = products;
    }

}
