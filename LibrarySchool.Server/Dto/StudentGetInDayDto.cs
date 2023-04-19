using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibrarySchoolServer.Dto;

namespace LibrarySchool.Server.Dto;

/// <summary>
/// Create seeding data for testing controller
/// </summary>
public class StudentGetInDayDto
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
    /// Marks - list mark that student received
    /// </summary>
    public List<MarkInStudentDto> Marks { get; set; } = null!;
}
