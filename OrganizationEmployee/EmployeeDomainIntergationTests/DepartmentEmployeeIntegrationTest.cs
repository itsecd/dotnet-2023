using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
using System.Text;
namespace EmployeeDomain.IntegrationTests;
public class DepartmentEmployeeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public DepartmentEmployeeIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

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
    /*
    [Theory]
    [InlineData(2020, 11, 23, 0, true)]
    [InlineData(2011, 3, 15, 1, true)]
    [InlineData(2011, 3, 15, 33, false)]
    public async Task PostVacationVoucher(int issueYear, int issueMonth, int issueDay,
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new VacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(vacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/VacationVoucher", stringContent);
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
    [InlineData(2, 2020, 11, 23, 0, true)]
    [InlineData(2, 2020, 11, 23, 55, false)]
    [InlineData(55, 2011, 3, 15, 0, false)]
    public async Task PutVacationVoucher(uint vacationVoucherId, int issueYear, int issueMonth, int issueDay,
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new VacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(vacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/VacationVoucher/{0}", vacationVoucherId), stringContent);

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
    public async Task DeleteVacationVoucher(int vacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/VacationVoucher/{0}", vacationVoucherId));
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }*/
}