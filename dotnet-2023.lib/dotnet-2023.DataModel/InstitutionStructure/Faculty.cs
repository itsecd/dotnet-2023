using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.InstitutionStructure;
public class Faculty : BaseSection
{
    public string? IdDean { get; set; }
    public EducationWorker? Dean { get; set; }

    /// <summary>
    /// one-to-many -> One Faculty Many Departments
    /// </summary>
    public ICollection<Department>? Departments { get; set; } = new List<Department>();

    /// <summary>
    /// one-to-many -> One Institute Many Facultes
    /// </summary>
    public HigherEducationInstitution? Institute { get; set; }
    public string? IdInstitute { get; set; }
}
