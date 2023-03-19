namespace Shop_class;
/// <summary>
/// Product - class describing products
/// </summary>
public class Product
{
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
    public int Poduct_group_code { get; set; }
    /// <summary>
    /// Product weight
    /// </summary>
    public double Weight { get; set; } = 0.0;
    /// <summary>
    /// Product type (piece or bulk)
    /// </summary>
    public string Product_type { get; set; } = string.Empty;
    /// <summary>
    /// Product price
    /// </summary>
    public double Price { get; set; }
    /// <summary>
    /// Storage limit date
    /// </summary>
    public DateOnly Storage_limit_date { get; set; }
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; }

    public Product(string barcode, string name, int poduct_group_code, double weight, string product_type,
        double price, DateOnly storage_limit_date, double quantity)
    {
        Barcode = barcode;
        Name = name;
        Poduct_group_code = poduct_group_code;
        Weight = weight;
        Product_type = product_type;
        Price = price;
        Storage_limit_date = storage_limit_date;
        Quantity = quantity;
    }
}
