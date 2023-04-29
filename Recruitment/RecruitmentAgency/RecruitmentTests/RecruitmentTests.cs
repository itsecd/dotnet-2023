namespace RecruitmentTests;

using System.Linq;

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
                      where jobApplications.TitleId == 0
                      orderby jobApplications?.EmployeeId
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
        var result = (from employee in _fixture.FixtureEmployees
                      join jobApplication in _fixture.FixtureJobApplications on employee.Id equals jobApplication.EmployeeId
                      join companyApplication in _fixture.FixtureCompaniesApplications on jobApplication.TitleId equals companyApplication.TitleId
                      where jobApplication.TitleId == 0 &&
                            employee.Salary <= companyApplication.Salary &&
                            employee.Education == companyApplication.Education
                      select new
                      {
                          PersonalName = employee.PersonalName,
                          Salary = employee.Salary,
                          CompanySalary = companyApplication.Salary
                      });
        Assert.Single(result);
    }
    [Fact]
    public void NumberApplicationTest()
    {
        var result = from titles in _fixture.FixtureTitles
                     join jobApplications in _fixture.FixtureJobApplications on titles.Id equals jobApplications.TitleId into jobApplicationsGroup
                     select new
                     {
                         JobSection = titles.Section,
                         JobTitle = titles.JobTitle,
                         NumJobApplications = jobApplicationsGroup.Count(),
                         NumCompanyApplications = titles.CompanyApplications.Count()
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
        var query = (from company in _fixture.FixtureCompanies
                     join companyApplication in _fixture.FixtureCompaniesApplications on company.Id equals companyApplication.CompanyId into gj
                     orderby gj.Count() descending
                     select new
                     {
                         CompanyName = company.CompanyName,
                         NumberOfApplications = gj.Count()
                     }).Take(5).ToList();
        var expected = new List<string> { "Microsoft", "Netflix", "Oracle" };

        Assert.Equal(expected[0], query[2].CompanyName);
        Assert.Equal(expected[1], query[1].CompanyName);
        Assert.Equal(expected[2], query[0].CompanyName);
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