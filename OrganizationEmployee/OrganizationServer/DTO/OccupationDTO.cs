namespace OrganizationServer.DTO;
using EmployeeDomain;
/// <summary>
/// Occupation - represents an employee occupation.
/// The class has list of EmployeeOccupation objects for many-to-many relationship.
/// </summary>
public class OccupationDTO
{
    /// <summary>
    /// Name - a name of the given occupation
    /// </summary>
    public string Name { get; set; } = string.Empty;
}