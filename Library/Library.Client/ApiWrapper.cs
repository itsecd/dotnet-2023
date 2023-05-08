using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Client;
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

    public Task<ICollection<BookGetDto>> GetBooksAsync()
    {
        return _client.BookAllAsync();
    }

    public Task<BookGetDto> AddBookAsync(BookPostDto book)
    {
        return _client.BookAsync(book);
    }

    public Task UpdateBookAsync(int id, BookPostDto book)
    {
        return _client.Book3Async(id, book);
    }

    public Task DeleteBookAsync(int id)
    {
        return _client.Book4Async(id);
    }
}