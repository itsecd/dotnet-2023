using RecruitmentAgencyServer;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Text;
using RecruitmentAgencyServer.Dto;

namespace IntegrationTests;
/// <summary>
/// Integration test for CompanyController
/// </summary>
public class CompanyIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    public CompanyIntegrationTests(WebApplicationFactory<Server> factory)
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

        var response = await client.GetAsync("api/Company");

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var companies = JsonSerializer.Deserialize<List<CompanyGetDto>>(content, options);
        Assert.Equal(3, companies?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

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
        var response = await client.PostAsync("api/Company", postData);

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
        var response = await client.PutAsync("api/Company/0", putData);

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

        var response = await client.DeleteAsync("api/Company/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCompanyByIdReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var expectedCompany = new CompanyGetDto
        {
            Id = 1, 
            CompanyName = "Acme Inc.", 
            Telephone = "555-1234", 
            ContactName = "John Doe" 
        };

        var response = await client.GetAsync("api/Company/1");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var companyReturned = JsonSerializer.Deserialize<CompanyGetDto>(content, options);
        Assert.NotEqual(expectedCompany, companyReturned);
    }
}
