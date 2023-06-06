namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о покупке
/// </summary>
public class PurchaseGetDto
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// ID Товара.
    /// </summary>
    public int IdProduct { get; set; } = 0;
    /// <summary>
    /// ID Покупателя.
    /// </summary>
    public int IdCustomer { get; set; } = 0;

}
