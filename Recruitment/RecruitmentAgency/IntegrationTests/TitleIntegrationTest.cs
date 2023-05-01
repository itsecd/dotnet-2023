using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for TitleController
/// </summary>
public class TitleIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly HttpClient _client;
    public TitleIntegrationTests(WebApplicationFactory<Server> factory)
    {
        _client = factory.CreateClient();
    }
    /// <summary>
    /// Test of the get method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetValuesReturnsSuccess()
    {
        var response = await _client.GetAsync("api/Title");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var newTitle = new TitleGetDto()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newTitle, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/Title", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {
        var newTitle = new TitlePostDto()
        {
            JobTitle = "TestMethod",
            Section = "RequestsTests"
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newTitle, options);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("api/Title/15", putData);

        Assert.False(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var response = await _client.DeleteAsync("api/Title/15");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTitleByIdReturnsSuccess()
    {
        var expectedTitle = new TitleGetDto()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };
        var response = await _client.GetAsync("api/Title/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var titleReturned = JsonSerializer.Deserialize<TitleGetDto>(content, options);
        Assert.NotEqual(expectedTitle, titleReturned);
    }
}
