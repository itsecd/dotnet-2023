namespace UniversityData.Server.Dto;

public class RectorPostDto
{
    /// <summary>
    /// Имя ректора
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Фамилия ректора
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Отчество ректора
    /// </summary>
    public string Patronymic { get; set; }
    /// <summary>
    /// Степень ректора
    /// </summary>
    public string Degree { get; set; }
    /// <summary>
    /// Звание ректора
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Должность ректора
    /// </summary>
    public string Position { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    public int UniversityiId { get; set; }
}
