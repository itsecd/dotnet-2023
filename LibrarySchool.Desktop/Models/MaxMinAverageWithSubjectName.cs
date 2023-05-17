namespace LibrarySchool.Desktop.Models;

/// <summary>
/// Model of class max, min average subject with subject id and subject name 
/// </summary>
public class MaxMinAverageWithSubjectName : MaxMinAverageMarkDto
{
    /// <summary>
    /// Identificator subject
    /// </summary>
    public int SubjectId { get; set; }


    /// <summary>
    /// Name of the subject
    /// </summary>
    public string SubjectName { get; set; } = "";

}
