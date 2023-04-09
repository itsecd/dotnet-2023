namespace EmployeeDomain;
/// <summary>
/// class Department - represents a department in company
/// </summary>
public class Department
{
    /// <summary>
    /// Id - an id of the department
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the department
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// DepartmentEmployees - a list of employee's departments in which the employee is currently working
    /// One employee can work in multiple departments
    /// </summary>
    public List<DepartmentEmployee> DepartmentEmployees { get; set; } = new List<DepartmentEmployee>();
}