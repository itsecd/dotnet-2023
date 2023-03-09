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
    public Specialty? Specialty { get; set; }
    /// <summary>
    /// Количетсов групп
    /// </summary>
    public int CountGroups { get; set; }
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? TableNodeUniversity { get; set; }
}
