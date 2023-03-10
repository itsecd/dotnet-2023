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
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    public string Surname { get; set; } = string.Empty;
    /// <summary>
    /// Отчество ректора
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// Степень ректора
    /// </summary>
    public string Degree { get; set; } = string.Empty;
    /// <summary>
    /// Звание ректора
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Должность ректора
    /// </summary>
    public string Position { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? University { get; set; }
}
