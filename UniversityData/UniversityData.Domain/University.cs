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
    public string UniversityNumber { get; set; } = string.Empty;
    /// <summary>
    /// Название университета
    /// </summary>
    public string UniversityName { get; set; } = string.Empty;
    /// <summary>
    /// Адрес университета
    /// </summary>
    public string UniversityAddress { get; set; } = string.Empty;
    /// <summary>
    /// Сведения о ректоре 
    /// </summary>
    public Rector? UniversityRectorData { get; set; }  
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public string UniversityProperty { get; set; } = string.Empty; 
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public string UniversityConstructionProperty { get; set; } = string.Empty;
    /// <summary>
    /// Факультеты университета
    /// </summary>
    public List<Faculty> UniversityFacultiesData { get; set; } = new List<Faculty>();
    /// <summary>
    /// Кафедры университета
    /// </summary>
    public List<Department> UniversityDepartmentsData { get; set; } = new List<Department>();
    /// <summary>
    /// Таблица связи специальность-количетсов групп
    /// </summary>
    public List<SpecialtyTableNode> UniversitySpecialtyTable { get; set; } = new List<SpecialtyTableNode>();
}