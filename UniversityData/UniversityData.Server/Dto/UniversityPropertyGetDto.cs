using System.ComponentModel.DataAnnotations.Schema;
using UniversityData.Domain;

namespace UniversityData.Server.Dto;
/// <summary>
/// Собственность университета
/// </summary>
public class UniversityPropertyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название собственности университета
    /// </summary>
    public string NameUniversityProperty { get; set; }
}
