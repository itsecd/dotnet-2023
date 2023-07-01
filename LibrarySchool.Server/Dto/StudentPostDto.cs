namespace LibrarySchoolServer.Dto;

/// <summary>
/// Post Dto of student
/// </summary>
/// <param name="Passport">Passport of student</param>
/// <param name="StudentName">Name of student</param>
/// <param name="DateOfBirth">Birthday of student</param>
/// <param name="ClassId">Id of class</param>
public record StudentPostDto(string Passport,
                             string StudentName,
                             DateTime DateOfBirth,
                             int ClassId);
