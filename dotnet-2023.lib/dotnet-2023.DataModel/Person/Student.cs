using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;

namespace dotnet_2023.DataModel.Person;
public class Student : BasePerson
{
    /// <summary>
    /// one-to-many -> One GroupOfStudent Many Student
    /// </summary>
    public string? IdGroup { get; set; }
    public GroupOfStudents? Group { get; set; }

    public string? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

}
