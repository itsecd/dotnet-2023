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
    public int IdProduct { get; set; }

    [ForeignKey("IdProduct")]
    public Product Product { get; set; }

    /// <summary>
    /// ID Покупателя.
    /// </summary>
    public int IdCustomer { get; set; }

    [ForeignKey("IdCustomer")]
    public Customer Customer { get; set; }

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
