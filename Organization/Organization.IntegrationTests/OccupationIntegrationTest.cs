using Microsoft.AspNetCore.Mvc.Testing;
using Organization.Server.Dto;
using System.Text;
using System.Text.Json;
namespace Organization.IntegrationTests;
/// <summary>
/// OccupationIntegrationTest  - represents a integration test of OccupationController
/// </summary>
[Collection("Sequential")]
public class OccupationIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the OccupationIntegrationTest
    /// </summary>
    public OccupationIntegrationTest(WebApplicationFactory<Program> factory)
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
    public async Task GetOccupations()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Occupation");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var occupations = JsonSerializer.Deserialize<List<GetOccupationDto>>(content, _serializeOptions);
        Assert.NotNull(occupations);
        Assert.True(occupations.Count >= 3);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="occupationId">ID of the Occupation</param>
    /// <param name="occupationName">Correct name of the Occupation</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, "Аналитик данных", true)]
    [InlineData(2, "Программист", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetOccupation(uint occupationId, string occupationName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/Occupation/{occupationId}");

        var content = await response.Content.ReadAsStringAsync();
        var occupation = JsonSerializer.Deserialize<GetOccupationDto>(content, _serializeOptions);
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
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="occupationName">The name of the Occupation</param>
    [Theory]
    [InlineData("Дизайнер")]
    [InlineData("Специалист по информационной безопасности")]
    public async Task PostOccupation(string occupationName)
    {
        var occupationDto = new PostOccupationDto()
        {
            Name = occupationName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(occupationDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Occupation", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="occupationId">The ID of the existing occupation</param>
    /// <param name="occupationName">The new name of the Occupation</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(3, "Специалист по компьютерной безопасности", true)]
    [InlineData(155, "Отдел здравоохранения", false)]
    public async Task PutOccupation(uint occupationId, string occupationName, bool isSuccess)
    {
        var departmentDto = new PostOccupationDto()
        {
            Name = occupationName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(departmentDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"api/Occupation/{occupationId}", stringContent);

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
    /// <param name="occupationId">The ID of the existing occupation</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(6, true)]
    [InlineData(133, false)]
    public async Task DeleteOccupation(int occupationId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/Occupation/{occupationId}");
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