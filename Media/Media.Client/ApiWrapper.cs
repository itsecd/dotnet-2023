using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Media.Client;
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

    public async Task<ICollection<ArtistGetDto>> GetArtistsAsync()
    {
        return await _client.ArtistAllAsync();
    }

    public async Task AddArtistAsync(ArtistPostDto artist)
    {
        await _client.ArtistAsync(artist);
    }

    public async Task UpdateArtistAsync(int id, ArtistPostDto artist)
    {
        await _client.Artist3Async(id, artist);
    }

    public async Task DeleteArtistAsync(int id)
    {
        await _client.Artist4Async(id);
    }
}
