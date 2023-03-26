namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Mark
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

}
