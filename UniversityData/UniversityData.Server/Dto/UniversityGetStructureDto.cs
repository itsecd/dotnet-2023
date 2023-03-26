using UniversityData.Domain;
namespace UniversityData.Server.Dto;
/// <summary>
/// Информация об университете
/// </summary>
public class UniversityGetStructureDto
{
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
