using Microsoft.AspNetCore.Mvc.Testing;
using OrganizationServer.Dto;
using System.Text;
using System.Text.Json;
namespace EmployeeDomainIntegrationTests;
/// <summary>
/// VacationVoucherIntegrationTest  - represents a integration test of VacationVoucherController
/// </summary>
[Collection("Sequential")]
public class VacationVoucherIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the VacationVoucherIntegrationTest
    /// </summary>
    public VacationVoucherIntegrationTest(WebApplicationFactory<Program> factory)
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
    public async Task GetVacationVouchers()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/VacationVoucher");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var vacationVouchers = JsonSerializer
            .Deserialize<List<GetVacationVoucherDto>>(content, _serializeOptions);
        Assert.NotNull(vacationVouchers);
        Assert.True(vacationVouchers.Count >= 1);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="vacationVoucherId">ID of the VacationVoucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetVacationVoucher(uint vacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/VacationVoucher/{vacationVoucherId}");

        var content = await response.Content.ReadAsStringAsync();
        var vacationVoucher = JsonSerializer.Deserialize<GetVacationVoucherDto>(content, _serializeOptions);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(vacationVoucher);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="issueYear">The year when the vacation voucher was been issued</param>
    /// <param name="issueMonth">The month when the vacation voucher was been issued</param>
    /// <param name="issueDay">The day when the vacation voucher was been issued</param>
    /// <param name="voucherTypeId">The voucher type id of the vacation voucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(2020, 11, 23, 2, true)]
    [InlineData(2011, 3, 15, 1, true)]
    [InlineData(2011, 3, 15, 33, false)]
    public async Task PostVacationVoucher(int issueYear, int issueMonth, int issueDay,
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new PostVacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(vacationVoucherDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
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
    /// <summary>
    /// Tests the PUT method
    /// </summary>
    /// <param name="vacationVoucherId">The ID of the existing vacation voucher</param>
    /// <param name="issueYear">The new year when the vacation voucher was been issued</param>
    /// <param name="issueMonth">The new month when the vacation voucher was been issued</param>
    /// <param name="issueDay">The new day when the vacation voucher was been issued</param>
    /// <param name="voucherTypeId">The new voucher type id of the vacation voucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(2, 2020, 11, 23, 1, true)]
    [InlineData(2, 2020, 11, 23, 55, false)]
    [InlineData(55, 2011, 3, 15, 1, false)]
    public async Task PutVacationVoucher(uint vacationVoucherId, int issueYear, int issueMonth, int issueDay,
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new PostVacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(vacationVoucherDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"api/VacationVoucher/{vacationVoucherId}", stringContent);

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
    /// <param name="vacationVoucherId">The ID of the existing vacation voucher</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteVacationVoucher(int vacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/VacationVoucher/{vacationVoucherId}");
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