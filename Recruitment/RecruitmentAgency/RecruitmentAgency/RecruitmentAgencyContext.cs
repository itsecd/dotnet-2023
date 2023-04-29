using Microsoft.EntityFrameworkCore;

namespace RecruitmentAgency;
/// <summary>
/// Class represented a DbContext of RecruitmentAgency
/// </summary>
public sealed class RecruitmentAgencyContext : DbContext
{
    public RecruitmentAgencyContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CompanyApplication> CompanyApplications { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<JobApplication> JobApplications { get; set; } = null!;
    public DbSet<Title> Titles { get; set; } = null!;

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
            firstCompany.Id = -1;
            firstCompany.Applications.Add(companiesApplications[0].Id);
            companies.Add(firstCompany);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = -2;
            secondCompany.Applications.Add(companiesApplications[1].Id);
            companies.Add(secondCompany);
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = -3;
            thirdCompany.Applications.Add(companiesApplications[2].Id);
            companies.Add(thirdCompany);
            return companies;
        }
    }
    /// <summary>
    /// Return the list of titles with default values
    /// </summary>
    private List<Title> RepositoryTitles
    {
        get
        {
            var companiesApplications = RepositoryCompaniesApplications;
            var employeesApplications = RepositoryJobApplications;
            var titles = new List<Title>();
            var firstTitle = new Title();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            firstTitle.Id = 0;
            firstTitle.CompanyApplications.Add(companiesApplications[0].Id);
            firstTitle.CompanyApplications.Add(companiesApplications[2].Id);
            firstTitle.EmployeeApplications.Add(employeesApplications[0].Id);
            firstTitle.EmployeeApplications.Add(employeesApplications[2].Id);
            titles.Add(firstTitle);
            var secondTitle = new Title();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            secondTitle.Id = 1;
            secondTitle.CompanyApplications.Add(companiesApplications[1].Id);
            secondTitle.EmployeeApplications.Add(employeesApplications[1].Id);
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
            var firstTitle = new Title();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            firstTitle.Id = 1;

            var secondTitle = new Title();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            secondTitle.Id = 2;

            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            firstCompany.Id = 1;
            var firstApplication = new CompanyApplication();
            firstApplication.CompanyId = firstCompany.Id;
            firstApplication.WorkExperience = 0;
            firstApplication.Salary = 50000;
            firstApplication.Date = new DateTime(2022, 12, 12);
            firstApplication.TitleId = 1;
            firstApplication.Education = "None";
            firstApplication.Id = 0;
            companiesApplications.Add(firstApplication);


            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = 2;
            var secondApplication = new CompanyApplication();
            secondApplication.CompanyId = secondCompany.Id;
            secondApplication.WorkExperience = 1;
            secondApplication.Salary = 60000;
            secondApplication.Date = new DateTime(2022, 5, 9);
            secondApplication.TitleId = 2;
            secondApplication.Education = "Half";
            secondApplication.Id = 1;
            companiesApplications.Add(secondApplication);


            var thirdApplication = new CompanyApplication();
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = 3;
            thirdApplication.CompanyId = thirdCompany.Id;
            thirdApplication.WorkExperience = 2;
            thirdApplication.Salary = 70000;
            thirdApplication.Date = new DateTime(2022, 7, 6);
            thirdApplication.TitleId = 1;
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
            firstEmployee.Applications.Add(employeeApplications[0].Id);
            employees.Add(firstEmployee);
            var secondEmployee = new Employee();
            secondEmployee.PersonalName = "John Dishes";
            secondEmployee.Telephone = "520-301";
            secondEmployee.WorkExperience = 1;
            secondEmployee.Salary = 61000;
            secondEmployee.Education = "Half";
            secondEmployee.Id = 1;
            secondEmployee.Applications.Add(employeeApplications[1].Id);
            employees.Add(secondEmployee);
            var thirdEmployee = new Employee();
            thirdEmployee.PersonalName = "Alex Walker";
            thirdEmployee.Telephone = "513-219";
            thirdEmployee.WorkExperience = 2;
            thirdEmployee.Salary = 66000;
            thirdEmployee.Education = "Full";
            thirdEmployee.Id = 2;
            thirdEmployee.Applications.Add(employeeApplications[2].Id);
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
            firstApplication.EmployeeId = 1;
            firstApplication.TitleId = 1;
            firstApplication.Date = new DateTime(2022, 11, 11);
            firstApplication.Id = 0;
            jobApplications.Add(firstApplication);
            var secondApplication = new JobApplication();
            secondApplication.EmployeeId = 2;
            secondApplication.TitleId = 2;
            secondApplication.Date = new DateTime(2022, 4, 9);
            secondApplication.Id = 1;
            jobApplications.Add(secondApplication);
            var thirdApplication = new JobApplication();
            thirdApplication.EmployeeId = 3;
            thirdApplication.TitleId = 1;
            thirdApplication.Date = new DateTime(2022, 6, 5);
            thirdApplication.Id = 2;
            jobApplications.Add(thirdApplication);
            return jobApplications;
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var companies = RepositoryCompanies;
        var companyApplications = RepositoryCompaniesApplications;
        var employees = RepositoryEmployees;
        var jobApplications = RepositoryJobApplications;
        var titles = RepositoryTitles;
        modelBuilder.Entity<Company>().Ignore(company => company.Applications);
        modelBuilder.Entity<Employee>().Ignore(employee => employee.Applications);
        modelBuilder.Entity<Title>().Ignore(title => title.CompanyApplications);
        modelBuilder.Entity<Title>().Ignore(title => title.EmployeeApplications);

        var index = 1;
        foreach (var title in titles)
        {
            title.Id = index;
            modelBuilder.Entity<Title>().HasData(title);
            index++;
        }

        index = 1;
        foreach (var companyApplication in companyApplications)
        {
            companyApplication.Id = index;
            modelBuilder.Entity<CompanyApplication>().HasData(companyApplication);
            index++;
        }

        index = 1;
        foreach (var jobApplication in jobApplications)
        {
            jobApplication.Id = index;
            modelBuilder.Entity<JobApplication>().HasData(jobApplication);
            index++;
        }

        index = 1;
        foreach (var company in companies)
        {
            company.Id = index;
            modelBuilder.Entity<Company>().HasData(company);
            index++;
        }


        index = 1;
        foreach (var employee in employees)
        {
            employee.Id = index;
            modelBuilder.Entity<Employee>().HasData(employee);
            index++;
        }
    }
}