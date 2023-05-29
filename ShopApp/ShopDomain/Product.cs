using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopsDomain;
/// <summary>
/// Product - class describing products
/// </summary>
public class Product
{
    public Product() { }
    public Product(int id, string barcode, string name, int productGroupId, double weight, string productType,
        double price, DateTime storageLimitDate)
    {
        Id = id;
        Barcode = barcode;
        Name = name;
        ProductGroupId = productGroupId;
        Weight = weight;
        ProductType = productType;
        Price = price;
        StorageLimitDate = storageLimitDate;
    }
    /// <summary>
    /// Id is used to product the ID.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Product barcode
    /// </summary>
    [Required]
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// Product name
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Product group code 
    /// </summary>
    [ForeignKey("ProductGroup")]
    public int ProductGroupId { get; set; } = 0;
    /// <summary>
    /// ProductGroup is used to store information about the product group
    /// </summary>
    public ProductGroup? ProductGroup { get; set; }
    /// <summary>
    /// Product weight
    /// </summary>
    [Required]
    public double Weight { get; set; } = 0.0;
    /// <summary>
    /// Product type (piece or bulk)
    /// </summary>
    [Required]
    public string ProductType { get; set; } = string.Empty;
    /// <summary>
    /// Product price
    /// </summary>
    [Required]
    public double Price { get; set; } = 0.0;
    /// <summary>
    /// Storage limit date
    /// </summary>
    [Required]
    public DateTime StorageLimitDate { get; set; } = new DateTime();
}
