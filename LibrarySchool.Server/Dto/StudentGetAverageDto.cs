namespace LibrarySchoolServer.Dto;

/// <summary>
/// DtoType to get average mark of student
/// </summary>
/// <param name="StudentId"></param>
/// <param name="Passport"></param>
/// <param name="StudentName"></param>
/// <param name="DateOfBirth"></param>
/// <param name="ClassId"></param>
/// <param name="AverageMark"></param>
public record StudentGetAverageDto(int StudentId,
                                   string Passport,
                                   string StudentName,
                                   DateTime DateOfBirth,
                                   int ClassId,
                                   double AverageMark);