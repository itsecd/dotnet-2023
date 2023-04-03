using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace MyServer.Tests;
/// <summary>
/// Integration test for TitleController
/// </summary>
public class TitleIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public TitleIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    /// <summary>
    /// Test of the get method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Title");

        var content = await response.Content.ReadAsStringAsync();
        var titles = JsonConvert.DeserializeObject<List<TitleGetDTO>>(content);
        Assert.Equal(3, titles?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newTitle = new TitleGetDTO()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };

        var requestContent = JsonConvert.SerializeObject(newTitle);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/Title", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newTitle = new TitleGetDTO()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };
        var requestContent = JsonConvert.SerializeObject(newTitle);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/Title/0", putData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync("/api/Title/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetTitleByIdReturnsSeuccess()
    {
        var client = _factory.CreateClient();
        var expectedTitle = new TitleGetDTO()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };
        var response = await client.GetAsync("api/Title/0");
        var content = await response.Content.ReadAsStringAsync();
        var titleReturned = JsonConvert.DeserializeObject<TitleGetDTO>(content);
        Assert.NotEqual(expectedTitle, titleReturned);
    }
}
