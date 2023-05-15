using System.ComponentModel.DataAnnotations;

namespace MusicMarketServer.Dto;
/// <summary>
/// Информация о покупателе
/// </summary>
public class CustomerGetDto
{
    /// <summary>
    /// ID Покупателя.
    /// </summary>
    [Key]
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
}
