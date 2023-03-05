using RecruitmentAgency;
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
        var result = (from e in _fixture.FixtureEmployees
                     join ja in _fixture.FixtureJobApplications on e equals ja.Employee
                     join ca in _fixture.FixtureCompaniesApplications on ja.Title equals ca.Title.JobTitle
                     where ja.Title == ca.Title.JobTitle && e.Salary <= ca.Salary && e.Education == ca.Education
                     select new { e.PersonalName, e.Salary }).ToList();

        Assert.Equal(0, result.Count);
    }
    [Fact]
    public void NumberApplicationTest()
    {
        var result = (from jt in _fixture.FixtureTitles
                     join ca in _fixture.FixtureCompaniesApplications on jt.JobTitle equals ca.Title.JobTitle
                     group ca by new { jt.JobTitle, jt.Section } into g
                     select g.Count()).Sum();

        Assert.Equal(3, result);
    }
}