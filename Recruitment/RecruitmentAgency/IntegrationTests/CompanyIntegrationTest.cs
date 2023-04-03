using ApplicationsServer.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace MyServer.Tests;
/// <summary>
/// Integration test for CompanyController
/// </summary>
public class CompanyIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public CompanyIntegrationTests(WebApplicationFactory<Program> factory)
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
        var companies = JsonConvert.DeserializeObject<List<CompanyGetDTO>>(content);
        Assert.Equal(4, companies?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();

        var newCompany = new CompanyPostDTO()
        {
            CompanyName = "Test",
            Telephone = "000",
            ContactName = "SergeyPirat"
        };

        var requestContent = JsonConvert.SerializeObject(newCompany);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/Company", postData);

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

        var newCompany = new CompanyPostDTO()
        {
            CompanyName = "Test",
            Telephone = "000",
            ContactName = "SergeyPirat"
        };

        var requestContent = JsonConvert.SerializeObject(newCompany);
        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/Company/1", putData);

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

        var response = await client.DeleteAsync("/api/Company/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetCompanyByIdReturnsSeuccess()
    {
        var client = _factory.CreateClient();
        var expectedCompany = new CompanyGetDTO {
            Id = 1, 
            CompanyName = "Acme Inc.", 
            Telephone = "555-1234", 
            ContactName = "John Doe" 
        };

        var response = await client.GetAsync("api/Company/1");
        var content = await response.Content.ReadAsStringAsync();
        var companyReturned = JsonConvert.DeserializeObject<CompanyGetDTO>(content);
        Assert.NotEqual(expectedCompany, companyReturned);
    }
}
