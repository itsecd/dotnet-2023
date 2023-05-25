using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for EmployeeController
/// </summary>
[Collection("Tests")]
public class EmployeeIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly HttpClient _client;
    public EmployeeIntegrationTests(WebApplicationFactory<Server> factory)
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

        var response = await _client.GetAsync("api/Employee");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var newEmployee = new EmployeePostDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newEmployee, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/Employee", postData);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {
        var newEmployee = new EmployeePostDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newEmployee, options);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("api/Employee/1", putData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var response = await _client.DeleteAsync("api/Employee/255");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetEmployeeByIdReturnsSuccess()
    {
        var expectedEmployee = new EmployeeGetDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };

        var response = await _client.GetAsync("api/Employee/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var employeeReturned = JsonSerializer.Deserialize<EmployeeGetDto>(content, options);
        Assert.Equal(expectedEmployee.Id, employeeReturned?.Id);
    }
}
