using Microsoft.AspNetCore.Mvc.Testing;
using Organization.Server.Dto;
using System.Text.Json;
namespace Organization.IntegrationTests;
/// <summary>
/// StatisticsIntegrationTest  - represents a integration test of StatisticsController
/// </summary>
[Collection("Sequential")]
public class AnalyticsIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the StatisticsIntegrationTest
    /// </summary>
    public AnalyticsIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    /// <summary>
    /// Tests correctness of the following task: "Output all employees of the given department"
    /// </summary>
    /// <param name="departmentId">The ID of the Department</param>
    /// <param name="employeeCount">The correct number of employees in the department</param>
    [Theory]
    [InlineData(1, 4)]
    [InlineData(2, 4)]
    public async Task GetEmployeesOfDepartment(uint departmentId, int employeeCount)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/Statistics/DepartmentId/{departmentId}");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonSerializer.Deserialize<List<GetEmployeeDto>>(content, _serializeOptions);
        Assert.NotNull(employees);
        Assert.Equal(employeeCount, employees.Count);
    }
    /// <summary>
    /// Tests correctness of the following task: "Output all employees working in more than 1 department. 
    /// Sort the result by last name, first name, patronymic name."
    /// </summary>
    [Fact]
    public async Task GetEmployeesWithFewDepartmentsDto()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeesWithFewDepartments");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonSerializer
            .Deserialize<List<EmployeeWithFewDepartmentsDto>>(content, _serializeOptions);
        Assert.NotNull(employees);
        Assert.Equal(3, employees.Count);
        Assert.DoesNotContain(employees, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 1337);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Tests correctness of the following task: "Output the archive of dismissals, including registration number, 
    /// first name, last name, patronymic name, date of birth, workshop, department, occupation of the employee."
    /// </summary>
    [Fact]
    public async Task GetArchiveOfDismissals()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/ArchiveOfDismissals");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var archiveOfDismissals = JsonSerializer
            .Deserialize<List<ArchiveOfDismissalsDto>>(content, _serializeOptions);
        Assert.NotNull(archiveOfDismissals);
        Assert.True(archiveOfDismissals.Count >= 4);
        Assert.DoesNotContain(archiveOfDismissals, requestElem => requestElem.RegNumber == 1337);
        Assert.DoesNotContain(archiveOfDismissals, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(archiveOfDismissals, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(archiveOfDismissals, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Tests correctness of the following task: "Output an average age of employees for each department"
    /// </summary>
    [Fact]
    public async Task GetAverageAgeInDepartmentDto()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/AvgAgeInDepartments");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var avgAgeInDepartments = JsonSerializer
            .Deserialize<List<AverageAgeInDepartmentDto>>(content, _serializeOptions);
        Assert.NotNull(avgAgeInDepartments);
        Assert.True(avgAgeInDepartments[0].AverageAge >= 37);
        Assert.True(avgAgeInDepartments[1].AverageAge >= 38);
        Assert.NotEqual(avgAgeInDepartments[0].AverageAge, avgAgeInDepartments[1].AverageAge);
        Assert.Equal(2, avgAgeInDepartments.Count);
    }
    /// <summary>
    /// Tests correctness of the following task: "Output the info about employees, 
    /// who received a vacation voucher in past year."
    /// </summary>
    [Fact]
    public async Task GetEmployeeLastYearVoucher()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeeLastYearVoucher");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employeesLastYearVoucher = JsonSerializer
            .Deserialize<List<EmployeeLastYearVoucherDto>>(content, _serializeOptions);
        Assert.NotNull(employeesLastYearVoucher);
        Assert.Contains(employeesLastYearVoucher, queryElem => queryElem.RegNumber == 1337);
        Assert.Contains(employeesLastYearVoucher, queryElem => queryElem.RegNumber == 443);
        Assert.Equal(2, employeesLastYearVoucher.Count);
    }
    /// <summary>
    /// Tests correctness of the following task: 
    /// "Output the top-5 employees who have the longest working experience at the company"
    /// </summary>
    [Fact]
    public async Task GetEmployeeWithLongestWorkExperience()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeeWithLongestWorkExperience");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employeeWorkExperience = JsonSerializer
            .Deserialize<List<EmployeeWorkExperienceDto>>(content, _serializeOptions);
        Assert.NotNull(employeeWorkExperience);
        Assert.Equal(4, employeeWorkExperience.Count);
        Assert.True(employeeWorkExperience[0].WorkExperience > 24);
        Assert.True(employeeWorkExperience[1].WorkExperience > 23);
        Assert.True(employeeWorkExperience[2].WorkExperience > 22);
        Assert.True(employeeWorkExperience[2].WorkExperience > 4);
        Assert.Equal((uint)3, employeeWorkExperience[0].RegNumber);
        Assert.Equal((uint)1337, employeeWorkExperience[1].RegNumber);
        Assert.Equal((uint)5, employeeWorkExperience[2].RegNumber);
        Assert.Equal((uint)443, employeeWorkExperience[3].RegNumber);
    }
}