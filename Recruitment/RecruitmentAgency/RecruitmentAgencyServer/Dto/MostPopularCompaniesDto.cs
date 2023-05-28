namespace RecruitmentAgencyServer.Dto;
/// <summary>
/// MostPopularCompaniesDto - a class that describes the sql query
/// </summary>
public class MostPopularCompaniesDto
{
    /// <summary>
    /// CompanyName - a string for the company name
    /// </summary>  
    public string CompanyName { set; get; }
    /// <summary>
    /// NumberOfApplications - an int that stores the number of the applications
    /// </summary>
    public int NumberOfApplications { set; get; }
}