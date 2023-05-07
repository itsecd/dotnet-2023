using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Информация о факультете 
/// </summary>
[Table("faculty")]
public class Faculty
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название факультета
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    /// <summary>
    /// Количество сотрудников факультета
    /// </summary>
    [Column("workers_count")]
    public int WorkersCount { get; set; }
    /// <summary>
    /// Количество студентов факультета
    /// </summary>
    [Column("students_count")]
    public int StudentsCount { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    [Column("university_id")] 
    public int UniversityId { get; set; }
}
