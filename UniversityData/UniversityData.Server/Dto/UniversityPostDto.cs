namespace UniversityData.Server.Dto;
/// <summary>
/// PostDto университета
/// </summary>
public class UniversityPostDto
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Адрес университета
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// ID ректора
    /// </summary>
    public int RectorId { get; set; }
    /// <summary>
    /// ID собственности организации
    /// </summary>
    public int UniversityPropertyId { get; set; }
    /// <summary>
    /// ID собственности зданий университета
    /// </summary>
    public int ConstructionPropertyId { get; set; }
}
