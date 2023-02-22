

namespace UniversityData.Domain;
/// <summary>
/// Информация об университете
/// </summary>
public class University
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string? UniversityNumber { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    public string? UniversityName { get; set; }
    /// <summary>
    /// Адрес университета
    /// </summary>
    public string? UniversityAddress { get; set; }
    /// <summary>
    /// Сведения о ректоре 
    /// </summary>
    public Rector? UniversityRectorData { get; set; }
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public string? UniversityProperty { get; set; } 
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public string? UniversityConstructionProperty { get; set; }
    /// <summary>
    /// Факультеты университета
    /// </summary>
    public List<Faculty>? UniversityFacultiesData { get; set; } 
    /// <summary>
    /// Кафедры университета
    /// </summary>
    public List<Department>? UniversityDepartmentsData { get; set; }
    /// <summary>
    /// Таблица связи специальность-количетсов групп
    /// </summary>
    public List<SpecialtyTableNode>? UniversitySpecialtyTable { get; set; }
}