using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.Organization;
public class HigherEducationInstitution : EducationalInstitution
{
    public string? IdRector { get; set; }
    public EducationWorker? Rector { get; set; }

    /// <summary>
    /// one-to-many -> One Institute Many Facultes
    /// </summary>
    public ICollection<Faculty>? Faculties { get; set; } = new List<Faculty>();

    /// <summary>
    /// one-to-many -> One Institute Many Departments
    /// </summary>
    public ICollection<Department>? Departments { get; set; } = new List<Department>();

    /// <summary>
    /// many-to-many -> many Institute many Specialty
    /// </summary>
    public ICollection<InstituteSpeciality>? Specialties { get; set; } = new List<InstituteSpeciality>();

}
