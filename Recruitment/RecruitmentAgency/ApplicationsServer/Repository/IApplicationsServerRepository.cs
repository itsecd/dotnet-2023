using RecruitmentAgency;

namespace ApplicationsServer.Repository;
public interface IApplicationsServerRepository
{
    List<Company> Companies { get; }
    List<CompanyApplication> CompaniesApplications { get; }
    List<Employee> Employees { get; }
    List<JobApplication> JobApplications { get; }
    List<Title> Titles { get; }
}