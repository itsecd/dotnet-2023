namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Marks
/// </summary>
public class MarkPostDto
{
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

}
