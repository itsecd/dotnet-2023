using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Client;
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

    public Task<ICollection<EnterpriseGetDto>> GetEnterpriseAsync()
    {
        return _client.EnterpriseAllAsync();
    }

    public Task AddEnterpriseAsync(EnterprisePostDto enterprise)
    {
        return _client.EnterpriseAsync(enterprise);
    }

    public Task UpdateEnterpriseAsync(int id, EnterprisePostDto enterprise)
    {
        return _client.Enterprise3Async(id, enterprise);
    }

    public Task DeleteEnterpriseAsync(int id)
    {
        return _client.Enterprise4Async(id);
    }
}
