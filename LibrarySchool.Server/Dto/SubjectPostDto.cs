namespace LibrarySchoolServer.Dto;
/// <summary>
/// ClassPostDto of Subject
/// </summary>
/// <param name="SubjectName"></param>
/// <param name="YearStudy"></param>
public record SubjectPostDto(string SubjectName,
                             int YearStudy);