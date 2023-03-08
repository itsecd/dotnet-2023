namespace EmployeeDomain;
public class Workshop
{
    public string Name { get; set; } = string.Empty;
    public uint Id { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
}
