namespace OrganizationServer.Dto;
/// <summary>
/// class GetDepartmentDto - represents a department in company
/// </summary>
public class GetDepartmentDto
{
    /// <summary>
    /// Id - an id of the department
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the department
    /// </summary>
    public string Name { get; set; }
}