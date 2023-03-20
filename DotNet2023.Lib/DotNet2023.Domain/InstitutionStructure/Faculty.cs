using DotNet2023.Domain.Organization;
using DotNet2023.Domain.Person;

namespace DotNet2023.Domain.InstitutionStructure;

/// <summary>
/// The class is a description of the faculty
/// <param name="IdDean">Id of the dean of the faculty</param>
/// <param name="Dean">Dean of faculty</param>
/// <param name="Departments">Departments existing in the faculty</param>
/// <param name="Institute">Id institute, on the basis of which the department exists</param>
/// <param name="IdInstitute">Institute, on the basis of which the department exists</param>
/// </summary>
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

    public override string ToString() =>
        $"Class - Faculty. Id Dean - {IdDean}. Bla-Bla-Bla";
}
