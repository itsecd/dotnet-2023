using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Собственность университета
/// </summary>
[Table("university_property")]
public class UniversityProperty
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название собственности университета
    /// </summary>
    [Column("name_university_property")]
    public string NameUniversityProperty { get; set; }
}
