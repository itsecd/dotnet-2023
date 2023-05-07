using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Информация о кафедре
/// </summary>
[Table("department")]
public class Department
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название кафедры
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    /// <summary>
    /// Контактный телефон заведущего кафедрой
    /// </summary>
    [Column("supervisor_number")]
    public string SupervisorNumber { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    [Column("university_id")]
    public int UniversityId { get; set; }
}
