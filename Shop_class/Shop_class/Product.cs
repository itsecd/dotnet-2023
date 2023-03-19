namespace Shop_class;
public class Product
{
    public string Barcode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Poduct_group_code { get; set; }
    public double Weight { get; set; }
    public string Product_type { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime Storage_limit_date { get; set; }
    public double Quantity { get; set; }

    public Product(string barcode, string name, int poduct_group_code, double weight, string product_type,
        double price, DateTime storage_limit_date, double quantity)
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
