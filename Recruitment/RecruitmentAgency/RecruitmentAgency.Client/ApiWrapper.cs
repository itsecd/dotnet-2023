using Microsoft.Extensions.Configuration;
using RecruitmentAgencyServer.Dto;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecruitmentAgency.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;
    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
            
        _client = new ApiClient(serverUrl, new HttpClient());
    }
    public async Task<ICollection<CompanyGetDto>> GetCompaniesAsync()
    {
        return await _client.CompanyAllAsync();
    }
    public async Task<CompanyGetDto> AddCompanyAsync(CompanyPostDto company)
    {
        return await _client.CompanyPOSTAsync(company);
    }
    public async Task UpdateCompanyAsync(int id, CompanyPostDto company)
    {
        await _client.CompanyPUTAsync(id, company);
    }
    public async Task DeleteCompanyAsync(int id)
    {
        await _client.CompanyDELETEAsync(id);
    }

    public async Task<ICollection<CompanyApplicationGetDto>> GetCompanyApplicationsAsync()
    {
        return await _client.CompanyApplicationAllAsync();
    }
    public async Task<CompanyApplicationGetDto> AddCompanyApplicationAsync(CompanyApplicationPostDto companyApplication)
    {
        return await _client.CompanyApplicationPOSTAsync(companyApplication);
    }
    public async Task UpdateCompanyApplicationAsync(int id, CompanyApplicationPostDto companyApplication)
    {
        await _client.CompanyApplicationPUTAsync(id, companyApplication);
    }
    public async Task DeleteCompanyApplicationAsync(int id)
    {
        await _client.CompanyApplicationDELETEAsync(id);
    }

    public async Task<ICollection<EmployeeGetDto>> GetEmployeesAsync()
    {
        return await _client.EmployeeAllAsync();
    }
    public async Task<EmployeeGetDto> AddEmployeeAsync(EmployeePostDto employee)
    {
        return await (Task<EmployeeGetDto>)_client.EmployeePOSTAsync(employee);
    }
    public async Task UpdateEmployeeAsync(int id, EmployeePostDto employee)
    {
        await _client.EmployeePUTAsync(id, employee);
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        await _client.EmployeeDELETEAsync(id);
    }

    public async Task<ICollection<JobApplicationGetDto>> GetJobApplicationsAsync()
    {
        return await _client.JobApplicationAllAsync();
    }
    public async Task<JobApplicationGetDto> AddJobApplicationAsync(JobApplicationPostDto jobApplication)
    {
        return await (Task<JobApplicationGetDto>)_client.JobApplicationPOSTAsync(jobApplication);
    }
    public async Task UpdateJobApplicationAsync(int id, JobApplicationPostDto jobApplication)
    {
        await _client.JobApplicationPUTAsync(id, jobApplication);
    }
    public async Task DeleteJobApplicationAsync(int id)
    {
        await _client.JobApplicationDELETEAsync(id);
    }

    public async Task<ICollection<TitleGetDto>> GetTitlesAsync()
    {
        return await _client.TitleAllAsync();
    }
    public async Task<TitleGetDto> AddTitleAsync(TitlePostDto title)
    {
        return await (Task<TitleGetDto>)_client.TitlePOSTAsync(title);
    }
    public async Task UpdateTitleAsync(int id, TitlePostDto title)
    {
        await _client.TitlePUTAsync(id, title);
    }
    public async Task DeleteTitleAsync(int id)
    {
        await _client.TitleDELETEAsync(id);
    }
}
