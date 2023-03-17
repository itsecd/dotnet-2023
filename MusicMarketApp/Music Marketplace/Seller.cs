namespace MusicMarket;

/// <summary>
/// Продавец.
/// </summary>
public class Seller
{
    /// <summary>
    /// ID Продавца.
    /// </summary>
    public int Id;

    /// <summary>
    /// Название магазина.
    /// </summary>
    public string ShopName { get; set; } = string.Empty;

    /// <summary>
    /// Страна доставки.
    /// </summary>
    public string CountryOfDelivery { get; set; } = string.Empty;

    /// <summary>
    /// Стоимость доставки за 1 товар.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Список товаррв.
    /// </summary>
    public List<Product> Products = new();

    public Seller() { }
    public Seller(int id, string name, string country, double price)
    {
        Id = id;
        ShopName = name;
        CountryOfDelivery = country;
        Price = price;
    }

}