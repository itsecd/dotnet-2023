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

    public async Task<ICollection<BookGetDto>> GetBooksAsync()
    {
        return await _client.BookAllAsync();
    }

    public async Task<BookGetDto> AddBookAsync(BookPostDto book)
    {
        return await _client.BookAsync(book);
    }

    public async Task UpdateBookAsync(int id, BookPostDto book)
    {
        await _client.Book3Async(id, book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _client.Book4Async(id);
    }

    public async Task<ICollection<CardGetDto>> GetCardsAsync()
    {
        return await _client.CardAllAsync();
    }

    public async Task<CardGetDto> AddCardAsync(CardPostDto card)
    {
        return await _client.CardAsync(card);
    }

    public async Task UpdateCardAsync(int id, CardPostDto card)
    {
        await _client.Card3Async(id, card);
    }

    public async Task DeleteCardAsync(int id)
    {
        await _client.Card4Async(id);
    }

    public async Task<ICollection<DepartmentGetDto>> GetDepartmentsAsync()
    {
        return await _client.DepartmentAllAsync();
    }

    public async Task<DepartmentGetDto> AddDepartmentAsync(DepartmentPostDto department)
    {
        return await _client.DepartmentAsync(department);
    }

    public async Task UpdateDepartmentAsync(int id, DepartmentPostDto department)
    {
        await _client.Department3Async(id, department);
    }

    public async Task DeleteDepartmentAsync(int id)
    {
        await _client.Department4Async(id);
    }

    public async Task<ICollection<ReaderGetDto>> GetReadersAsync()
    {
        return await _client.ReaderAllAsync();
    }

    public async Task<ReaderGetDto> AddReaderAsync(ReaderPostDto reader)
    {
        return await _client.ReaderAsync(reader);
    }

    public async Task UpdateReaderAsync(int id, ReaderPostDto reader)
    {
        await _client.Reader3Async(id, reader);
    }

    public async Task DeleteReaderAsync(int id)
    {
        await _client.Reader4Async(id);
    }

    public async Task<ICollection<TypeEditionGetDto>> GetTypeEditionsAsync()
    {
        return await _client.TypeEditionAllAsync();
    }

    public async Task<ICollection<TypeDepartmentGetDto>> GetTypeDepartmentsAsync()
    {
        return await _client.TypeDepartmentAllAsync();
    }

    public async Task<ICollection<BookGetDto>> GetAllBooksAsync()
    {
        return await _client.AllBooksAsync();
    }
}