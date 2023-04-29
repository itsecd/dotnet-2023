namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// CompanyApplication - a class that describes the company application
/// </summary>
public class CompanyApplicationPostDto
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
    /// Education - shows the level of education
    /// </summary>
    public string? Education { set; get; }
}
