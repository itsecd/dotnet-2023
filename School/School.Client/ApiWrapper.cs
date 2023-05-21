using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.Client;
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
    public Task<ICollection<ClassGetDto>> GetClassesAsync()

    {
        return _client.ClassAllAsync();
    }

    public Task<ClassGetDto> PostClassAsync(ClassPostDto @class)

    {
        return _client.ClassAsync(@class);
    }
   
    public Task UpdateClassAsync(int id, ClassPostDto @class)

    {
        return _client.Class3Async(id,@class);
    }

    public Task DeleteClassAsync(int id)

    {
        return _client.Class4Async(id);
    }
}
