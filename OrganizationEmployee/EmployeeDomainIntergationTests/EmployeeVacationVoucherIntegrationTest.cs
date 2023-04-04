using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
using System.Text;

namespace EmployeeDomain.IntegrationTests;
public class EmployeeVacationVoucherIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public EmployeeVacationVoucherIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetEmployeeVacationVouchers()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/EmployeeVacationVoucher");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var employeeVacationVouchers = JsonConvert.DeserializeObject<List<EmployeeVacationVoucherDto>>(content);
        Assert.NotNull(employeeVacationVouchers);
        Assert.True(employeeVacationVouchers.Count >= 1);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetEmployeeVacationVoucher(uint employeeVacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .GetAsync(string.Format("api/EmployeeVacationVoucher/{0}", employeeVacationVoucherId));

        var content = await response.Content.ReadAsStringAsync();
        var employeeVacationVoucher = JsonConvert.DeserializeObject<EmployeeVacationVoucherDto>(content);
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
    
    [Theory]
    [InlineData(1, 1, true)]
    [InlineData(1, 2011, false)]
    [InlineData(2011, 1, false)]
    public async Task PostEmployeeVacationVoucher(uint voucherId, uint employeeId, bool isSuccess)
    {
        var employeeVacationVoucherDto = new EmployeeVacationVoucherDto()
        {
            VacationVoucherId = voucherId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(employeeVacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
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
    
    [Theory]
    [InlineData(2, 1, 1, true)]
    [InlineData(2, 1, 1111, false)]
    [InlineData(2, 1111, 1, false)]
    [InlineData(2226, 1, 1, false)]
    public async Task PutEmployeeVacationVoucher(uint employeeVacationVoucherId, uint voucherId, uint employeeId, bool isSuccess)
    {
        var employeeVacationVoucherDto = new EmployeeVacationVoucherDto()
        {
            VacationVoucherId = voucherId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(employeeVacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client
            .PutAsync(string.Format("api/EmployeeVacationVoucher/{0}", employeeVacationVoucherId), stringContent);

        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    
    [Theory]
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteEmployeeVacationVoucher(uint employeeVacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .DeleteAsync(string.Format("api/EmployeeVacationVoucher/{0}", employeeVacationVoucherId));
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