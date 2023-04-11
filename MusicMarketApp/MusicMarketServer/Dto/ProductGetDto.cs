using MusicMarket;

namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о товаре
/// </summary>
public class ProductGetDto
{
    /// <summary>
    /// ID Товара.
    /// </summary>
    public int Id;

    /// <summary>
    /// Тип аудионосителя: диск|кассета|виниловая пластинка.
    /// </summary>
    public string TypeOfCarrier { get; set; } = string.Empty;

    /// <summary>
    /// Тип издания: альбом|сингл.
    /// </summary>
    public string PublicationType { get; set; } = string.Empty;

    /// <summary>
    /// Исполнитель
    /// </summary>
    public string Creator { get; set; } = string.Empty;

    /// <summary>
    /// Название 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Страна издания.
    /// </summary>
    public string MadeIn { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние аудионосителя: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    public string MediaStatus { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние упаковки: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    public string PackagingCondition { get; set; } = string.Empty;

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Cтатус: в продаже || продан. 
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// ID Продавца.
    /// </summary>
    public int SellerId { get; set; }
}
