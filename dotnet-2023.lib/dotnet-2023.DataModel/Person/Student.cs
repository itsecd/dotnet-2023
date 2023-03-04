using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;

namespace dotnet_2023.DataModel.Person;

/// <summary>
/// The class is a description of the student.
/// <param name="IdGroup">Student Group Id</param>
/// <param name="Group">The group in which the student is studying</param>
/// First two fields are needed to implement the "one-to-many" connection, 
///     where one group can contain many students.
/// <param name="IdSpeciality">Code of the specialty in which the student studies</param>
/// <param name="Speciality">The specialty in which the student studies</param>
/// </summary>
public class Student : BasePerson
{

    /// <summary>
    /// one-to-many -> One GroupOfStudent Many Student
    /// </summary>
    public string? IdGroup { get; set; }
    public GroupOfStudents? Group { get; set; }

    public string? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

    public override string ToString() =>
        $"Class - Student. Id Group - {IdGroup}. Id Speciality - {IdSpeciality}";
}
