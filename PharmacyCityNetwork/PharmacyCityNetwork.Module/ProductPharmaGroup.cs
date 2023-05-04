using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharma group
/// </summary>
[Table("product_pharma_groups")]
public class ProductPharmaGroup
{
    /// <summary>
    /// Id of product pharma group
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Pharma group Id
    /// </summary>
    [Column("pharmaGroupId")]
    public int PharmaGroupId { get; set; }
    /// <summary>
    /// Product Id of pharma group
    /// </summary>
    [Column("productId")]
    public int ProductId { get; set; }
    /// <summary>
    /// Pharma group
    /// </summary>
    public PharmaGroup PharmaGroup { get; set; }
    /// <summary>
    /// Product of pharma group
    /// </summary>
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