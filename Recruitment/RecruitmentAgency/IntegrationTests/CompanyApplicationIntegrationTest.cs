using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Net;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IntegrationTests;
/// <summary>
/// Integration tests for CompanyApplicationController
/// </summary>
public class CompanyApplicationIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    public CompanyApplicationIntegrationTests(WebApplicationFactory<Server> factory)
    {
        _factory = factory;
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newCompany = new CompanyApplicationPostDto()
        {
            
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newCompany, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/CompanyApplication", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/CompanyApplication");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newApplication = new CompanyApplicationGetDto()
        {
            Date = DateTime.Now,
            WorkExperience = 2,
            Salary = 92000,
            Education = "None",
            Id = 0
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newApplication, options);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("api/CompanyApplication/0", putData);

        Assert.False(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync("api/CompanyApplication/5");

        Assert.False(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCompanyApplicationByIdReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var expectedApplication = new CompanyApplicationGetDto()
        {
            Date = DateTime.Now,
            WorkExperience = 2,
            Salary = 92000,
            Education = "None",
            Id = 0
        };

        var response = await client.GetAsync("api/CompanyApplication/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var applicationReturned = JsonSerializer.Deserialize<CompanyApplicationGetDto>(content, options);
        Assert.Equal(expectedApplication.Id, applicationReturned?.Id);
    }
}
