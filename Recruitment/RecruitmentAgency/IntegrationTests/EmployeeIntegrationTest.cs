using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace MyServer.Tests;
/// <summary>
/// Integration test for EmployeeController
/// </summary>
public class EmployeeIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public EmployeeIntegrationTests(WebApplicationFactory<Program> factory)
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
        var employees = JsonConvert.DeserializeObject<List<EmployeeGetDTO>>(content);
        Assert.Equal(3, employees?.Count);
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

        var requestContent = JsonConvert.SerializeObject(newEmployee);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/Employee", postData);

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

        var requestContent = JsonConvert.SerializeObject(newEmployee);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/Employee/1", putData);

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

        var response = await client.DeleteAsync("/api/Employee/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetEmployeeByIdReturnsSeuccess()
    {
        var client = _factory.CreateClient();
        var expectedEmployee = new EmployeeGetDTO()
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
        var employeeReturned = JsonConvert.DeserializeObject<EmployeeGetDTO>(content);
        Assert.Equal(expectedEmployee.Id, employeeReturned?.Id);
    }
}
