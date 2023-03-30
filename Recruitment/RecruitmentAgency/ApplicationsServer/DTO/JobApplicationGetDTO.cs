namespace ApplicationsServer.DTO;
/// <summary>
/// JobApplication - a class that describes the employee's application
/// </summary>
public class JobApplication
{
    /// <summary>
    /// Employee - contains employee id
    /// </summary>  
    public int Employee { get; set; }
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// Title - responsible for the job title
    /// </summary>
    public string Title { set; get; } = string.Empty;
    /// <summary>  
    /// id - shows the JobApplication id
    /// </summary>  
    public int Id { set; get; }
}


