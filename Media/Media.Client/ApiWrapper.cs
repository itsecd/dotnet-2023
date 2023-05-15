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

    public async Task<ICollection<AlbumGetDto>> GetAlbumsAsync()
    {
        return await _client.AlbumAllAsync();
    }

    public async Task AddAlbumAsync(AlbumPostDto album)
    {
        await _client.AlbumAsync(album);
    }

    public async Task UpdateAlbumAsync(int id, AlbumPostDto album)
    {
        await _client.Album3Async(id, album);
    }

    public async Task DeleteAlbumAsync(int id)
    {
        await _client.Album4Async(id);
    }

    public async Task<ICollection<Genre>> GetGenresAsync()
    {
        return await _client.GenreAllAsync();
    }

    public async Task AddGenreAsync(GenrePostDto genre)
    {
        await _client.GenreAsync(genre);
    }

    public async Task UpdateGenreAsync(int id, GenrePostDto genre)
    {
        await _client.Genre3Async(id, genre);
    }

    public async Task DeleteGenreAsync(int id)
    {
        await _client.Genre4Async(id);
    }

    public async Task<ICollection<AlbumGetDto>> GetTopAlbumsAsync()
    {
        return await _client.Top5AlbumsAsync();
    }
}
