namespace LibrarySchoolServer.Dto;

/// <summary>
/// DtoType to get average mark of student
/// </summary>
public class StudentGetAverageDto
{
    ///<summary>
    /// StudentId - guid typed value for storing Id of the student
    ///</summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Passport - string type number passport of the student
    /// </summary>
    public string Passport { get; set; } = "";

    /// <summary>
    /// StudentName - string type name of the student
    /// </summary>
    public string StudentName { get; set; } = "";

    /// <summary>
    /// DateOfBirth - student's date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; } = new DateTime(1, 1, 1);

    /// <summary>
    /// ClassId - Id of the class where student studing
    /// </summary>
    public int ClassId { get; set; }

    /// <summary>
    /// GPA - average mark that student received
    /// </summary>
    public double AverageMark { get; set; }
}
