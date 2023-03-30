using RecruitmentAgency;

namespace ApplicationsServer.Repository;

/// <summary>
/// A class for storing and modifying table data
/// </summary>
public class ApplicationsServerRepository : IApplicationsServerRepository
{
    private readonly List<Company> _companies;
    private readonly List<TitleGetDTO> _titles;
    private readonly List<CompanyApplication> _companiesApplications;
    private readonly List<Employee> _employees;
    private readonly List<JobApplication> _jobApplications;
    /// <summary>
    /// A constructor that adds some default values for tables
    /// </summary>
    public ApplicationsServerRepository()
    {
        _companies = RepositoryCompanies;
        _titles = RepositoryTitles;
        _companiesApplications = RepositoryCompaniesApplications;
        _employees = RepositoryEmployees;
        _jobApplications = RepositoryJobApplications;
    }
    /// <summary>
    /// Return the list of companies with default values
    /// </summary>
    private List<Company> RepositoryCompanies
    {
        get
        {
            var companiesApplications = RepositoryCompaniesApplications;
            var companies = new List<Company>();
            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            firstCompany.Id = 0;
            firstCompany.Applications.Add(companiesApplications[0]);
            companies.Add(firstCompany);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = 1;
            secondCompany.Applications.Add(companiesApplications[1]);
            companies.Add(secondCompany);
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = 2;
            thirdCompany.Applications.Add(companiesApplications[2]);
            companies.Add(thirdCompany);
            return companies;
        }
    }
    /// <summary>
    /// Return the list of titles with default values
    /// </summary>
    private List<TitleGetDTO> RepositoryTitles
    {
        get
        {
            var companiesApplications = RepositoryCompaniesApplications;
            var employeesApplications = RepositoryJobApplications;
            var titles = new List<TitleGetDTO>();
            var firstTitle = new TitleGetDTO();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            firstTitle.Id = 0;
            firstTitle.CompanyApplications.Add(companiesApplications[0]);
            firstTitle.CompanyApplications.Add(companiesApplications[2]);
            firstTitle.EmployeeApplications.Add(employeesApplications[0]);
            firstTitle.EmployeeApplications.Add(employeesApplications[2]);
            titles.Add(firstTitle);
            var secondTitle = new TitleGetDTO();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            secondTitle.Id = 1;
            secondTitle.CompanyApplications.Add(companiesApplications[1]);
            secondTitle.EmployeeApplications.Add(employeesApplications[1]);
            titles.Add(secondTitle);
            return titles;
        }
    }
    /// <summary>
    ///  Return the list of CompaniesApplications with default values
    /// </summary>
    private List<CompanyApplication> RepositoryCompaniesApplications
    {
        get
        {
            var companiesApplications = new List<CompanyApplication>();
            var firstTitle = new TitleGetDTO();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            firstTitle.Id = 0;
            var secondTitle = new TitleGetDTO();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            secondTitle.Id = 1;
            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            firstCompany.Id = 0;
            var firstApplication = new CompanyApplication();
            firstApplication.Company = firstCompany;
            firstApplication.WorkExperience = 0;
            firstApplication.Salary = 50000;
            firstApplication.Date = new DateTime(2022, 12, 12);
            firstApplication.Title = firstTitle;
            firstApplication.Education = "None";
            firstApplication.Id = 0;
            companiesApplications.Add(firstApplication);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = 1;
            var secondApplication = new CompanyApplication();
            secondApplication.Company = secondCompany;
            secondApplication.WorkExperience = 1;
            secondApplication.Salary = 60000;
            secondApplication.Date = new DateTime(2022, 5, 9);
            secondApplication.Title = secondTitle;
            secondApplication.Education = "Half";
            secondApplication.Id = 1;
            companiesApplications.Add(secondApplication);
            var thirdApplication = new CompanyApplication();
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = 2;
            thirdApplication.Company = thirdCompany;
            thirdApplication.WorkExperience = 2;
            thirdApplication.Salary = 70000;
            thirdApplication.Date = new DateTime(2022, 7, 6);
            thirdApplication.Title = firstTitle;
            thirdApplication.Education = "Full";
            thirdApplication.Id = 2;
            companiesApplications.Add(thirdApplication);
            return companiesApplications;
        }
    }
    /// <summary>
    /// Return the list of Employees with default values
    /// </summary>
    private List<Employee> RepositoryEmployees
    {
        get
        {
            var employeeApplications = RepositoryJobApplications;
            var employees = new List<Employee>();
            var firstEmployee = new Employee();
            firstEmployee.PersonalName = "Alex Walker";
            firstEmployee.Telephone = "531-100";
            firstEmployee.WorkExperience = 0;
            firstEmployee.Salary = 52000;
            firstEmployee.Education = "None";
            firstEmployee.Id = 0;
            firstEmployee.Applications.Add(employeeApplications[0]);
            employees.Add(firstEmployee);
            var secondEmployee = new Employee();
            secondEmployee.PersonalName = "John Dishes";
            secondEmployee.Telephone = "520-301";
            secondEmployee.WorkExperience = 1;
            secondEmployee.Salary = 61000;
            secondEmployee.Education = "Half";
            secondEmployee.Id = 1;
            secondEmployee.Applications.Add(employeeApplications[1]);
            employees.Add(secondEmployee);
            var thirdEmployee = new Employee();
            thirdEmployee.PersonalName = "Alex Walker";
            thirdEmployee.Telephone = "513-219";
            thirdEmployee.WorkExperience = 2;
            thirdEmployee.Salary = 66000;
            thirdEmployee.Education = "Full";
            thirdEmployee.Id = 2;
            thirdEmployee.Applications.Add(employeeApplications[2]);
            employees.Add(thirdEmployee);
            return employees;
        }
    }
    /// <summary>
    /// Return the list of JobApplications with default values
    /// </summary>
    private List<JobApplication> RepositoryJobApplications
    {
        get
        {
            var firstEmployee = new Employee();
            firstEmployee.PersonalName = "Alex Walker";
            firstEmployee.Telephone = "531-100";
            firstEmployee.WorkExperience = 0;
            firstEmployee.Salary = 52000;
            firstEmployee.Education = "None";
            firstEmployee.Id = 0;
            var secondEmployee = new Employee();
            secondEmployee.PersonalName = "John Dishes";
            secondEmployee.Telephone = "520-301";
            secondEmployee.WorkExperience = 1;
            secondEmployee.Salary = 61000;
            secondEmployee.Education = "Half";
            secondEmployee.Id = 1;
            var thirdEmployee = new Employee();
            thirdEmployee.PersonalName = "Alex Walker";
            thirdEmployee.Telephone = "513-219";
            thirdEmployee.WorkExperience = 2;
            thirdEmployee.Salary = 66000;
            thirdEmployee.Education = "Full";
            thirdEmployee.Id = 2;
            var jobApplications = new List<JobApplication>();
            var firstApplication = new JobApplication();
            firstApplication.Employee = firstEmployee;
            firstApplication.Title = "Backend";
            firstApplication.Date = new DateTime(2022, 11, 11);
            firstApplication.Id = 0;
            jobApplications.Add(firstApplication);
            var secondApplication = new JobApplication();
            secondApplication.Employee = secondEmployee;
            secondApplication.Title = "Frontend";
            secondApplication.Date = new DateTime(2022, 4, 9);
            secondApplication.Id = 1;
            jobApplications.Add(secondApplication);
            var thirdApplication = new JobApplication();
            thirdApplication.Employee = thirdEmployee;
            thirdApplication.Title = "Backend";
            thirdApplication.Date = new DateTime(2022, 6, 5);
            thirdApplication.Id = 2;
            jobApplications.Add(thirdApplication);
            return jobApplications;
        }
    }
    /// <summary>
    /// A list of Companies that will change by methods
    /// </summary>
    public List<Company> Companies => _companies;
    /// <summary>
    /// A list of Titles that will change by methods
    /// </summary>
    public List<TitleGetDTO> Titles => _titles;
    /// <summary>
    /// A list of CompaniesApplications that will change by methods
    /// </summary>
    public List<CompanyApplication> CompaniesApplications => _companiesApplications;
    /// <summary>
    /// A list of Employess that will change by methods
    /// </summary>
    public List<Employee> Employees => _employees;
    /// <summary>
    /// A list of JobApplications that will change by methods
    /// </summary>
    public List<JobApplication> JobApplications => _jobApplications;
}
