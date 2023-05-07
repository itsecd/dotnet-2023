using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
[Table("specialty")]
public class Specialty
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    [Column("code")]
    public string Code { get; set; }
}
