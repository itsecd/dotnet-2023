namespace Shops.Domain;
/// <summary>
/// Product - class describing products
/// </summary>
public class Product
{
    public Product() { }
    public Product(string barcode, string name, int productGroupCode, double weight, string productType,
        double price, DateTime storageLimitDate)
    {
        Barcode = barcode;
        Name = name;
        ProductGroupCode = productGroupCode;
        Weight = weight;
        ProductType = productType;
        Price = price;
        StorageLimitDate = storageLimitDate;
    }
    /// <summary>
    /// Product barcode
    /// </summary>
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Product group code (milky - 1, meat - 2, fish - 3, bakery - 4, grocery - 5
    ///                     drinks - 6, candies - 7)
    /// </summary>
    public int ProductGroupCode { get; set; } = 0;
    /// <summary>
    /// Product weight
    /// </summary>
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
