namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о покупателе
/// </summary>
public class CustomerPostDto
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
}
