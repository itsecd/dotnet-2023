namespace LibrarySchool.Server.Dto;

/// <summary>
/// DtoClassOfStudent who get mark in day
/// </summary>
/// <param name="StudentId"></param>
/// <param name="StudentName"></param>
/// <param name="SubjectId"></param>
/// <param name="SubjectName"></param>
/// <param name="MarkValue"></param>
public record StudentGetInDayDto(int StudentId,
                                 string StudentName,
                                 int SubjectId,
                                 int SubjectName,
                                 int MarkValue);
