namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a product pharmacy
/// </summary>
public class ProductPharmacy
{
    /// <summary>
    /// Product count
    /// </summary>
    public int ProductCount { get; set; } = 0;
    /// <summary>
    /// Product cost
    /// </summary>
    public int ProductCost { get; set; } = 0;
    /// <summary>
    /// Products of product pharmacy
    /// </summary>
    public int ProductId { get; set; }
    public Product Product { get; set; }
    /// <summary>
    /// Pharmacy of product pharmacy
    /// </summary>
    public int PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; }
    public ProductPharmacy() { }
    public ProductPharmacy(int productCount, int productCost, Product product, Pharmacy pharmacy, int productId, int pharmacyId)
    {
        ProductCount = productCount;
        ProductCost = productCost;
        Product = product;
        Pharmacy = pharmacy;
        ProductId = productId;
        PharmacyId = pharmacyId;
    }
}