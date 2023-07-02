namespace LibrarySchoolServer.Dto;

/// <summary>
/// Subjects - Class type the subject 
/// </summary>
/// <param name="SubjectId">id of subject</param>
/// <param name="SubjectName">Name of student</param>
/// <param name="YearStudy">Year study subject</param>

public record SubjectGetDto(int SubjectId,
                            string SubjectName,
                            int YearStudy);
