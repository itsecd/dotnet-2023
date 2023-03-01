

namespace UniversityData.Domain;
/// <summary>
/// Информация об университете
/// </summary>
public class University
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
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

    public University(string? universityNumber, string? universityName, string? universityAddress, Rector? universityRectorData, string? universityProperty, string? universityConstructionProperty, List<Faculty>? universityFacultiesData, List<Department>? universityDepartmentsData, List<SpecialtyTableNode>? universitySpecialtyTable)
    {
        UniversityNumber = universityNumber;
        UniversityName = universityName;
        UniversityAddress = universityAddress;
        UniversityRectorData = universityRectorData;
        UniversityProperty = universityProperty;
        UniversityConstructionProperty = universityConstructionProperty;
        UniversityFacultiesData = universityFacultiesData;
        UniversityDepartmentsData = universityDepartmentsData;
        UniversitySpecialtyTable = universitySpecialtyTable;
    }
}