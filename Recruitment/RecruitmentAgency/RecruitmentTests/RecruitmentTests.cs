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
}