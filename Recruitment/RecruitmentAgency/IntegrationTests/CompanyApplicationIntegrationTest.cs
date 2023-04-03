using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace MyServer.Tests;
/// <summary>
/// Integration tests for CompanyApplicationController
/// </summary>
public class CompanyApplicationIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public CompanyApplicationIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
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

        var content = await response.Content.ReadAsStringAsync();
        var companiesApplciations = JsonConvert.DeserializeObject<List<CompanyApplicationGetDTO>>(content);
        Assert.Equal(3, companiesApplciations?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newApplication = new CompanyApplicationGetDTO()
        {
            Date = DateTime.Now,
            WorkExperience = 2,
            Salary = 92000,
            Education = "None",
            Id = 0
        };

        var requestContent = JsonConvert.SerializeObject(newApplication);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/CompanyApplication", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newApplication = new CompanyApplicationGetDTO()
        {
            Date = DateTime.Now,
            WorkExperience = 2,
            Salary = 92000,
            Education = "None",
            Id = 0
        };

        var requestContent = JsonConvert.SerializeObject(newApplication);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/CompanyApplication/0", putData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync("/api/CompanyApplication/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCompanyApplicationByIdReturnsSeuccess()
    {
        var client = _factory.CreateClient();

        var expectedApplication = new CompanyApplicationGetDTO()
        {
            Date = DateTime.Now,
            WorkExperience = 2,
            Salary = 92000,
            Education = "None",
            Id = 0
        };

        var response = await client.GetAsync("api/CompanyApplication/0");
        var content = await response.Content.ReadAsStringAsync();
        var applicationReturned = JsonConvert.DeserializeObject<CompanyApplicationGetDTO>(content);
        Assert.Equal(expectedApplication.Id, applicationReturned?.Id);
    }
}
