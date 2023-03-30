namespace LibrarySchool;

///<summary>
/// Mark - Class type mark, connection between sudent-mark value-subject
///</summary>
public class Mark
{
    ///<summary>
    /// MarkId - Id mark 
    ///</summary>
    public int MarkId { get; set; }

    ///<summary>
    /// StudentId - Id student
    ///</summary>
    public int StudentId { get; set; }

    ///<summary>
    /// MarkValue - value of mark student received
    ///</summary>
    public int MarkValue { get; set; }

    ///<summary>
    /// SubjectId - Id subject
    ///</summary>
    public int SubjectId { get; set; }

    ///<summary>
    /// TimeReceive - time when student receive mark
    ///</summary>
    public DateTime TimeReceive { get; set; }

    public Mark() { }

    public Mark(int markId, int studentId, int markValue, int subjectId, DateTime timeReceive)
    {
        MarkId = markId;
        StudentId = studentId;
        MarkValue = markValue;
        SubjectId = subjectId;
        TimeReceive = timeReceive;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Mark) return false;
        var objMark = (Mark)obj;
        return (objMark.StudentId == StudentId && objMark.MarkValue == MarkValue && objMark.MarkId == MarkId && objMark.SubjectId == SubjectId && objMark.TimeReceive == TimeReceive);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MarkId, StudentId, MarkValue, SubjectId, TimeReceive);
    }
}
