namespace LibrarySchoolServer.Dto;

/// <summary>
/// Dto get Student
/// </summary>
/// <param name="StudentId">Id of student</param>
/// <param name="Passport">Passport of student</param>
/// <param name="StudentName">Name of student</param>
/// <param name="DateOfBirth">Birthday of student</param>
/// <param name="ClassId">Id of class</param>
public record StudentGetDto(int StudentId,
                            string Passport,
                            string StudentName,
                            DateTime DateOfBirth,
                            int ClassId);
