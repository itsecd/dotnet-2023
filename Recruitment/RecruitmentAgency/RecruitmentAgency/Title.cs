namespace RecruitmentAgency;
/// <summary>
/// Title - a class that describes the field of work and position
/// </summary>
public class Title
{
    /// <summary>
    /// Section - a string that stores section, for example: IT, Finance, etc...
    /// </summary>  
    public string Section { set; get; } = string.Empty;
    /// <summary>
    /// JobTitle - the string responsible for the title. For example: Programmer, Designer, etc...
    /// </summary>  
    public string JobTitle { set; get; } = string.Empty;
    /// <summary>  
    /// id - shows the title's
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    /// Applications - shows the employees' applications 
    /// </summary>
    public List<JobApplication> EmployeeApplications { set; get; } = new List<JobApplication>();
    /// <summary>
    /// Applications - shows the company requests
    /// </summary>
    public List<CompanyApplication> CompanyApplications { set; get; } = new List<CompanyApplication>();
}
