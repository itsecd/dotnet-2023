using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityData.Domain;
/// <summary>
/// Информация об университете
/// </summary>
[Table("university")]
public class University
{
    /// <summary>
    /// ID
    /// </summary>
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    [Column("number")]
    public string Number { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    /// <summary>
    /// Адрес университета
    /// </summary>
    [Column("address")]
    public string Address { get; set; }
    /// <summary>
    /// ID ректора
    /// </summary>
    [Column("rector_id")]
    public int RectorId { get; set; }
    /// <summary>
    /// ID собственности зданий университета
    /// </summary>
    [Column("construction_property_id")]
    public int ConstructionPropertyId { get; set; }
    /// <summary>
    /// ID собственности университета
    /// </summary>
    [Column("university_property_id")]
    public int UniversityPropertyId { get; set; }
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