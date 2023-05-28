using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UniversityData.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var server = configuration.GetSection("ServerURL").Value;

        _client = new ApiClient(server, new HttpClient());
    }

    public Task<ICollection<ConstructionPropertyGetDto>> GetConstructionPropertyAsync()
    {
        return _client.ConstructionPropertyAllAsync();
    }

    public Task<ConstructionPropertyGetDto> AddConstructionPropertyAsync(ConstructionPropertyPostDto constructionProperty)
    {
        return _client.ConstructionPropertyAsync(constructionProperty);
    }

    public Task<ConstructionPropertyPostDto> UpdateConstructionPropertyAsync(int id, ConstructionPropertyPostDto constructionProperty)
    {
        return _client.ConstructionProperty3Async(id, constructionProperty);
    }

    public Task<ConstructionPropertyGetDto> DeleteConstructionPropertyAsync(int id)
    {
        return _client.ConstructionProperty4Async(id);
    }
}
