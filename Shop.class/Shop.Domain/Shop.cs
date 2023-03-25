namespace Shops.Domain;
/// <summary>
/// Shop - class describes shop 
/// </summary>
public class Shop
{
    /// <summary>
    /// Shop id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Products in shop
    /// </summary>
    public List<ProductQuantity> Products { get; set; } = new List<ProductQuantity>();
    /// <summary>
    /// Sales records
    /// </summary>
    public List<PurchaseRecord> PurchaseRecords { get; set; } = new List<PurchaseRecord>();
    public Shop() { }
    public Shop(int id, List<ProductQuantity> products, List<PurchaseRecord> purchaseRecords)
    {
        Id = id;
        Products = products;
        PurchaseRecords = purchaseRecords;
    }
}
