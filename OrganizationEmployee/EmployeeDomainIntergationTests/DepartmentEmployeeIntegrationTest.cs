using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;

namespace OrganizationEmployee.IntegrationTests;
/// <summary>
/// DepartmentEmployeeIntegrationTest  - represents a integration test of DepartmentEmployeeController
/// </summary>
public class DepartmentEmployeeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// A constructor of the DepartmentEmployeeIntegrationTest
    /// </summary>
    public DepartmentEmployeeIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    /// <summary>
    /// Tests the parameterless GET method
    /// </summary>
    [Fact]
    public async Task GetDepartmentEmployees()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/DepartmentEmployee");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var departmentEmployees = JsonConvert.DeserializeObject<List<DepartmentEmployeeDto>>(content);
        Assert.NotNull(departmentEmployees);
        Assert.True(departmentEmployees.Count >= 5);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="departmentEmployeeId">ID of DepartmentEmployee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetDepartmentEmployee(uint departmentEmployeeId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/DepartmentEmployee/{0}", departmentEmployeeId));

        var content = await response.Content.ReadAsStringAsync();
        var departmentEmployee = JsonConvert.DeserializeObject<DepartmentEmployeeDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(departmentEmployee);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the parameterized POST method
    /// </summary>
    /// <param name="departmentId">ID of Department</param>
    /// <param name="employeeId">ID of Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(1, 555, false)]
    [InlineData(565, 1, false)]
    [InlineData(565, 15345, false)]
    public async Task PostDepartmentEmployee(uint departmentId, uint employeeId, bool isSuccess)
    {
        var departmentEmployeeDto = new DepartmentEmployeeDto()
        {
            DepartmentId = departmentId,
            EmployeeId = employeeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentEmployeeDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/DepartmentEmployee", stringContent);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the parameterized PUT method
    /// </summary>
    /// <param name="departmentEmployeeId">ID of existing DepartmentEmployee</param>
    /// <param name="departmentId">ID of Department</param>
    /// <param name="employeeId">ID of Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(6, 1, 1, true)]
    [InlineData(111, 1, 1, false)]
    [InlineData(6, 333, 1, false)]
    [InlineData(6, 1, 333, false)]
    [InlineData(6, 353, 333, false)]
    public async Task PutDepartmentEmployee(uint departmentEmployeeId, uint departmentId, uint employeeId, bool isSuccess)
    {
        var departmentEmployeeDto = new DepartmentEmployeeDto()
        {
            DepartmentId = departmentId,
            EmployeeId = employeeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentEmployeeDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/DepartmentEmployee/{0}", departmentEmployeeId), stringContent);

        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the parameterized DELETE method
    /// </summary>
    /// <param name="departmentEmployeeId">ID of existing DepartmentEmployee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(7, true)]
    [InlineData(133, false)]
    public async Task DeleteDepartmentEmployee(int departmentEmployeeId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/DepartmentEmployee/{0}", departmentEmployeeId));
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}