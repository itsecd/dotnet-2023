using Microsoft.AspNetCore.Mvc.Testing;
using OrganizationServer.Dto;
using System.Text;
using System.Text.Json;
namespace EmployeeDomainIntegrationTests;
/// <summary>
/// WorkshopIntegrationTest  - represents a integration test of WorkshopController
/// </summary>
[Collection("Sequential")]
public class WorkshopIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the WorkshopIntegrationTest
    /// </summary>
    public WorkshopIntegrationTest(WebApplicationFactory<Program> factory)
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
    public async Task GetWorkshops()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Workshop");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var workshops = JsonSerializer.Deserialize<List<GetWorkshopDto>>(content, _serializeOptions);
        Assert.NotNull(workshops);
        Assert.True(workshops.Count >= 4);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="workshopId">ID of the workshop</param>
    /// <param name="workshopName">Correct name of the workshop</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, "Ленинский цех", true)]
    [InlineData(2, "Производственный цех", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetWorkshop(uint workshopId, string workshopName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/Workshop/{workshopId}");

        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var workshop = JsonSerializer.Deserialize<GetWorkshopDto>(content, _serializeOptions);
            Assert.NotNull(workshop);
            Assert.Equal(workshopName, workshop.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="workshopName">The name of the workshop</param>
    [Theory]
    [InlineData("Самарский цех")]
    [InlineData("Московский цех")]
    public async Task PostWorkshop(string workshopName)
    {
        var workshopDto = new PostWorkshopDto()
        {
            Name = workshopName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(workshopDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Workshop", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Tests the PUT method
    /// </summary>
    /// <param name="workshopId">ID of the existing workshop</param>
    /// <param name="workshopName">The new name of the workshop</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(4, "Екатеринбургский цех", true)]
    [InlineData(155, "Московский цех", false)]
    public async Task PutWorkshop(uint workshopId, string workshopName, bool isSuccess)
    {
        var departmentDto = new PostWorkshopDto()
        {
            Name = workshopName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(departmentDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"api/Workshop/{workshopId}", stringContent);
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
    /// <param name="workshopId">ID of the existing workshop</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(5, true)]
    [InlineData(133, false)]
    public async Task DeleteWorkshop(int workshopId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/Workshop/{workshopId}");
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