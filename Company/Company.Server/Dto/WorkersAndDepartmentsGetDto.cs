namespace Company.Server.Dto;

/// <summary>
/// WorkersAndDepartmentsGetDto - narrows the WorkersAndDepartments class for Get method in controller
/// </summary>
public class WorkersAndDepartmentsGetDto
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    public int WorkerId { get; set; }


    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    public int DepartmentId { get; set; }
}
