namespace LibrarySchoolServer.Dto;

/// <summary>
/// DtoType to get average mark of student
/// </summary>
/// <param name="StudentId">Id of student</param>
/// <param name="Passport">Passport number of student</param>
/// <param name="StudentName">Name of student</param>
/// <param name="DateOfBirth">Birthday of student</param>
/// <param name="ClassId">Id of class where student studing</param>
/// <param name="AverageMark">Average mark of student</param>
public record StudentGetAverageDto(int StudentId,
                                   string Passport,
                                   string StudentName,
                                   DateTime DateOfBirth,
                                   int ClassId,
                                   double AverageMark);