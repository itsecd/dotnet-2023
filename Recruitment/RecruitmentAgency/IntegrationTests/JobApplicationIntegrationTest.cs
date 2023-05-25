using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for JobApplicationController
/// </summary>
[Collection("Tests")]
public class JobApplicationIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly HttpClient _client;
    public JobApplicationIntegrationTests(WebApplicationFactory<Server> factory)
    {
        _client = factory.CreateClient();
    }
    /// <summary>
    /// Test of the get method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetValuesReturnsSuccess()
    {

        var response = await _client.GetAsync("api/JobApplication");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var newApplication = new JobApplicationPostDto()
        {
            EmployeeId = 1,
            Date = DateTime.Now,
            TitleId = 1
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newApplication, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/JobApplication", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {

        var newJobApplication = new JobApplicationPostDto()
        {
            TitleId = 1,
            EmployeeId = 1,
            Date = DateTime.Now
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newJobApplication, options);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("api/JobApplication/15", putData);

        Assert.False(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var response = await _client.DeleteAsync("api/JobApplication/15");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetJobApplicationByIdReturnsSuccess()
    {
        var response = await _client.GetAsync("api/JobApplication/353");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
