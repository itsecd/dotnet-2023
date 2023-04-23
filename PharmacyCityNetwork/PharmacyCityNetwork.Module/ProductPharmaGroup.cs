namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharma group
/// </summary>
public class ProductPharmaGroup
{
    /// <summary>
    /// Id of product pharma group
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Pharma group
    /// </summary>
    public int PharmaGroupId { get; set; }
    public PharmaGroup PharmaGroup { get; set; }
    /// <summary>
    /// Product of pharma group
    /// </summary>
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public ProductPharmaGroup() { }
    public ProductPharmaGroup(int id, PharmaGroup pharmaGroup, Product product, int pharmaGroupId, int productId)
    {
        Id = id;
        PharmaGroup = pharmaGroup;
        Product = product;
        PharmaGroupId = pharmaGroupId;
        ProductId = productId;
    }
}