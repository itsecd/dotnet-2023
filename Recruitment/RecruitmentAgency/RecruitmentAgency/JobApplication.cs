using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency;
/// <summary>
/// JobApplication - a class that describes the employee's application
/// </summary>
public class JobApplication
{
    /// <summary>
    /// Employee - contains information about the employee
    /// </summary>  
    [ForeignKey("EmployeeId")]
    public int EmployeeId { get; set; }
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// Title - responsible for the job title
    /// </summary>
    [ForeignKey("TitleId")]
    public int TitleId { set; get; }

    /// <summary>  
    /// id - shows the JobApplication id
    /// </summary>
    [Key]
    public int Id { set; get; }
}
