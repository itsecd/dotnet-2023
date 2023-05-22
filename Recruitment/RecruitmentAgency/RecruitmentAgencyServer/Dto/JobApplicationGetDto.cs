namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// JobApplication - a class that describes the employee's application
/// </summary>
public class JobApplicationGetDto
{
    /// <summary>
    /// Employee - contains employee id
    /// </summary>  
    public int EmployeeId { get; set; }
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// Title - responsible for the job title
    /// </summary>
    public int TitleId { set; get; }
    /// <summary>  
    /// id - shows the JobApplication id
    /// </summary>  
    public int Id { set; get; }
}


