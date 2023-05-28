using Microsoft.AspNetCore.Mvc.Testing;
using RecruitmentAgencyServer;
using RecruitmentAgencyServer.Dto;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for CompanyController
/// </summary>
[Collection("Tests")]
public class CompanyIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly HttpClient _client;
    public CompanyIntegrationTests(WebApplicationFactory<Server> factory)
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
        var response = await _client.GetAsync("api/Company");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {

        var newCompany = new CompanyPostDto()
        {
            CompanyName = "Test",
            Telephone = "000",
            ContactName = "SergeyPirat"
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newCompany, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/Company", postData);

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the put method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PutValuesReturnsSuccess()
    {

        var newCompany = new CompanyPostDto()
        {
            CompanyName = "Test",
            Telephone = "000",
            ContactName = "SergeyPirat"
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newCompany, options);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("api/Company/0", putData);

        Assert.False(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the delete method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task DeleteValuesReturnsSuccess()
    {

        var response = await _client.DeleteAsync("api/Company/25");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCompanyByIdReturnsSuccess()
    {
        var response = await _client.GetAsync("api/Company/1111");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
