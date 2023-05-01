using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using System.Globalization;
using System.Net;

namespace IntegrationTests;
/// <summary>
/// Integration test for RequestsController
/// </summary>
public class RequestsIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    private readonly HttpClient _client;
    public RequestsIntegrationTests(WebApplicationFactory<Server> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
    /// <summary>
    /// Test of the GetApplicantsRequestsForSpecificJobTitle method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetApplicantsRequestsForSpecificJobTitleTest()
    {
        await Task.Delay(5000).ConfigureAwait(false);
        var response = await _client.GetAsync("api/requests/applicants_requests/15");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    /// <summary>
    /// Test of the GetApplicantsOverGivenPeriod method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetApplicantsOverGivenPeriodTest()
    {
        await Task.Delay(5000).ConfigureAwait(false);
        var minDate = DateTime.ParseExact("2022-01-01T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        var maxDate = DateTime.ParseExact("2022-06-05T23:59:59Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        var response = await _client.GetAsync($"api/requests/applicants_over_given_period?minDate={minDate}&maxDate={maxDate}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    /// <summary>
    ///  Test of the GetApplicantsThatMatchCompanyApplication method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetApplicantsThatMatchCompanyApplicationTest()
    {
        await Task.Delay(5000).ConfigureAwait(false);
        var response = await _client.GetAsync("api/requests/applicants_matches/0");
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the GetNumberApplications method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetNumberApplicationsTest()
    {
        var response = await _client.GetAsync("api/requests/applications_number");
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the GetTheMostPopularCompanies method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTheMostPopularCompaniesTest()
    {
        var response = await _client.GetAsync("api/requests/the_most_popular_companies");
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the GetTheCompanyWithHighestWageTest method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTheCompanyWithHighestWageTest()
    {
        var response = await _client.GetAsync("api/requests/the_highest_wage");
        Assert.True(response.IsSuccessStatusCode);
    }
}
