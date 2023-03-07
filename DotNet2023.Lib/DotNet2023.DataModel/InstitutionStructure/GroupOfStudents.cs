using DotNet2023.DataModel.InstituteDocumentation;
using DotNet2023.DataModel.Person;

namespace DotNet2023.DataModel.InstitutionStructure;

/// <summary>
/// A class describing a group of students
/// <param name="IdSpeciality">Id Speciality</param>
/// <param name="Speciality">Speciality</param>
/// <param name="Students">A collection of students. It implements a one-to-many relationship, 
///     where one student group can contain many students.</param>
/// <param name="Department">Department</param>
/// <param name="IdDepartment">Id Department</param>
/// </summary>
public class GroupOfStudents : BaseSection
{
    public string? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

    /// <summary>
    /// one-to-many -> One Group Many Students
    /// </summary>
    public ICollection<Student>? Students { get; set; } = new List<Student>();

    /// <summary>
    /// one-to-many -> One Department Many GroupOfStudents
    /// </summary>
    public Department? Department { get; set; }
    public string? IdDepartment { get; set; }

    public override string ToString() =>
        $"Class - GroupOfStudents. Id Speciality - {IdSpeciality}. Bla-Bla-Bla";
}
