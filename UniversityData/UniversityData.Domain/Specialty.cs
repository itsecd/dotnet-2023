

namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
public class Specialty
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    public string? SpecialtyName { get; set; } 
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string? SpecialtyCode { get; set; }
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public SpecialtyTableNode? SpecialtyNode { get; set; }
    public Specialty(string? specialtyName, string? specialtyCode)
    {
        SpecialtyName = specialtyName;
        SpecialtyCode = specialtyCode;
    }
}
