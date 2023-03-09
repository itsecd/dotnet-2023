namespace UniversityData.Domain;
/// <summary>
/// Информация о ректор
/// </summary>
public class Rector
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя ректора
    /// </summary>
    public string RectorName { get; set; } = string.Empty;
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    public string RectorSurname { get; set; } = string.Empty;
    /// <summary>
    /// Отчество ректора
    /// </summary>
    public string RectorPatronymic { get; set; } = string.Empty;
    /// <summary>
    /// Степень ректора
    /// </summary>
    public string RectorDegree { get; set; } = string.Empty;
    /// <summary>
    /// Звание ректора
    /// </summary>
    public string RectorTitle { get; set; } = string.Empty;
    /// <summary>
    /// Должность ректора
    /// </summary>
    public string RectorPosition { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? RectorUniversity { get; set; }
}
