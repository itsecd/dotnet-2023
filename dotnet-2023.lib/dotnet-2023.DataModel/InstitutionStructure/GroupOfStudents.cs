using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.InstitutionStructure;

public class GroupOfStudents
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
}
