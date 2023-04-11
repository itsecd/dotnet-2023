namespace MusicMarket;

/// <summary>
/// Покупка.
/// </summary>
public class Purchase
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    public int Id;

    /// <summary>
    /// Список товаров.
    /// </summary>
    public List<Product> Products = new();

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Purchase() { }

    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Purchase(int id, List<Product> products, DateTime date, string customerName)
    {
        Id = id;
        Products = products;
        Date = date;

    }

}
