namespace RecruitmentAgency;
public class JobApplication
{
    /// <summary>
    /// Employee - contains information about the employee
    /// </summary>  
    public Employee Employee { get; set; } = new();
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; } = DateTime.MinValue;
    /// <summary>
    /// Title - responsible for the job title
    /// </summary>
    public string Title { set; get; } = string.Empty;
}
