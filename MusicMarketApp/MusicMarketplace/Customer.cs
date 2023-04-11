namespace MusicMarket;

/// <summary>
/// Покупатель.
/// </summary>
public class Customer
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
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// История заказов. 
    /// </summary>
    public List<Purchase> Purchases = new();

    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Customer() { }
    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Customer(int id, string name, string country, string address, List<Purchase> purchases)
    {
        Id = id;
        Name = name;
        Country = country;
        Address = address;
        Purchases = purchases;
    }
}   
