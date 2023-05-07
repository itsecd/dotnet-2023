using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Собственность зданий
/// </summary>
[Table("construction_property")]
public class ConstructionProperty
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Название собственности зданий университета
    /// </summary>
    [Column("name_construction_property")]
    public string NameConstructionProperty { get; set; }
}
