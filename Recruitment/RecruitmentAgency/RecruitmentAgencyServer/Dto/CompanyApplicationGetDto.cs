namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// CompanyApplication - a class that describes the company application
/// </summary>
public class CompanyApplicationGetDto
{
    /// <summary>
    /// Date - date of application
    /// </summary>  
    public DateTime Date { set; get; } = DateTime.MinValue;
    /// <summary>
    /// WorkExperience - shows the required work experience in years
    /// </summary>
    public int WorkExperience { set; get; } = 0;
    /// <summary>
    /// Salary - shows the wages which the company will pay
    /// </summary>
    public int Salary { set; get; } = 0;
    /// <summary>
    /// Title - shows the job id
    /// </summary>
    public string? Education { set; get; } = "None";
    /// <summary>  
    /// id - shows the company's application id
    /// </summary>  
    public int Id { set; get; }
}
