using System.ComponentModel.DataAnnotations;

namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о покупке
/// </summary>
public class PurchaseGetDto
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    [Key]
    public int Id;

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// ID Товара.
    /// </summary>
    public int IdProduct;
    /// <summary>
    /// ID Покупателя.
    /// </summary>
    public int IdCustomer;

}
