using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySchool;

///<summary>
/// Marks - Class type mark, connection between sudent-mark value-subject
///</summary>
public class Mark
{
    ///<summary>
    /// MarkId - Id mark 
    ///</summary>
    [Key]
    public int MarkId { get; set; }

    ///<summary>
    /// StudentId - Id student
    ///</summary>
    [ForeignKey("Student")]
    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    ///<summary>
    /// MarkValue - value of mark student received
    ///</summary>
    public int MarkValue { get; set; }

    ///<summary>
    /// SubjectId - Id subject
    ///</summary>
    [ForeignKey("Subject")]
    public int SubjectId { get; set; }

    /// <summary>
    /// Subject with id = SubjectId
    /// </summary>
    public Subject Subject { get; set; } = null!;

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
