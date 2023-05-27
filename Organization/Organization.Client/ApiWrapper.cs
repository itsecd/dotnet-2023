using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Organization.Client;
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

    public Task<ICollection<GetDepartmentDto>> GetDepartmentsAsync()
    {
        return _client.DepartmentAllAsync();
    }

    public Task<GetDepartmentDto> AddDepartmentAsync(PostDepartmentDto department)
    {
        return _client.DepartmentPOSTAsync(department);
    }

    public Task<GetDepartmentDto> UpdateDepartmentAsync(int id, PostDepartmentDto department)
    {
        return _client.DepartmentPUTAsync(id, department);
    }

    public Task<GetDepartmentDto> DeleteDepartmentAsync(int id)
    {
        return _client.DepartmentDELETEAsync(id);
    }
}
