using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shops.Domain;
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
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Product group code 
    /// </summary>
    public int ProductGroupId { get; set; } = 0;
    /// <summary>
    /// Product weight
    /// </summary>
    public ProductGroup? ProductGroup { get; set; }
    public double Weight { get; set; } = 0.0;
    /// <summary>
    /// Product type (piece or bulk)
    /// </summary>
    public string ProductType { get; set; } = string.Empty;
    /// <summary>
    /// Product price
    /// </summary>
    public double Price { get; set; } = 0.0;
    /// <summary>
    /// Storage limit date
    /// </summary>
    public DateTime StorageLimitDate { get; set; } = new DateTime();
}
