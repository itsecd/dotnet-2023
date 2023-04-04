using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;
namespace OrganizationEmployee.IntegrationTests;
public class VoucherTypeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public VoucherTypeIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetVoucherTypes()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/VoucherType");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var voucherTypes = JsonConvert.DeserializeObject<List<VoucherTypeDto>>(content);
        Assert.NotNull(voucherTypes);
        Assert.True(voucherTypes.Count >= 1);
    }

    [Theory]
    [InlineData(0, "Санаторий", true)]
    [InlineData(1, "Дом отдыха", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetVoucherType(uint voucherTypeId, string voucherTypeName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/VoucherType/{0}", voucherTypeId));

        var content = await response.Content.ReadAsStringAsync();
        var voucherType = JsonConvert.DeserializeObject<VoucherTypeDto>(content);
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

    [Theory]
    [InlineData("Путевка на Черное море")]
    [InlineData("Путевка на озеро Байкал")]
    public async Task PostVoucherType(string voucherTypeName)
    {
        var voucherTypeDto = new VoucherTypeDto()
        {
            Name = voucherTypeName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(voucherTypeDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/VoucherType", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }

    [Theory]
    [InlineData(2, "Пионерский лагерь организации", true)]
    [InlineData(155, "Путевка в Европу", false)]
    public async Task PutVoucherType(uint voucherTypeId, string voucherTypeName, bool isSuccess)
    {
        var voucherTypeDto = new VoucherTypeDto()
        {
            Name = voucherTypeName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(voucherTypeDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/VoucherType/{0}", voucherTypeId), stringContent);

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
    public async Task DeleteVoucherType(int voucherTypeId, bool isSuccess)
    {
        var client = _factory.CreateClient();
        var response = await client.DeleteAsync(string.Format("api/VoucherType/{0}", voucherTypeId));
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