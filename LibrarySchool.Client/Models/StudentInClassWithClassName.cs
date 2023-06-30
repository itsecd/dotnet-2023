namespace LibrarySchool.Client.Models;

/// <summary>
/// Model of student dto with class number and class letter 
/// </summary>
public class StudentInClassWithClassName : StudentGetDto
{
    /// <summary>
    /// Number of class, where student studying in
    /// </summary>
    public int ClassNumber { get; set; }

    /// <summary>
    /// Letter of class, where student studying in
    /// </summary>
    public string ClassLetter { get; set; } = "";
}
