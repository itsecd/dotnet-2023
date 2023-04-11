using MusicMarket;

namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о покупке
/// </summary>
public class PurchasePostDto
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    public int Id;

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    public DateTime Date { get; set; }
}
