using System.ComponentModel.DataAnnotations.Schema;
using UniversityData.Domain;

namespace UniversityData.Server.Dto;
/// <summary>
/// Специальность
/// </summary>
public class SpecialtyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// Записи в таблице связи
    /// </summary>
}
