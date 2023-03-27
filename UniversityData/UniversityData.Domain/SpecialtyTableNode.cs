namespace UniversityData.Domain;
/// <summary>
/// Узел таблицы связи специальности и количества групп
/// </summary>
public class SpecialtyTableNode
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Специальность
    /// </summary>
    public Specialty Specialty { get; set; }
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
