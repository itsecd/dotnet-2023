using RecruitmentAgency;
namespace RecruitmentAgencyServer.Repository;
/// <summary>
/// Interface for the RecruitmentAgencyServerRepository class
/// </summary>
public interface IRecruitmentAgencyServerRepository
{
    /// <summary>
    /// A list of Companies that will change by methods
    /// </summary>
    public List<Company> Companies { get; }
    /// <summary>
    /// A list of CompaniesApplications that will change by methods
    /// </summary>
    public List<CompanyApplication> CompaniesApplications { get; }
    /// <summary>
    /// A list of Employees that will change by methods
    /// </summary>
    public List<Employee> Employees { get; }
    /// <summary>
    /// A list of JobApplications that will change by methods
    /// </summary>
    public List<JobApplication> JobApplications { get; }
    /// <summary>
    /// A list of Titles that will change by methods
    /// </summary>
    public List<Title> Titles { get; }
}