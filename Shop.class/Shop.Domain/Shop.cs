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
    public string? Name { get; set; }
    public string? Adress { get; set; }
    /// <summary>
    /// Products in shop
    /// </summary>
    public List<ProductQuantity> Products { get; set; } = new List<ProductQuantity>();
    /// <summary>
    /// Sales records
    /// </summary>
    public List<PurchaseRecord> PurchaseRecords { get; set; } = new List<PurchaseRecord>();
    public Shop() { }
    public Shop(int id, string name, string adress, List<ProductQuantity> products, List<PurchaseRecord> purchaseRecords)
    {
        Id = id;
        Name = name;
        Adress = adress;
        Products = products;
        PurchaseRecords = purchaseRecords;
    }
}
