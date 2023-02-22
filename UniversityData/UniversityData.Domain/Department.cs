

namespace UniversityData.Domain;
/// <summary>
/// Информация о кафедре
/// </summary>
public class Department
{
    /// <summary>
    /// Название кафедры
    /// </summary>
    public string? DepartmentName { get; set; } 
    /// <summary>
    /// Контактный телефон заведущего кафедрой
    /// </summary>
    public string? DepartmentSupervisorNumber { get; set; }
}
