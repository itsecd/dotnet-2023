namespace UniversityData.Server.Dto;
/// <summary>
/// GetDto собственности зданий университета
/// </summary>
public class ConstructionPropertyGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название собственности зданий университета
    /// </summary>
    public string NameConstructionProperty { get; set; }
}
