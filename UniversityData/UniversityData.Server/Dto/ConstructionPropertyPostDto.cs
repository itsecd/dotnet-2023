using System.ComponentModel.DataAnnotations.Schema;
using UniversityData.Domain;

namespace UniversityData.Server.Dto;
/// <summary>
/// Собственность зданий университета
/// </summary>
public class ConstructionPropertyPostDto
{
    /// <summary>
    /// Название собственности зданий университета
    /// </summary>
    public string NameConstructionProperty { get; set; }
}