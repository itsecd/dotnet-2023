using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for EmployeeController
/// </summary>
public class EmployeeIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    public EmployeeIntegrationTests(WebApplicationFactory<Server> factory)
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

        var response = await client.GetAsync("api/Employee");

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var employees = JsonSerializer.Deserialize<List<EmployeeGetDto>>(content, options);
        Assert.Equal(4, employees?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

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
        var response = await client.PostAsync("api/Employee", postData);

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
        var response = await client.PutAsync("api/Employee/1", putData);

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

        var response = await client.DeleteAsync("api/Employee/2");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetEmployeeByIdReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var expectedEmployee = new EmployeeGetDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };

        var response = await client.GetAsync("api/Employee/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var employeeReturned = JsonSerializer.Deserialize<EmployeeGetDto>(content, options);
        Assert.Equal(expectedEmployee.Id, employeeReturned?.Id);
    }
}
