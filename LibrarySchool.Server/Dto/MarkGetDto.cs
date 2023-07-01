namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Marks
/// </summary>
/// <param name="MarkId"></param>
/// <param name="StudentId"></param>
/// <param name="MarkValue"></param>
/// <param name="SubjectId"></param>
/// <param name="TimeReceive"></param>
public record MarkGetDto(int MarkId,
                         int StudentId,
                         int MarkValue,
                         int SubjectId,
                         DateTime TimeReceive);