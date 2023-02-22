

namespace UniversityData.Domain;
/// <summary>
/// Информация о ректор
/// </summary>
public class Rector
{
    /// <summary>
    /// Имя ректора
    /// </summary>
    public string? RectorName { get; set; }
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    public string? RectorSurname { get; set; }
    /// <summary>
    /// Отчество ректора
    /// </summary>
    public string? RectorPatronymic { get; set; }
    /// <summary>
    /// Степень ректора
    /// </summary>
    public string? RectorDegree { get; set; }
    /// <summary>
    /// Звание ректора
    /// </summary>
    public string? RectorTitle { get; set; }
    /// <summary>
    /// Должность ректора
    /// </summary>
    public string? RectorPosition { get; set; }

}
