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
    public string Number { get; set; } = string.Empty;
    /// <summary>
    /// Название университета
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Адрес университета
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Сведения о ректоре 
    /// </summary>
    public Rector? RectorData { get; set; }
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public string UniversityProperty { get; set; } = string.Empty;
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public string ConstructionProperty { get; set; } = string.Empty;
    /// <summary>
    /// Факультеты университета
    /// </summary>
    public List<Faculty> FacultiesData { get; set; } = new List<Faculty>();
    /// <summary>
    /// Кафедры университета
    /// </summary>
    public List<Department> DepartmentsData { get; set; } = new List<Department>();
    /// <summary>
    /// Таблица связи специальность-количество групп
    /// </summary>
    public List<SpecialtyTableNode> SpecialtyTable { get; set; } = new List<SpecialtyTableNode>();
}