namespace UniversityData.Server.Dto;
/// <summary>
/// Узел таблицы связи специальности и количества групп
/// </summary>
public class SpecialtyTableNodePostDto
{
    /// <summary>
    /// ID специальности
    /// </summary>
    public int SpecialtyId { get; set; }
    /// <summary>
    /// Количество групп
    /// </summary>
    public int CountGroups { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    public int UniversityId { get; set; }
}
