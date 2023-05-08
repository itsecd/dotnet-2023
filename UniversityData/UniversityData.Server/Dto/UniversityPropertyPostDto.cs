using System.ComponentModel.DataAnnotations.Schema;
using UniversityData.Domain;

namespace UniversityData.Server.Dto;
/// <summary>
/// Собственность университета
/// </summary>
public class UniversityPropertyPostDto
{
    /// <summary>
    /// Название собственности университета
    /// </summary>
    public string NameUniversityProperty { get; set; }
}
