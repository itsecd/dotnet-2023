namespace LibrarySchool;
/// <summary>
/// Subject - Class type the subject 
/// </summary>

public class Subject
{
    /// <summary>
    /// SubjectID - Id of subject 
    /// </summary>
    public int SubjectID { get; set; }

    /// <summary>
    /// SubjectName - Name of the subject
    /// </summary>
    public string SubjectName { get; set; } = "";

    /// <summary>
    /// YearStudy - the year when start study subject
    /// </summary>
    public int YearStudy { get; set; }

    public Subject(int subjectID, string subjectName, int yearStudy)
    {
        SubjectID = subjectID;
        SubjectName = subjectName;
        YearStudy = yearStudy;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Subject) return false;
        var subj = (Subject)obj;
        return (subj.SubjectID == SubjectID && subj.SubjectName == SubjectName && subj.YearStudy == YearStudy);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(SubjectID, SubjectName, YearStudy);
    }
}
