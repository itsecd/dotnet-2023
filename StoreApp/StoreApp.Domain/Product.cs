using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StoreApp.Domain;

/// <summary>
/// Product - Class describing the product
/// </summary>
public class Product
{
    /// <summary>
    /// Product ID, corresponds to its barcode
    /// </summary>
    [Key]
    public int ProductId { get; set; }

    /// <summary>
    /// Product Group
    /// </summary>
    [Required] 
    public int ProductGroup { get; set; } = -1;

    /// <summary>
    /// Product name
    /// </summary>
    [Required] 
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Product weight
    /// </summary>
    [Required] 
    public double ProductWeight { get; set; } = 0.0;

    /// <summary>
    /// Product type (piece, weighted) piece -> true | weighted -> false
    /// </summary>
    [Required] 
    public bool ProductType { get; set; } = false;

    /// <summary>
    /// Product price
    /// </summary>
    [Required] 
    public double ProductPrice { get; set; } = -1.0;

    /// <summary>
    /// Product deadline date storage
    /// </summary>
    [Required] 
    public DateTime DateStorage { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Collection ProductSale
    /// </summary>
    public List<ProductSale> ProductSales { get; set; } = null!;

    /// <summary>
    /// Collection ProductStore
    /// </summary>
    public List<ProductStore> ProductStores { get; set; } = null!;

    public Product() { }

    public Product(int productId, int productGroup, string productName, double productWeight, bool productType, double productPrice, string dateStorage)
    {
        ProductId = productId;
        ProductGroup = productGroup;
        ProductName = productName;
        ProductWeight = productWeight;
        ProductType = productType;
        ProductPrice = productPrice;
        DateStorage = DateTime.Parse(dateStorage);
        ProductSales = new List<ProductSale>();
        ProductStores = new List<ProductStore>();
    }
}

