using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;
namespace OrganizationEmployee.IntegrationTests;
/// <summary>
/// DepartmentIntegrationTest  - represents a integration test of DepartmentController
/// </summary>
public class DepartmentIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// A constructor of the DepartmentIntegrationTest
    /// </summary>
    public DepartmentIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    /// <summary>
    /// Tests the parameterless GET method
    /// </summary>
    [Fact]
    public async Task GetDepartments()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Department");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var departments = JsonConvert.DeserializeObject<List<DepartmentDto>>(content);
        Assert.NotNull(departments);
        Assert.True(departments.Count >= 8);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="departmentId">ID of the Department</param>
    /// <param name="departmentName">Correct Name of the Department</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(10, "Отдел снабжения и закупок", true)]
    [InlineData(2, "Отдел программирования", true)]
    [InlineData(9, "Отдел логистики", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetDepartment(uint departmentId, string departmentName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Department/{0}", departmentId));

        var content = await response.Content.ReadAsStringAsync();
        var department = JsonConvert.DeserializeObject<DepartmentDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(department);
            Assert.Equal(departmentName, department.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="departmentName">Name of the department that will be added</param>
    [Theory]
    [InlineData("Отдел техобслуживания")]
    [InlineData("Отдел медицинской помощи")]
    public async Task PostDepartment(string departmentName)
    {
        var departmentDto = new DepartmentDto()
        {
            Name = departmentName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Department", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Tests the PUT method
    /// </summary>
    /// <param name="departmentId">ID of the existing Department</param>
    /// <param name="departmentName">New name of the Department</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(4, "Отдел здравоохранения", true)]
    [InlineData(155, "Отдел здравоохранения", false)]
    public async Task PutDepartment(uint departmentId, string departmentName, bool isSuccess)
    {
        var departmentDto = new DepartmentDto()
        {
            Name = departmentName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/Department/{0}", departmentId), stringContent);

        var content = await response.Content.ReadAsStringAsync();
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
    /// Tests the DELETE method
    /// </summary>
    /// <param name="departmentId">ID of the existing Department</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(5, true)]
    [InlineData(133, false)]
    public async Task DeleteDepartment(int departmentId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/Department/{0}", departmentId));
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