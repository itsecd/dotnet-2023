namespace UniversityData.Server.Dto;
/// <summary>
/// GetDto собственности организации
/// </summary>
public class UniversityPropertyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название собственности университета
    /// </summary>
    public string NameUniversityProperty { get; set; }
}
