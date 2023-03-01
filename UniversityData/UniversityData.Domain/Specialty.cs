

namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
public class Specialty
{
    /// <summary>
    /// Название специальности
    /// </summary>
    public string? SpecialtyName { get; set; } 
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string? SpecialtyCode { get; set; }

    public Specialty(string? specialtyName, string? specialtyCode)
    {
        SpecialtyName = specialtyName;
        SpecialtyCode = specialtyCode;
    }
}
