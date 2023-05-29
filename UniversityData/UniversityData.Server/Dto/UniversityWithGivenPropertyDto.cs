namespace UniversityData.Server.Dto;
/// <summary>
/// Информация об университете с заданной собственностью 
/// </summary>
public class UniversityWithGivenPropertyDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Количество групп
    /// </summary>
    public int CountGroups { get; set; }
    /// <summary>
    /// ID собственности университета
    /// </summary>
    public int UniversityPropertyId { get; set; }
}
