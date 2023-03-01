using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.InstitutionStructure;

/// <summary>
/// The class describing the department
/// <param name="IdHeadOfDepartment">Id head of department</param>
/// <param name="HeadOfDepartment">Head of Department</param>
/// <param name="Specialties">The collection of majors that exist in the department. 
///     Relationship: "one-to-many", where one department may have many specialties.</param>
/// <param name="GroupOfStudents">A collection of groups studying in a department. 
///     One-to-many relationship, where one department may have many groups of students.</param>
/// <param name="Faculty">Faculty</param>
/// <param name="IdFaculty">Id Faculty</param>
/// <param name="Institute">Institute</param>
/// <param name="IdInstitute">Id Institute</param>
/// </summary>
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

    /// <summary>
    /// one-to-many -> One Institute Many Departments
    /// </summary>
    public HigherEducationInstitution? Institute { get; set; }
    public string? IdInstitute { get; set; }

    public override string ToString() =>
    $"Class - Department. Id Head Of Department - {IdHeadOfDepartment}. Bla-Bla-Bla";
}
