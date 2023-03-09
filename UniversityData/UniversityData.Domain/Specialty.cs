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
    public string SpecialtyName { get; set; } = string.Empty; 
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string SpecialtyCode { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public SpecialtyTableNode? SpecialtyNode { get; set; }
   
}
