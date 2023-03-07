namespace DotNet2023.DataModel.Person;

/// <summary>
/// The class contains a description of an employee in the field of higher education.
/// <param name="ScienceDegree">Academic degree of an employee</param>
/// <param name="Rank">The title of scientist</param>
/// </summary>
public class EducationWorker : Worker
{
    public string? ScienceDegree { get; set; }
    public string? Rank { get; set; }

    public override string ToString() =>
        $"Class - EducationWorker. JobTitle - {JobTitle}. ScienceDegree - {ScienceDegree}" +
        $"Rank - {Rank}";
}
