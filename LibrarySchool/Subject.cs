namespace LibrarySchool;
/// <summary>
/// Subject - Class type the subject 
/// </summary>

public class Subject
{
    /// <summary>
    /// SubjectId - Id of subject 
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// SubjectName - Name of the subject
    /// </summary>
    public string SubjectName { get; set; } = "";

    /// <summary>
    /// YearStudy - the year when start study subject
    /// </summary>
    public int YearStudy { get; set; }

    public Subject(int subjectId, string subjectName, int yearStudy)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
        YearStudy = yearStudy;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Subject) return false;
        var subj = (Subject)obj;
        return (subj.SubjectId == SubjectId && subj.SubjectName == SubjectName && subj.YearStudy == YearStudy);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(SubjectId, SubjectName, YearStudy);
    }
}
