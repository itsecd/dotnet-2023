using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Узел таблицы связи специальности и количества групп
/// </summary>
[Table("specialty_table_node")]
public class SpecialtyTableNode
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Специальность
    /// </summary>
    public Specialty Specialty { get; set; }
    /// <summary>
    /// ID специальности
    /// </summary>
    [Column("specialty_id")]
    public int SpecialtyId { get; set; }
    /// <summary>
    /// Количество групп
    /// </summary>
    [Column("count_groups")]
    public int CountGroups { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    [Column("university_id")]
    public int UniversityId { get; set; }
    /// <summary>
    /// Университет
    /// </summary>
    public University? University { get; set; }
}
