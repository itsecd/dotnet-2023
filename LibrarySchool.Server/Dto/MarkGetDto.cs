using System.ComponentModel.DataAnnotations;

namespace LibrarySchoolServer.Dto;
/// <summary>
/// PostDto type of class Marks
/// </summary>
/// <param name="MarkId">Id mark</param>
/// <param name="StudentId">Subject Id</param>
/// <param name="MarkValue">MarkValue</param>
/// <param name="SubjectId">Id Subject</param>
/// <param name="TimeReceive">Time recive mark</param>
public record MarkGetDto(int MarkId,
                         int StudentId,
                         int MarkValue,
                         int SubjectId,
                         DateTime TimeReceive);