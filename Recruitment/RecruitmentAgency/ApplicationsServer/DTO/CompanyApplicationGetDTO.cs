namespace ApplicationsServer.DTO;
/// <summary>
/// CompanyApplication - a class that describes the company application
/// </summary>
public class CompanyApplicationGetDTO
{
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; }
    /// <summary>
    /// WorkExperience - shows the required work experience in years
    /// </summary>
    public int WorkExperience { set; get; }
    /// <summary>
    /// Salary - shows the wages which the company will pay
    /// </summary>
    public int Salary { set; get; }
    /// <summary>
    /// Title - shows the job id
    /// </summary>
    public string? Education { set; get; }
    /// <summary>  
    /// id - shows the company's application id
    /// </summary>  
    public int Id { set; get; }
}
