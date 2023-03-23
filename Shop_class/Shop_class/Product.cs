namespace Shop_class;
/// <summary>
/// Product - class describing products
/// </summary>
public class Product
{
    public Product(string barcode, string name, int poductGroupCode, double weight, string productType,
        double price, DateTime storageLimitDate)
    {
        Barcode = barcode;
        Name = name;
        ProductGroupCode = poductGroupCode;
        Weight = weight;
        ProductType = productType;
        Price = price;
        StorageLimitDate = storageLimitDate;
    }
    /// <summary>
    /// Product barcode
    /// </summary>
    public string Barcode { get; set; }
    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Product group code (milky - 1, meat - 2, fish - 3, bakery - 4, grocery - 5
    ///                     drinks - 6, candies - 7)
    /// </summary>
    public int ProductGroupCode { get; set; }
    /// <summary>
    /// Product weight
    /// </summary>
    public double Weight { get; set; }
    /// <summary>
    /// Product type (piece or bulk)
    /// </summary>
    public string ProductType { get; set; }
    /// <summary>
    /// Product price
    /// </summary>
    public double Price { get; set; }
    /// <summary>
    /// Storage limit date
    /// </summary>
    public DateTime StorageLimitDate { get; set; }
}
