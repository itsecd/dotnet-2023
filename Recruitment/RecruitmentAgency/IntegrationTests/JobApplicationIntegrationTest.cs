﻿using ApplicationsServer.Dto;
using ApplicationRecruitmentAgency;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace IntegrationTests;
/// <summary>
/// Integration test for JobApplicationController
/// </summary>
public class JobApplicationIntegrationTests : IClassFixture<WebApplicationFactory<Server>>
{
    private readonly WebApplicationFactory<Server> _factory;
    public JobApplicationIntegrationTests(WebApplicationFactory<Server> factory)
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

        var response = await client.GetAsync("api/JobApplication");

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var jobApplciations = JsonSerializer.Deserialize<List<JobApplicationGetDto>>(content, options);
        Assert.Equal(3, jobApplciations?.Count);
    }
    /// <summary>
    /// Test of the post method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task PostValuesReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var newEmployee = new EmployeePostDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var newApplication = new JobApplicationGetDto()
        {
            Employee = newEmployee,
            Title = "Backend",
            Id = 0
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newApplication, options);
        var postData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/JobApplication", postData);

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
        var newEmployee = new EmployeePostDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var newApplication = new JobApplicationGetDto()
        {
            Employee = newEmployee,
            Title = "Backend",
            Id = 0
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        var requestContent = JsonSerializer.Serialize(newApplication, options);

        var putData = new StringContent(requestContent, Encoding.UTF8, "application/json");
        var response = await client.PutAsync("/api/JobApplication/0", putData);

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

        var response = await client.DeleteAsync("/api/JobApplication/1");

        Assert.True(response.IsSuccessStatusCode);
    }
    /// <summary>
    /// Test of the get by id method
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetJobApplicationByIdReturnsSuccess()
    {
        var client = _factory.CreateClient();
        var newEmployee = new EmployeePostDto()
        {
            PersonalName = "Sergey Pirat",
            Telephone = "000",
            WorkExperience = 2,
            Education = "Full",
            Salary = 123000,
            Id = 0
        };
        var expectedApplication = new JobApplicationGetDto()
        {
            Employee = newEmployee,
            Date = DateTime.Now,
            Title = "Backend",
            Id = 0
        };

        var response = await client.GetAsync("api/JobApplication/0");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var applicationReturned = JsonSerializer.Deserialize<JobApplicationGetDto>(content, options);
        Assert.Equal(expectedApplication.Id, applicationReturned?.Id);
    }
}
