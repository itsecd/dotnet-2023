using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a product pharmacy
/// </summary>
[Table("product_pharmacys")]
public class ProductPharmacy
{
    /// <summary>
    /// Id of productPharmacy
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Product count
    /// </summary>
    [Column("productCount")]
    public int ProductCount { get; set; } = 0;
    /// <summary>
    /// Product cost
    /// </summary>
    [Column("productCost")]
    public int ProductCost { get; set; } = 0;
    /// <summary>
    /// Products Id of product pharmacy
    /// </summary>
    [Column("productId")]
    public int ProductId { get; set; }
    /// <summary>
    /// Products of product pharmacy
    /// </summary>
    public Product Product { get; set; }
    /// <summary>
    /// Pharmacy Id of product pharmacy
    /// </summary>
    [Column("pharmacyId")]
    public int PharmacyId { get; set; }
    /// <summary>
    /// Pharmacy Id of product pharmacy
    /// </summary>
    public Pharmacy Pharmacy { get; set; }
    public ProductPharmacy() { }
    public ProductPharmacy(int productCount, int productCost, Product product, Pharmacy pharmacy, int productId, int pharmacyId, int id)
    {
        ProductCount = productCount;
        ProductCost = productCost;
        Product = product;
        Pharmacy = pharmacy;
        ProductId = productId;
        PharmacyId = pharmacyId;
        Id = id;
    }
}