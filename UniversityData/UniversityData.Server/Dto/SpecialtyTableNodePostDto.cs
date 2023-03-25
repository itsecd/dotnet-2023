namespace UniversityData.Server.Dto;

public class SpecialtyTableNodePostDto
{
    /// <summary>
    /// ID специальности
    /// </summary>
    public int SpecialtyID { get; set; }
    /// <summary>
    /// Количество групп
    /// </summary>
    public int CountGroups { get; set; }
    /// <summary>
    /// ID университета
    /// </summary>
    public int UniversityId { get; set; }
}
