namespace UniversityData.Server.Dto;
/// <summary>
/// Информация о структуре университета
/// </summary>
public class UniversityStructureDto
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
}
