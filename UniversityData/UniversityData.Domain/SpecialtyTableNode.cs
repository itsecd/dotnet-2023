

namespace UniversityData.Domain;
/// <summary>
/// Узел таблицы связи специальности и количества групп
/// </summary>
public class SpecialtyTableNode
{
    /// <summary>
    /// Специальность
    /// </summary>
    public Specialty? Specialty { get; set; }
    /// <summary>
    /// Количетсов групп
    /// </summary>
    public int CountGroups { get; set; }

    public SpecialtyTableNode(Specialty? specialty, int countGroups)
    {
        Specialty = specialty;
        CountGroups = countGroups;
    }
}
