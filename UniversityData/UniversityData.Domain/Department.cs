

namespace UniversityData.Domain;
/// <summary>
/// Информация о кафедре
/// </summary>
public class Department
{   
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название кафедры
    /// </summary>
    public string? DepartmentName { get; set; } 
    /// <summary>
    /// Контактный телефон заведущего кафедрой
    /// </summary>
    public string? DepartmentSupervisorNumber { get; set; }
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? DepartmentUniversity { get; set; }

    public Department(string? departmentName, string? departmentSupervisorNumber)
    {
        DepartmentName = departmentName;
        DepartmentSupervisorNumber = departmentSupervisorNumber;
    }
}
