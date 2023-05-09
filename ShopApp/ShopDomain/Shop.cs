using System.ComponentModel.DataAnnotations;

namespace Shops.Domain;
/// <summary>
/// Shop - class describes shop 
/// </summary>
public class Shop
{
    /// <summary>
    /// Shop id
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Shop name
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Shop address
    /// </summary>
    [Required]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Products in shop
    /// </summary>
    public List<ProductQuantity> Products { get; set; } = new List<ProductQuantity>();
    /// <summary>
    /// Sales records
    /// </summary>
    public List<PurchaseRecord> PurchaseRecords { get; set; } = new List<PurchaseRecord>();
    public Shop() { }
    public Shop(int id, string name, string address, List<ProductQuantity> products, List<PurchaseRecord> purchaseRecords)
    {
        Id = id;
        Name = name;
        Address = address;
        Products = products;
        PurchaseRecords = purchaseRecords;
    }
}
