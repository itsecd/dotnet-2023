namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// JobApplication - a class that describes the employee's application
/// </summary>
public class JobApplicationPostDto
{
    /// <summary>
    /// Employee - contains employee id
    /// </summary>  
    public EmployeePostDto? Employee { get; set; }
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// Title - responsible for the job title
    /// </summary>
    public string Title { set; get; } = string.Empty;
}


