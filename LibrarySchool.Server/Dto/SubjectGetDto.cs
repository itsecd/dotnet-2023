using LibrarySchool;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarySchoolServer.Dto;

/// <summary>
/// Subjects - Class type the subject 
/// </summary>

public class SubjectGetDto
{
    /// <summary>
    /// SubjectId - Id of subject 
    /// </summary>
    public int SubjectId { get; set; }
    /// <summary>
    /// SubjectName - Name of the subject
    /// </summary>
    public string SubjectName { get; set; } = "";
    /// <summary>
    /// YearStudy - the year when start study subject
    /// </summary>
    public int YearStudy { get; set; }
}
