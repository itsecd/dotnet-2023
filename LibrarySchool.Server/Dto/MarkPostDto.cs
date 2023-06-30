namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Marks
/// </summary>
/// <param name="StudentId"></param>
/// <param name="MarkValue"></param>
/// <param name="SubjectId"></param>
/// <param name="TimeReceive"></param>
public record MarkPostDto(int StudentId,
                          int MarkValue,
                          int SubjectId,
                          DateTime TimeReceive);

