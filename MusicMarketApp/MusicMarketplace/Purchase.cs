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
    /// ID Товара.
    /// </summary>
    public int IdProduct;

    /// <summary>
    /// ID Покупателя.
    /// </summary>
    public int IdCustomer;

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
    public Purchase(int id, int product, DateTime date, int customer)
    {
        Id = id;
        IdProduct = product;
        IdCustomer = customer;
        Date = date;

    }

}
