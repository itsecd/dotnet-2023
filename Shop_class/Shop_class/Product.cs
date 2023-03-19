namespace Shop_class;
/// <summary>
/// Product - class describing products
/// </summary>
public class Product
{
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
    public int PoductGroupCode { get; set; }
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
    public DateOnly StorageLimitDate { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; }

    public Product(string barcode, string name, int poductgroupcode, double weight, string producttype,
        double price, DateOnly storagelimitdate, double quantity)
    {
        Barcode = barcode;
        Name = name;
        PoductGroupCode = poductgroupcode;
        Weight = weight;
        ProductType = producttype;
        Price = price;
        StorageLimitDate = storagelimitdate;
        Quantity = quantity;
    }
}
