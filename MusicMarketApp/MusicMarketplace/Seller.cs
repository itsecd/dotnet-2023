using System.ComponentModel.DataAnnotations;

namespace MusicMarketplace;

/// <summary>
/// Продавец.
/// </summary>
public class Seller
{
    /// <summary>
    /// ID Продавца.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// Название магазина.
    /// </summary>
    [Required]
    public string ShopName { get; set; } = string.Empty;

    /// <summary>
    /// Страна доставки.
    /// </summary>
    [Required]
    public string CountryOfDelivery { get; set; } = string.Empty;
    /// <summary>
    /// Стоимость доставки за 1 товар.
    /// </summary>
    [Required]
    public double Price { get; set; }

    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Seller() { }
    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Seller(int id, string name, string country, double price)
    {
        Id = id;
        ShopName = name;
        CountryOfDelivery = country;
        Price = price;
    }

}