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
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public SpecialtyTableNode? Node { get; set; }

}
