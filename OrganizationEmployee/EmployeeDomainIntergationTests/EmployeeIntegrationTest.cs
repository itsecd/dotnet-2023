using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using EmployeeDomain;
using OrganizationServer;


namespace MyServer.Tests;

public class EmployeeIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public EmployeeIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_Values_ReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Employee/2");

        var content = await response.Content.ReadAsStringAsync();
        var employee = JsonConvert.DeserializeObject<Employee>(content);
        //var employees = JsonConvert.DeserializeObject<List<Employee>>(content);
        Assert.NotNull(employee);
        // Assert.Equal(1, employees.Count());
    }
}