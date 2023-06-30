namespace LibrarySchoolServer.Dto;

/// <summary>
/// Dto get Student
/// </summary>
/// <param name="StudentId"></param>
/// <param name="Passport"></param>
/// <param name="StudentName"></param>
/// <param name="DateOfBirth"></param>
/// <param name="ClassId"></param>
public record StudentGetDto(int StudentId,
                            string Passport,
                            string StudentName,
                            DateTime DateOfBirth,
                            int ClassId);
