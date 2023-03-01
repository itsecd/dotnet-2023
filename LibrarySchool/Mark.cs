namespace LibrarySchool;

///<summary>
/// Mark - Class type mark, connection between sudent-mark value-subject
///</summary>
public class Mark
{
    ///<summary>
    /// MarkID - Id mark 
    ///
    ///</summary>
    public int MarkID { get; set; }

    ///<summary>
    /// StudentID - Id student
    ///</summary>
    public int StudentID { get; set; }

    ///<summary>
    /// MarkValue - value of mark student received
    ///</summary>
    public int MarkValue { get; set; }

    ///<summary>
    /// SubjectID - Id subject
    ///</summary>
    public int SubjectID { get; set; }


    ///<summary>
    /// TimeReceive - time when student receive mark
    ///</summary>
    public DateOnly TimeReceive { get; set; }

    public Mark(int markID, int studentID, int markValue, int subjectID, DateOnly timeReceive)
    {
        MarkID = markID;
        StudentID = studentID;
        MarkValue = markValue;
        SubjectID = subjectID;
        TimeReceive = timeReceive;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Mark) return false;
        var objMark = (Mark)obj;
        return (objMark.StudentID == StudentID && objMark.MarkValue == MarkValue && objMark.MarkID == MarkID && objMark.SubjectID == SubjectID && objMark.TimeReceive == TimeReceive);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MarkID, StudentID, MarkValue, SubjectID, TimeReceive);
    }
}
