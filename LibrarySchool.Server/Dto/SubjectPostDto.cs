namespace LibrarySchoolServer.Dto;
/// <summary>
/// DtoPostType of class Subjects
/// </summary>
public class SubjectPostDto
{
    /// <summary>
    /// SubjectName - Name of the subject
    /// </summary>
    public string SubjectName { get; set; } = "";

    /// <summary>
    /// YearStudy - the year when start study subject
    /// </summary>
    public int YearStudy { get; set; }
}
