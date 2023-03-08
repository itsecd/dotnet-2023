namespace RecruitmentTests;

using Newtonsoft.Json.Linq;
using System.Linq;
using Xunit.Sdk;

public class MediaTest : IClassFixture<RecruitmentFixture>
{
    private RecruitmentFixture _fixture;

    public MediaTest(RecruitmentFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void EmployeesTitlesTest()
    {
        var result = (from jobApplications in _fixture.FixtureJobApplications
                      where jobApplications.Title == "Backend"
                      orderby jobApplications.Employee.PersonalName
                      select jobApplications).ToList();

        Assert.Equal(2, result.Count);
    }
    [Fact]
    public void JobApplicationDateTest()
    {
        var result = (from jobApplications in _fixture.FixtureJobApplications
                      where jobApplications.Date >= new DateTime(2022, 2, 9) && jobApplications.Date <= new DateTime(2022, 8, 8)
                      select jobApplications).ToList();

        Assert.Equal(2, result.Count);
    }
    [Fact]
    public void CompanyApplicationTest()
    {
        var result = from applications in _fixture.FixtureTitles
                     from appCompany in applications.CompanyApplications.Where(appCompany => appCompany.Id == 2)
                     from appEmployee in applications.EmployeeApplications.Where(appEmployee => appEmployee.Employee.Salary <= appCompany.Salary &&
                     appEmployee.Employee.Education == appCompany.Education && appEmployee.Title == appCompany.Title.JobTitle &&
                     appEmployee.Employee.WorkExperience >= appCompany.WorkExperience)
                     select new
                     {
                         Employee = appEmployee,
                     };


        Assert.Single(result);
    }
    [Fact]
    public void NumberApplicationTest()
    {
        var result = from titles in _fixture.FixtureTitles
                     select new
                     {
                         JobSection = titles.Section,
                         JobTitle = titles.JobTitle,
                         NumJobApplications = titles.EmployeeApplications.Count(jobApplication => jobApplication.Title == titles.JobTitle),
                         NumCompanyApplications = titles.CompanyApplications.Count(companyApplication => companyApplication.Title.JobTitle == titles.JobTitle)
                     };
        var firstItem = result.First();
        var secondItem = result.Last();
        Assert.Equal(2, firstItem.NumJobApplications);
        Assert.Equal(1, secondItem.NumJobApplications);
        Assert.Equal("Backend", firstItem.JobTitle);
        Assert.Equal("Frontend", secondItem.JobTitle);
    }
    [Fact]
    public void MostPopularCompaniesTest()
    {
        var result = (from ca in _fixture.FixtureCompaniesApplications
                      group ca by ca.Company.CompanyName into g
                      orderby g.Count() descending
                      select new
                      {
                          Company = g.Key,
                          NumRequests = g.Count()
                      }).Take(5).ToList();
        var expected = new List<string> { "Microsoft", "Netflix", "Oracle" };

        Assert.Equal(expected[0], result[2].Company);
        Assert.Equal(expected[1], result[1].Company);
        Assert.Equal(expected[2], result[0].Company);
    }
    [Fact]
    public void BiggestSalaryTest()
    {
        var result = from companyApplication in _fixture.FixtureCompaniesApplications
                     where companyApplication.Salary == (from companyApplicationSalaries in _fixture.FixtureCompaniesApplications
                                         select companyApplicationSalaries.Salary).Max()
                     select new
                     {
                         CompanyRequest = companyApplication,
                     };
        Assert.Equal(70000, result.First().CompanyRequest.Salary);
    }
}