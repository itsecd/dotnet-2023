namespace PharmacyCityNetwork;

/// <summary>
/// Сlass describing a product pharmacy
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
    public Product Product { get; set; }
    /// <summary>
    /// Pharmacys of product pharmacy
    /// </summary>
    public Pharmacy Pharmacy { get; set; }
    public ProductPharmacy() { }
    public ProductPharmacy(int productCount, int productCost, Product product, Pharmacy pharmacy)
    {
        ProductCount = productCount;
        ProductCost = productCost;
        Product = product;
        Pharmacy = pharmacy;
    }
}