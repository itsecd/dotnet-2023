namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a product
/// </summary>
public class Product
{
    /// <summary>
    /// Id of product
    /// </summary>
    public int ProductId { get; set; } = 0;
    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Product group
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// Product manufacturer
    /// </summary>
    public Manufacturer Manufacturer { get; set; }
    /// <summary>
    /// ProductPharmacys of product
    /// </summary>
    public List<ProductPharmacy> ProductPharmacys { get; set; } = new List<ProductPharmacy>();
    /// <summary>
    /// ProductPharmaGroups of product
    /// </summary>
    public List<ProductPharmaGroup> ProductPharmaGroups { get; set; } = new List<ProductPharmaGroup>();
    /// <summary>
    /// Sales of product
    /// </summary>
    public List<Sale> Sales { get; set; } = new List<Sale>();
    public Product() { }
    public Product(string productName, int productId, Group group, Manufacturer manufacturer)
    {
        ProductName = productName;
        ProductId = productId;
        Group = group;
        Manufacturer = manufacturer;
    }
}