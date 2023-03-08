namespace EmployeeDomain;
/// <summary>
/// Class Workshop represents a workshop on the orgainzation
/// </summary>
public class Workshop
{
    /// <summary>
    /// Id - an id of the workshop
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the workshop
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Employees - a list of Employee objects, used to maintain an one-to-many relationship.
    /// </summary>
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
