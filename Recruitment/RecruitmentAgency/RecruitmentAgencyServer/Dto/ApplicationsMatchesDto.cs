namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// ApplicationsMatchesDto - a class that describes the sql query
/// </summary>
public class ApplicationsMatchesDto
{
    /// <summary>
    /// PersonalName - a string for name, second_name and surname
    /// </summary>  
    public string PersonalName { set; get; } = string.Empty;
    /// <summary>
    /// Salary - an int that stores the salary
    /// </summary>
    public int Salary { set; get; }
    /// <summary>
    /// CompanySalary - shows the salary in the company
    /// </summary>  
    public int CompanySalary { set; get; }
    /// <summary>  
    /// CompanyId - shows company id
    /// </summary>  
    public int? CompanyId { set; get; }

}