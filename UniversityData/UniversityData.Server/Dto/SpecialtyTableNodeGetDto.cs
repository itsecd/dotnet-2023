namespace UniversityData.Server.Dto;

public class SpecialtyTableNodeGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Специальность
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
