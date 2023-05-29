namespace UniversityData.Server.Dto;
/// <summary>
/// Специальность с максимальным количеством групп
/// </summary>
public class MostPopularSpecialtyDto
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
    /// Количество групп
    /// </summary>
    public int CountGroups { get; set; }
}
