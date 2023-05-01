using Microsoft.AspNetCore.Mvc.Testing;
using OrganizationServer.Dto;
using System.Text;
using System.Text.Json;
namespace EmployeeDomainIntergationTests;
/// <summary>
/// DepartmentIntegrationTest  - represents a integration test of DepartmentController
/// </summary>
public class DepartmentIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the DepartmentIntegrationTest
    /// </summary>
    public DepartmentIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        _client = factory.CreateClient();
    }
    /// <summary>
    /// Tests the parameterless GET method
    /// </summary>
    [Fact]
    public async Task GetDepartments()
    {
        var response = await _client.GetAsync("api/Department");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var departments = JsonSerializer.Deserialize<List<GetDepartmentDto>>(content, _serializeOptions);
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
        var response = await _client.GetAsync($"api/Department/{departmentId}");
        var content = await response.Content.ReadAsStringAsync();
        var department = JsonSerializer.Deserialize<GetDepartmentDto>(content, _serializeOptions);
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
        var departmentDto = new PostDepartmentDto()
        {
            Name = departmentName
        };
        var jsonObject = JsonSerializer.Serialize(departmentDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/Department", stringContent);
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
        var departmentDto = new PostDepartmentDto()
        {
            Name = departmentName
        };
        var jsonObject = JsonSerializer.Serialize(departmentDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"api/Department/{departmentId}", stringContent);

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
        var response = await _client.DeleteAsync($"api/Department/{departmentId}");
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