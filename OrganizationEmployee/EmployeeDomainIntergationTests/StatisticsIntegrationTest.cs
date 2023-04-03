using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
namespace EmployeeDomain.IntegrationTests;

public class StatisticsIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public StatisticsIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// First query - output all employees of the given department
    /// </summary>
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 4)]
    public async Task GetEmployeesOfDepartment(uint departmentId, int employeeCount)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Statistics/DepartmentId/{0}", departmentId));
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);
        Assert.NotNull(employees);
        Assert.Equal(employeeCount, employees.Count);
    }
    /// <summary>
    /// Second query - output all employees working in more than 1 department. Sort the result by last name, first name, patronymic name.
    /// </summary>
    [Fact]
    public async Task GetEmployeesWithFewDepartmentsDto()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeesWithFewDepartments");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonConvert.DeserializeObject<List<EmployeeWithFewDepartmentsDto>>(content);
        Assert.NotNull(employees);
        Assert.Equal(3, employees.Count);
        Assert.DoesNotContain(employees, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 1337);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(employees, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Third query - output the archive of dismissals, including registration number, first name, last name, patronymic name,
    /// date of birth, workshop, department, occupation of the employee.
    /// </summary>
    [Fact]
    public async Task GetArchiveOfDismissals()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/ArchiveOfDismissals");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var archiveOfDismissals = JsonConvert.DeserializeObject<List<ArchiveOfDismissalsDto>>(content);
        Assert.NotNull(archiveOfDismissals);
        Assert.Equal(4, archiveOfDismissals.Count);
        Assert.DoesNotContain(archiveOfDismissals, requestElem => requestElem.RegNumber == 1337);
        Assert.DoesNotContain(archiveOfDismissals, requestElem => requestElem.RegNumber == 443);
        Assert.Contains(archiveOfDismissals, requestElem => requestElem.RegNumber == 5);
        Assert.Contains(archiveOfDismissals, requestElem => requestElem.RegNumber == 3);
    }
    /// <summary>
    /// Fourth Query - output an average age of employees for each department
    /// </summary>
    [Fact]
    public async Task GetAverageAgeInDepartmentDto()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/AvgAgeInDepartments");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var avgAgeInDepartments = JsonConvert.DeserializeObject<List<AverageAgeInDepartmentDto>>(content);
        Assert.NotNull(avgAgeInDepartments);
        Assert.True(avgAgeInDepartments[0].AverageAge >= 37);
        Assert.True(avgAgeInDepartments[1].AverageAge >= 38);
        Assert.NotEqual(avgAgeInDepartments[0].AverageAge, avgAgeInDepartments[1].AverageAge);
        Assert.Equal(2, avgAgeInDepartments.Count);
    }
    /// <summary>
    /// Fifth query - output the info about employees, who received a vacation voucher in past year.
    /// </summary>
    [Fact]
    public async Task GetEmployeeLastYearVoucher()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeeLastYearVoucher");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employeesLastYearVoucher = JsonConvert.DeserializeObject<List<EmployeeLastYearVoucherDto>>(content);
        Assert.NotNull(employeesLastYearVoucher);
        Assert.Contains(employeesLastYearVoucher, queryElem => queryElem.RegNumber == 1337);
        Assert.Contains(employeesLastYearVoucher, queryElem => queryElem.RegNumber == 443);
        Assert.Equal(2, employeesLastYearVoucher.Count);
    }
    /// <summary>
    /// Output the top-5 employees who have the longest working experience at the company
    /// </summary>
    [Fact]
    public async Task GetEmployeeWithLongestWorkExperience()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Statistics/EmployeeWithLongestWorkExperience");
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var employeseWorkExperience = JsonConvert.DeserializeObject<List<EmployeeWorkExperienceDto>>(content);
        Assert.NotNull(employeseWorkExperience);
        Assert.Equal(4, employeseWorkExperience.Count);
        Assert.True(employeseWorkExperience[0].WorkExperience > 24);
        Assert.True(employeseWorkExperience[1].WorkExperience > 23);
        Assert.True(employeseWorkExperience[2].WorkExperience > 22);
        Assert.True(employeseWorkExperience[2].WorkExperience > 4);
        Assert.Equal((uint)3, employeseWorkExperience[0].RegNumber);
        Assert.Equal((uint)1337, employeseWorkExperience[1].RegNumber);
        Assert.Equal((uint)5, employeseWorkExperience[2].RegNumber);
        Assert.Equal((uint)443, employeseWorkExperience[3].RegNumber);
    }
}