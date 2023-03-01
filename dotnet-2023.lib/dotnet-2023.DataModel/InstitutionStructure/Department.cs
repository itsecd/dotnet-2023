using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.InstitutionStructure;
public class Department : BaseSection
{
    public string? IdHeadOfDepartment { get; set; }
    public EducationWorker? HeadOfDepartment { get; set; }


    /// <summary>
    /// one-to-many -> One Department Many Specialties
    /// </summary>
    public ICollection<Speciality>? Specialties { get; set; } = new List<Speciality>();

    /// <summary>
    /// one-to-many -> One Department Many GroupOfStudents
    /// </summary>
    public ICollection<GroupOfStudents>? GroupOfStudents { get; set; } = new List<GroupOfStudents>();


    /// <summary>
    /// one-to-many -> One Faculty Many Departments
    /// </summary>
    public Faculty? Faculty { get; set; }
    public string? IdFaculty { get; set; }
}
