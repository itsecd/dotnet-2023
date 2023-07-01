namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Marks
/// </summary>
/// <param name="StudentId">Id of student</param>
/// <param name="MarkValue">Value of mark</param>
/// <param name="SubjectId">Id of subject</param>
/// <param name="TimeReceive">Time recive mark</param>
public record MarkPostDto(int StudentId,
                          int MarkValue,
                          int SubjectId,
                          DateTime TimeReceive);

