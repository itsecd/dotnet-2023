
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
    /// <summary>
    /// sales records
    /// </summary>
    public List<PurchaseRecord> PurchaseRecords { get; set; }

    public Shop(int shopid, List<Product> products, List<PurchaseRecord> purchaseRecords)
    {
        ShopId = shopid;
        Products = products;
        PurchaseRecords = purchaseRecords;
    }
}
