namespace LibrarySchoolServer.Dto;
/// <summary>
/// ClassPostDto of Subject
/// </summary>
/// <param name="SubjectName">Name of subject</param>
/// <param name="YearStudy">Year study subject</param>
public record SubjectPostDto(string SubjectName,
                             int YearStudy);