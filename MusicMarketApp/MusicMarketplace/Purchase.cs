using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMarket;

/// <summary>
/// Покупка.
/// </summary>
public class Purchase
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// ID Товара.
    /// </summary>
    [ForeignKey("IdProduct")]
    public int IdProduct;

    /// <summary>
    /// ID Покупателя.
    /// </summary>
    [ForeignKey("IdCustomer")]
    public int IdCustomer;

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    [Required]
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
