namespace Company.Server.Dto;

/// <summary>
/// WorkersAndDepartmentsPostDto - narrows the WorkersAndDepartments class for Post method in controller
/// </summary>
public class WorkersAndDepartmentsPostDto
{
    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    public int WorkerId { get; set; }


    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    public int DepartmentId { get; set; }
}
