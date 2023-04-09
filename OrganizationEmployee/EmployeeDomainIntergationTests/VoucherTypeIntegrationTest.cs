using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;
namespace OrganizationEmployee.IntegrationTests;
/// <summary>
/// VoucherTypeIntegrationTest  - represents a integration test of VoucherTypeController
/// </summary>
public class VoucherTypeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the VoucherTypeIntegrationTest
    /// </summary>
    public VoucherTypeIntegrationTest(WebApplicationFactory<Program> factory)
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
    public async Task GetVoucherTypes()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/VoucherType");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var voucherTypes = JsonSerializer.Deserialize<List<GetVoucherTypeDto>>(content, _serializeOptions);
        Assert.NotNull(voucherTypes);
        Assert.True(voucherTypes.Count >= 1);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="voucherTypeId">ID of the voucher type</param>
    /// <param name="voucherTypeName">Correct name of the voucher type</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(0, "Санаторий", true)]
    [InlineData(1, "Дом отдыха", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetVoucherType(uint voucherTypeId, string voucherTypeName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/VoucherType/{voucherTypeId}");

        var content = await response.Content.ReadAsStringAsync();
        var voucherType = JsonSerializer.Deserialize<GetVoucherTypeDto>(content, _serializeOptions);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(voucherType);
            Assert.Equal(voucherTypeName, voucherType.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="voucherTypeName">Name of the voucher type</param>
    [Theory]
    [InlineData("Путевка на Черное море")]
    [InlineData("Путевка на озеро Байкал")]
    public async Task PostVoucherType(string voucherTypeName)
    {
        var voucherTypeDto = new PostVoucherTypeDto()
        {
            Name = voucherTypeName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(voucherTypeDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/VoucherType", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Tests the PUT method
    /// </summary>
    /// <param name="voucherTypeId">ID of the existing voucher type</param>
    /// <param name="voucherTypeName">A new name of the voucher type</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(2, "Пионерский лагерь организации", true)]
    [InlineData(155, "Путевка в Европу", false)]
    public async Task PutVoucherType(uint voucherTypeId, string voucherTypeName, bool isSuccess)
    {
        var voucherTypeDto = new PostVoucherTypeDto()
        {
            Name = voucherTypeName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(voucherTypeDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"api/VoucherType/{voucherTypeId}", stringContent);

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
    /// <param name="voucherTypeId">ID of the existing voucher type</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteVoucherType(int voucherTypeId, bool isSuccess)
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync($"api/VoucherType/{voucherTypeId}");
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