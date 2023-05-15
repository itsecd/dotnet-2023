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
    public Task<ICollection<CompanyGetDto>> GetCompaniesAsync()
    {
        return _client.CompanyAllAsync();
    }
    public Task<CompanyGetDto> AddCompanyAsync(CompanyPostDto company)
    {
        return (Task<CompanyGetDto>)_client.CompanyAsync(company);
    }
    public Task UpdateCompanyAsync(int id, CompanyPostDto company)
    {
        return _client.Company3Async(id, company);
    }
    public Task DeleteCompanyAsync(int id)
    {
        return _client.Company4Async(id);
    }

    public Task<ICollection<CompanyApplicationGetDto>> GetCompanyApplicationsAsync()
    {
        return _client.CompanyApplicationAllAsync();
    }
    public Task<CompanyApplicationGetDto> AddCompanyApplicationAsync(CompanyApplicationPostDto companyApplication)
    {
        return (Task<CompanyApplicationGetDto>)_client.CompanyApplicationAsync(companyApplication);
    }
    public Task UpdateCompanyApplicationAsync(int id, CompanyApplicationPostDto companyApplication)
    {
        return _client.CompanyApplication3Async(id, companyApplication);
    }
    public Task DeleteCompanyApplicationAsync(int id)
    {
        return _client.CompanyApplication4Async(id);
    }

    public Task<ICollection<EmployeeGetDto>> GetEmployeesAsync()
    {
        return _client.EmployeeAllAsync();
    }
    public Task<EmployeeGetDto> AddEmployeeAsync(EmployeePostDto employee)
    {
        return (Task<EmployeeGetDto>)_client.EmployeeAsync(employee);
    }
    public Task UpdateEmployeeAsync(int id, EmployeePostDto employee)
    {
        return _client.Employee3Async(id, employee);
    }
    public Task DeleteEmployeeAsync(int id)
    {
        return _client.Employee4Async(id);
    }

    public Task<ICollection<JobApplicationGetDto>> GetJobApplicationsAsync()
    {
        return _client.JobApplicationAllAsync();
    }
    public Task<JobApplicationGetDto> AddEmployeeAsync(JobApplicationPostDto jobApplication)
    {
        return (Task<JobApplicationGetDto>)_client.JobApplicationAsync(jobApplication);
    }
    public Task UpdateJobApplicationAsync(int id, JobApplicationPostDto jobApplication)
    {
        return _client.JobApplication3Async(id, jobApplication);
    }
    public Task DeleteJobApplicationAsync(int id)
    {
        return _client.JobApplication4Async(id);
    }

    public Task<ICollection<TitleGetDto>> GetTitlesAsync()
    {
        return _client.TitleAllAsync();
    }
    public Task<TitleGetDto> AddTitleAsync(TitlePostDto title)
    {
        return (Task<TitleGetDto>)_client.TitleAsync(title);
    }
    public Task UpdateTitleAsync(int id, TitlePostDto title)
    {
        return _client.Title3Async(id, title);
    }
    public Task DeleteTitleAsync(int id)
    {
        return _client.Title4Async(id);
    }
}
