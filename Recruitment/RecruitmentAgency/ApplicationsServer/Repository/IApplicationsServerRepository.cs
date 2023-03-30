using RecruitmentAgency;

namespace ApplicationsServer.Repository;
/// <summary>
/// Interface for the ApplicationsServerRepository class
/// </summary>
public interface IApplicationsServerRepository
{
    /// <summary>
    /// A list of Companies that will change by methods
    /// </summary>
    List<Company> Companies { get; }
    /// <summary>
    /// A list of CompaniesApplications that will change by methods
    /// </summary>
    List<CompanyApplication> CompaniesApplications { get; }
    /// <summary>
    /// A list of Employees that will change by methods
    /// </summary>
    List<Employee> Employees { get; }
    /// <summary>
    /// A list of JobApplications that will change by methods
    /// </summary>
    List<JobApplication> JobApplications { get; }
    /// <summary>
    /// A list of Titles that will change by methods
    /// </summary>
    List<Title> Titles { get; }
}