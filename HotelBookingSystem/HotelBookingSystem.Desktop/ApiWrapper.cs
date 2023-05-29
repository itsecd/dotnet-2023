using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using HotelBookingSystem.Server.Dto;

namespace HotelBookingSystem.Desktop;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var url = configuration.GetSection("ServerUrl").Value;
        //var url = configuration.GetConnectionString("ServerUrl");
        _client = new ApiClient(url, new HttpClient());
    }

    public Task<ICollection<HotelGetDto>> GetHotelsAsync()
    {
        return _client.HotelAllAsync();
    }

    public Task<HotelGetDto> PostHotelsAsync(HotelPostDto hotel)
    {
        return _client.HotelAsync(hotel);
    }

    public Task PutHotelsAsync(int id, HotelPostDto hotel)
    {
        return _client.Hotel3Async(id, hotel);
    }
    public Task DeleteHotelsAsync(int id)
    {
        return _client.Hotel4Async(id);
    }
}
