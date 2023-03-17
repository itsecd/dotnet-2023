using System.Collections.Generic;

namespace MusicMarket;

/// <summary>
/// Покупатель.
/// </summary>
public class Сustomer
{
    /// <summary>
    /// ID Покупателя.
    /// </summary>
    public int Id;

    /// <summary>
    /// Ф.И.О.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Страна проживания.
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Адрес.
    /// </summary>
    public string Adress { get; set; } = string.Empty;

    /// <summary>
    /// История заказов. 
    /// </summary>
    public List<Purchase> Purchases = new();

    public Сustomer() { }

    public Сustomer(int id, string name, string country, string adress, List<Purchase> purchases)
    {
        Id = id;
        Name = name;
        Country = country;
        Adress = adress;
        Purchases = purchases;
    }
}   
