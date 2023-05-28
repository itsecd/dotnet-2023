namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// NumberApplicationsDto - a class that describes the sql query
/// </summary>
public class NumberApplicationsDto
{
    /// <summary>
    /// JobSection - a string for the occupation
    /// </summary>  
    public string JobSection { set; get; } = string.Empty;
    /// <summary>
    /// JobTitle - a string for title of the job
    /// </summary>
    public string JobTitle { set; get; }
    /// <summary>
    /// NumJobApplications - shows the number of the job applications
    /// </summary>  
    public int NumJobApplications { set; get; }
    /// <summary>  
    /// NumCompanyApplications - shows the number of the companies applications
    /// </summary>  
    public int? NumCompanyApplications { set; get; }
}