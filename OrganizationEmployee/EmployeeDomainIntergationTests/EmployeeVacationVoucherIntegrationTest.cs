using Microsoft.AspNetCore.Mvc.Testing;
using OrganizationServer.Dto;
using System.Text;
using System.Text.Json;

namespace EmployeeDomainIntergationTests;
/// <summary>
/// EmployeeVacationVoucherIntegrationTest  - represents a integration test of EmployeeVacationVoucherController
/// </summary>
public class EmployeeVacationVoucherIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the EmployeeVacationVoucherIntegrationTest
    /// </summary>
    public EmployeeVacationVoucherIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    /// <summary>
    /// Tests the parameterless GET method
    /// </summary>
    [Fact]
    public async Task GetEmployeeVacationVouchers()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/EmployeeVacationVoucher");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var employeeVacationVouchers = JsonSerializer
            .Deserialize<List<GetEmployeeVacationVoucherDto>>(content, _serializeOptions);
        Assert.NotNull(employeeVacationVouchers);
        Assert.True(employeeVacationVouchers.Count >= 1);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="employeeVacationVoucherId">ID of the EmployeeVacationVoucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetEmployeeVacationVoucher(uint employeeVacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .GetAsync($"api/EmployeeVacationVoucher/{employeeVacationVoucherId}");

        var content = await response.Content.ReadAsStringAsync();
        var employeeVacationVoucher = JsonSerializer
            .Deserialize<GetEmployeeVacationVoucherDto>(content, _serializeOptions);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(employeeVacationVoucher);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="voucherId">The ID of the VacationVoucher</param>
    /// <param name="employeeId">The ID of the Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(1, 2011, false)]
    [InlineData(2011, 1, false)]
    public async Task PostEmployeeVacationVoucher(uint voucherId, uint employeeId, bool isSuccess)
    {
        var employeeVacationVoucherDto = new PostEmployeeVacationVoucherDto()
        {
            VacationVoucherId = voucherId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(employeeVacationVoucherDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/EmployeeVacationVoucher", stringContent);
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
    /// Tests the PUT method
    /// </summary>
    /// <param name="employeeVacationVoucherId">The ID of the existing EmployeeVacationVoucher</param>
    /// <param name="voucherId">The new ID of the VacationVoucher</param>
    /// <param name="employeeId">The new ID of the Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(2, 1, 1, true)]
    [InlineData(2, 1, 1111, false)]
    [InlineData(2, 1111, 1, false)]
    [InlineData(2226, 1, 1, false)]
    public async Task PutEmployeeVacationVoucher(uint employeeVacationVoucherId, uint voucherId, uint employeeId,
        bool isSuccess)
    {
        var employeeVacationVoucherDto = new PostEmployeeVacationVoucherDto()
        {
            VacationVoucherId = voucherId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(employeeVacationVoucherDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client
            .PutAsync($"api/EmployeeVacationVoucher/{employeeVacationVoucherId}", stringContent);

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
    /// <param name="employeeVacationVoucherId">The ID of the existing EmployeeVacationVoucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteEmployeeVacationVoucher(uint employeeVacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .DeleteAsync($"api/EmployeeVacationVoucher/{employeeVacationVoucherId}");
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