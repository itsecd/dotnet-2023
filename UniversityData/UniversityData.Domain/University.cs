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
    /// Сведения о ректоре 
    /// </summary>
    public Rector RectorData { get; set; }
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public UniversityProperty UniversityProperty { get; set; }
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public ConstructionProperty ConstructionProperty { get; set; }
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