using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.DataModel.Organization;

/// <summary>
/// The class describes the institution of Higher Education Institution.
/// <param name="IdRector">Id rector of an educational institution</param>
/// <param name="Rector">Rector of the educational institution</param>
/// <param name="Faculties">Faculties of the institution</param>
/// <param name="Departments">Departments of the educational institution</param>
/// <param name="Specialties">Implementation of the "many-to-many" connection for 
///     educational institutions and specialties</param>
/// </summary>
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
    public ICollection<InstituteSpeciality>? Specialties { get; set; } 
        = new List<InstituteSpeciality>();

    public override string ToString() =>
        $"Class - HigherEducationInstitution. Full Name - {FullName}. Id Rector - {IdRector}. " +
        $"Initials - {Initials}. Address - {LegalAddress}. Count Faculties - {Faculties.Count}. " +
        $"Count Departments - {Departments.Count}. Count Specialties - {Specialties.Count}";
}
