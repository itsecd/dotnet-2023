using RecruitmentAgency;
namespace RecruitmentTests;
public class RecruitmentFixture
{
    public List<Company> FixtureCompanies
    {
        get
        {
            var companiesApplications = FixtureCompaniesApplications;
            var companies = new List<Company>();
            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            firstCompany.Id = 0;
            firstCompany.Applications.Add(companiesApplications[0].Id);
            companies.Add(firstCompany);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = 1;
            secondCompany.Applications.Add(companiesApplications[1].Id);
            companies.Add(secondCompany);
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = 2;
            thirdCompany.Applications.Add(companiesApplications[2].Id);
            companies.Add(thirdCompany);
            return companies;
        }
    }
    public List<Title> FixtureTitles
    {
        get
        {
            var companiesApplications = FixtureCompaniesApplications;
            var employeesApplications = FixtureJobApplications;
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
    public List<CompanyApplication> FixtureCompaniesApplications
    {
        get
        {
            var companiesApplications = new List<CompanyApplication>();
            var firstTitle = new Title();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            firstTitle.Id = 0;
            var secondTitle = new Title();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            secondTitle.Id = 1;
            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            firstCompany.Id = 0;
            var firstApplication = new CompanyApplication();
            firstApplication.CompanyId = firstCompany.Id;
            firstApplication.WorkExperience = 0;
            firstApplication.Salary = 50000;
            firstApplication.Date = new DateTime(2022, 12, 12);
            firstApplication.TitleId = firstTitle.Id;
            firstApplication.Education = "None";
            firstApplication.Id = 0;
            companiesApplications.Add(firstApplication);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            secondCompany.Id = 1;
            var secondApplication = new CompanyApplication();
            secondApplication.CompanyId = secondCompany.Id;
            secondApplication.WorkExperience = 1;
            secondApplication.Salary = 60000;
            secondApplication.Date = new DateTime(2022, 5, 9);
            secondApplication.TitleId = secondTitle.Id;
            secondApplication.Education = "Half";
            secondApplication.Id = 1;
            companiesApplications.Add(secondApplication);
            var thirdApplication = new CompanyApplication();
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            thirdCompany.Id = 2;
            thirdApplication.CompanyId = thirdCompany.Id;
            thirdApplication.WorkExperience = 2;
            thirdApplication.Salary = 70000;
            thirdApplication.Date = new DateTime(2022, 7, 6);
            thirdApplication.TitleId = firstTitle.Id;
            thirdApplication.Education = "Full";
            thirdApplication.Id = 2;
            companiesApplications.Add(thirdApplication);
            return companiesApplications;
        }
    }
    public List<Employee> FixtureEmployees
    {
        get
        {
            var employeeApplications = FixtureJobApplications;
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
    public List<JobApplication> FixtureJobApplications
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
            firstApplication.EmployeeId = firstEmployee.Id;
            firstApplication.TitleId = 0;
            firstApplication.Date = new DateTime(2022, 11, 11);
            firstApplication.Id = 0;
            jobApplications.Add(firstApplication);
            var secondApplication = new JobApplication();
            secondApplication.EmployeeId = secondEmployee.Id;
            secondApplication.TitleId = 1;
            secondApplication.Date = new DateTime(2022, 4, 9);
            secondApplication.Id = 1;
            jobApplications.Add(secondApplication);
            var thirdApplication = new JobApplication();
            thirdApplication.EmployeeId = thirdEmployee.Id;
            thirdApplication.TitleId = 0;
            thirdApplication.Date = new DateTime(2022, 6, 5);
            thirdApplication.Id = 2;
            jobApplications.Add(thirdApplication);
            return jobApplications;
        }
    }
}