using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RecruitmentAgency;

namespace MyServer.Tests;
/// <summary>
/// Integration test for RequestsController
/// </summary>
public class RequestsIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public RequestsIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    /// <summary>
    /// Test of the GetApplicantsRequestsForSpecificJobTitle method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetApplicantsRequestsForSpecificJobTitleTest()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/requests/applicants_requests/Backend");
        var content = await response.Content.ReadAsStringAsync();
        var jobApplications = JsonConvert.DeserializeObject<List<JobApplicationGetDTO>>(content);
        Assert.Equal(2, jobApplications?.Count);
    }
    /// <summary>
    /// Test of the GetPassengerOverGivenPeriod method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetPassengerOverGivenPeriodTest()
    {
        var client = _factory.CreateClient();

        var minDate = "2022-04-09T00:00:00Z";
        var maxDate = "2022-06-05T23:59:59Z";

        var response = await client.GetAsync($"/api/requests/applicants_over_given_period?minDate={minDate}&maxDate={maxDate}");
        var content = await response.Content.ReadAsStringAsync();
        var employeeReturned = JsonConvert.DeserializeObject<List<EmployeeGetDTO>>(content);
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(2, employeeReturned?.Count);
    }
    /// <summary>
    ///  Test of the GetApplicantsThatMatchCompanyApplication method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetApplicantsThatMatchCompanyApplicationTest()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/requests/applicants_matches/2");
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the GetNumberApplications method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetNumberApplicationsTest()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/requests/applications_number");
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the GetTheMostPopularCompanies method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTheMostPopularCompaniesTest()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/requests/the_most_popular_companies");
        var content = await response.Content.ReadAsStringAsync();
        var companiesReturned = JsonConvert.DeserializeObject<List<Company>>(content);
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(3, companiesReturned?.Count);
    }
    /// <summary>
    /// Test of the GetTheCompanyWithHighestWageTest method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTheCompanyWithHighestWageTest()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/api/requests/the_highest_wage");
        var content = await response.Content.ReadAsStringAsync();
        var applicationsReturned = JsonConvert.DeserializeObject<List<CompanyApplication>>(content);
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(1, applicationsReturned?.Count);
    }
}
