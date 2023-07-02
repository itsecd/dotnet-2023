namespace LibrarySchool.Server.Dto;

/// <summary>
/// DtoClassOfStudent who get mark in day
/// </summary>
/// <param name="StudentId">Id of student</param>
/// <param name="StudentName">Name of student</param>
/// <param name="SubjectId">Id of subject</param>
/// <param name="SubjectName">Name of subject</param>
/// <param name="MarkValue">Value of mark</param>
public record StudentGetInDayDto(int StudentId,
                                 string StudentName,
                                 int SubjectId,
                                 string SubjectName,
                                 int MarkValue);
