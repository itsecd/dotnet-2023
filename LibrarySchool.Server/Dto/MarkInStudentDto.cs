namespace LibrarySchoolServer.Dto;

/// <summary>
/// Dto type of class Marks
/// </summary>
/// <param name="MarkValue">Value of mark</param>
/// <param name="SubjectId">Id subject</param>
public record MarkInStudentDto(int MarkValue, int SubjectId);