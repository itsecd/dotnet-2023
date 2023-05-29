namespace UniversityData.Server.Dto;
/// <summary>
/// Информация о количестве подразделений университета с заданным собственностями организации и зданий
/// </summary>
public class CountDivisionsWithDifferentProperties
{
    /// <summary>
    /// Количество кафедр
    /// </summary>
    public int CountDepartments { get; set; }
    /// <summary>
    /// Количество факультетов
    /// </summary>
    public int CountFaculties { get; set; }
    /// <summary>
    /// Количество специальностей
    /// </summary>
    public int CountSpecialties { get; set; }
    /// <summary>
    /// ID собственности университета
    /// </summary>
    public int UniversityPropertyId { get; set; }
    /// <summary>
    /// ID собственности зданий
    /// </summary>
    public int ConstructionPropertyId { get; set; }

}
