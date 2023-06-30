namespace LibrarySchoolServer.Dto;

/// <summary>
/// Subjects - Class type the subject 
/// </summary>
/// <param name="SubjectId"></param>
/// <param name="SubjectName"></param>
/// <param name="YearStudy"></param>

public record SubjectGetDto(int SubjectId,
                            string SubjectName,
                            int YearStudy);
