namespace dotnet_2023.DataModel.Person;
public class Worker : BasePerson
{
    public string? IdOrganization { get; set; }
    public string? OrganizationName { get; set; }
    public string? JobTitle { get; set; }
    public double? Salary { get; set; }
}
