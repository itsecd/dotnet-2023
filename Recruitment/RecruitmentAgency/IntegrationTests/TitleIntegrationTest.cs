﻿using ApplicationsServer.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;
using ApplicationRecruitmentAgency;

namespace IntegrationTests;
/// <summary>
/// Integration test for TitleController
/// </summary>
public class TitleIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    public TitleIntegrationTests(WebApplicationFactory<Server> factory)
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
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var titles = JsonSerializer.Deserialize <List<TitleGetDto>> (content, options);
        Assert.Equal(1, titles?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

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
    public async Task GetTitleByIdReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var expectedTitle = new TitleGetDto()
        {
            Section = "IT",
            JobTitle = "Test",
            Id = 0
        };
        var response = await client.GetAsync("api/Title/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var titleReturned = JsonSerializer.Deserialize<TitleGetDto>(content, options);
        Assert.NotEqual(expectedTitle, titleReturned);
    }
}
