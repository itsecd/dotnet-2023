namespace EmployeeDomain;
public class Occupation
{
    public string Name { get; set; }
    public uint Id { get; set; }
    public List<EmployeeOccupation> EmployeeOccupation { get; set; }
}