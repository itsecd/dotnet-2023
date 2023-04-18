namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharma group
/// </summary>
public class ProductPharmaGroup
{
    /// <summary>
    /// Id of product pharma group
    /// </summary>
    public int ProductPharmaGroupId { get; set; } = 0;
    /// <summary>
    /// Pharma group
    /// </summary>
    public PharmaGroup PharmaGroup { get; set; }
    /// <summary>
    /// Product of pharma group
    /// </summary>
    public Product Product { get; set; }
    public ProductPharmaGroup() { }
    public ProductPharmaGroup(int productPharmaGroupId, PharmaGroup pharmaGroup, Product product)
    {
        ProductPharmaGroupId = productPharmaGroupId;
        PharmaGroup = pharmaGroup;
        Product = product;
    }
}