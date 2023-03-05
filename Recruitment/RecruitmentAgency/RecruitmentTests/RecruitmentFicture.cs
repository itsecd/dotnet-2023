using RecruitmentAgency;
namespace RecruitmentTests;
public class RecruitmentFicture {
    public List<Company> FixtureCompanies
    {
        get
        {
            var companies = new List<Company>();
            var firstCompany = new Company();
            firstCompany.CompanyName = "Oracle";
            firstCompany.Telephone = "540-031";
            firstCompany.ContactName = "Steve Peterson";
            companies.Add(firstCompany);
            var secondCompany = new Company();
            secondCompany.CompanyName = "Netflix";
            secondCompany.Telephone = "532-176";
            secondCompany.ContactName = "Nikolay Petrov";
            companies.Add(secondCompany);
            var thirdCompany = new Company();
            thirdCompany.CompanyName = "Microsoft";
            thirdCompany.Telephone = "539-122";
            thirdCompany.ContactName = "Kyle Smith";
            companies.Add(thirdCompany);
            return companies;
        }
    }
    public List<Title> FixtureTitles
    {
        get
        {
            var titles = new List<Title>();
            var firstTitle = new Title();
            firstTitle.Section = "It";
            firstTitle.JobTitle = "Backend";
            titles.Add(firstTitle);
            var secondTitle = new Title();
            secondTitle.Section = "It";
            secondTitle.JobTitle = "Frontend";
            titles.Add(secondTitle);
            return titles;
        }
    }
    public List<CompanyApplication> FixtureCompaniesApplications
    {
        get
        {
            var companiesApplications = new List<CompanyApplication>();
            var companies = FixtureCompanies;
            var titles = FixtureTitles;
            var firstApplication = new CompanyApplication();
            firstApplication.Company = companies[0];
            firstApplication.WorkExperience = 0;
            firstApplication.Salary = 50000;
            firstApplication.Date = new DateTime(2022,12,12);
            firstApplication.Title = titles[0];
            firstApplication.Education = "None";
            companiesApplications.Add(firstApplication);
            var secondApplication = new CompanyApplication();
            secondApplication.Company = companies[1];
            secondApplication.WorkExperience = 1;
            secondApplication.Salary = 60000;
            secondApplication.Date = new DateTime(2022, 5, 9);
            secondApplication.Title = titles[1];
            secondApplication.Education = "Half";
            companiesApplications.Add(secondApplication);
            var thirdApplication = new CompanyApplication();
            thirdApplication.Company = companies[2];
            thirdApplication.WorkExperience = 2;
            thirdApplication.Salary = 70000;
            thirdApplication.Date = new DateTime(2022, 7, 6);
            thirdApplication.Title = titles[0];
            thirdApplication.Education = "Full";
            companiesApplications.Add(thirdApplication);
            return companiesApplications;
        }
    }
    public List<Employee> FixtureEmployees
    {
        get
        {
            var employees = new List<Employee>();
            var firstEmployee = new Employee();
            firstEmployee.PersonalName = "Smith Petrov";
            firstEmployee.Telephone = "531-100";
            firstEmployee.WorkExperience = 0;
            firstEmployee.Salary = 52000;
            firstEmployee.Education = "None";
            employees.Add(firstEmployee);
            var secondEmployee = new Employee();
            secondEmployee.PersonalName = "John Dishes";
            secondEmployee.Telephone = "520-301";
            secondEmployee.WorkExperience = 1;
            secondEmployee.Salary = 61000;
            secondEmployee.Education = "Half";
            employees.Add(secondEmployee);
            var thirdEmployee = new Employee();
            thirdEmployee.PersonalName = "Alex Walker";
            thirdEmployee.Telephone = "513-219";
            thirdEmployee.WorkExperience = 2;
            thirdEmployee.Salary = 72000;
            thirdEmployee.Education = "Full";
            employees.Add(thirdEmployee);
            return employees;
        }
    }
    public List<JobApplication> FixtureJobApplications
    {
        get
        {
            var employees = FixtureEmployees;
            var jobApplications = new List<JobApplication>();
            var firstApplication = new JobApplication();
            firstApplication.Employee = employees[0];
            firstApplication.Title = "Backend";
            firstApplication.Date = new DateTime(2022, 11, 11);
            jobApplications.Add(firstApplication);
            var secondApplication = new JobApplication();
            secondApplication.Employee = employees[1];
            secondApplication.Title = "Frontend";
            secondApplication.Date = new DateTime(2022, 4, 9);
            jobApplications.Add(secondApplication);
            var thirdApplication = new JobApplication();
            thirdApplication.Employee = employees[2];
            thirdApplication.Title = "Backend";
            thirdApplication.Date = new DateTime(2022, 6, 5);
            jobApplications.Add(thirdApplication);
            return jobApplications;
        }
    }
}