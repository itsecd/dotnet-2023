namespace LibrarySchoolServer.Dto;

/// <summary>
/// Post Dto of student
/// </summary>
/// <param name="Passport"></param>
/// <param name="StudentName"></param>
/// <param name="DateOfBirth"></param>
/// <param name="ClassId"></param>
public record StudentPostDto(string Passport,
                             string StudentName,
                             DateTime DateOfBirth,
                             int ClassId);
