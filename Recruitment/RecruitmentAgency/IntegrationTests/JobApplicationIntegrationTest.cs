using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace MyServer.Tests;
/// <summary>
/// Integration test for JobApplicationController
/// </summary>
public class JobApplicationIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public JobApplicationIntegrationTests(WebApplicationFactory<Program> factory)
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

        var response = await client.GetAsync("api/JobApplication");

        var content = await response.Content.ReadAsStringAsync();
        var jobApplciations = JsonConvert.DeserializeObject<List<JobApplicationGetDTO>>(content);
        Assert.Equal(3, jobApplciations?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var newEmployee = new EmployeePostDTO()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var newApplication = new JobApplicationGetDTO()
        {
            Employee = newEmployee,
            Title = "Backend",
            Id = 0
        };

        var requestContent = JsonConvert.SerializeObject(newApplication);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/JobApplication", postData);

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
        var newEmployee = new EmployeePostDTO()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var newApplication = new JobApplicationGetDTO()
        {
            Employee = newEmployee,
            Title = "Backend",
            Id = 0
        };

        var requestContent = JsonConvert.SerializeObject(newApplication);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/JobApplication/0", putData);

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

        var response = await client.DeleteAsync("/api/JobApplication/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetJobApplicationByIdReturnsSeuccess()
    {
        var client = _factory.CreateClient();
        var newEmployee = new EmployeePostDTO()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var expectedApplication = new JobApplicationGetDTO()
        {
            Employee = newEmployee,
            Date = DateTime.Now,
            Title = "Backend",
            Id = 0
        };

        var response = await client.GetAsync("api/JobApplication/0");
        var content = await response.Content.ReadAsStringAsync();
        var applicationReturned = JsonConvert.DeserializeObject<JobApplicationGetDTO>(content);
        Assert.Equal(expectedApplication.Id, applicationReturned?.Id);
    }
}
