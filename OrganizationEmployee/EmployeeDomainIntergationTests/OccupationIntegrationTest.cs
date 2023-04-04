using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;
namespace OrganizationEmployee.IntegrationTests;
public class OccupationIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public OccupationIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetOccupations()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Occupation");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var occupations = JsonConvert.DeserializeObject<List<OccupationDto>>(content);
        Assert.NotNull(occupations);
        Assert.True(occupations.Count >= 3);
    }

    [Theory]
    [InlineData(0, "Аналитик данных", true)]
    [InlineData(1, "Программист", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetOccupation(uint occupationId, string occupationName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Occupation/{0}", occupationId));

        var content = await response.Content.ReadAsStringAsync();
        var occupation = JsonConvert.DeserializeObject<OccupationDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(occupation);
            Assert.Equal(occupationName, occupation.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData("Дизайнер")]
    [InlineData("Специалист по информационной безопасности")]
    public async Task PostOccupation(string occupationName)
    {
        var occupationDto = new OccupationDto()
        {
            Name = occupationName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(occupationDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Occupation", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }

    [Theory]
    [InlineData(2, "Отдел здравоохранения", true)]
    [InlineData(155, "Отдел здравоохранения", false)]
    public async Task PutOccupation(uint occupationId, string occupationName, bool isSuccess)
    {
        var departmentDto = new OccupationDto()
        {
            Name = occupationName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/Occupation/{0}", occupationId), stringContent);

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

    /*
    [Theory]
    [InlineData(3, true)]
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
    }*/
}