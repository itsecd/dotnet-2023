namespace dotnet_2023.DataModel.Person;

/// <summary>
/// This class is a description of the base worker
/// <param name="IdOrganization">Id of the organization</param>
/// <param name="Organization">Base class of the organization in which the employee works</param>
/// <param name="JobTitle">Employee position</param>
/// <param name="Salary">Employee rate format: wage per hour</param>
/// </summary>
public class Worker : BasePerson
{
    public string? IdOrganization { get; set; }

    public string? JobTitle { get; set; }
    public double? Salary { get; set; }
}
