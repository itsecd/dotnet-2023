namespace DotNet2023.Domain.InstituteDocumentation;

public enum StudyFormat
{
    FullTime = 0,
    Extramural = 1,
    PartTime = 2
};

/// <summary>
/// The class describing the training specialty.
/// <param name="Code">Study code. Format: X.XX.XX.XX, where:
///     1st numeric digit corresponds to the code of the field of education;
///     The 2nd and 3rd digits correspond to the code of the enlarged group;
///     The 4th and 5th digits correspond to the code of educational level;
///     6th and 7th digits correspond to the code of the profession, specialty or training area.</param>
/// <param name="Title">Full name of the specialty</param>
/// <param name="StudyFormat">Study Format. FullTime - 0, Extramural - 1
///     PartTime - 2</param>
/// <param name="Institutes">Institute-Specialty class collection. 
///     Needed for realization of "many-to-many" relationship. 
///     Many specialties may be in many institutes.</param>
/// <param name="Department">Department</param>
/// <param name="IdDepartment">Id Department</param>
/// </summary>
public class Speciality
{
    //[RegularExpression(@"\d.\d\d.\d\d.\d\d")]
    public string Code { get; set; } = new Guid().ToString();
    public string? Title { get; set; }
    public StudyFormat? StudyFormat { get; set; }

    /// <summary>
    /// many-to-many with Institute
    /// </summary>
    public ICollection<InstituteSpeciality>? Institutes { get; set; } = new List<InstituteSpeciality>();
}
