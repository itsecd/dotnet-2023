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
        return _client.HotelPOSTAsync(hotel);
    }

    public Task PutHotelsAsync(int id, HotelPostDto hotel)
    {
        return _client.HotelPUTAsync(id, hotel);
    }
    public Task DeleteHotelsAsync(int id)
    {
        return _client.HotelDELETEAsync(id);
    }


    public Task<ICollection<RoomGetDto>> GetRoomsAsync()
    {
        return _client.RoomAllAsync();
    }

    public Task<RoomGetDto> PostRoomsAsync(RoomPostDto room)
    {
        return _client.RoomPOSTAsync(room);
    }

    public Task PutRoomsAsync(int id, RoomPostDto room)
    {
        return _client.RoomPUTAsync(id, room);
    }
    public Task DeleteRoomsAsync(int id)
    {
        return _client.RoomDELETEAsync(id);
    }


    public Task<ICollection<LodgerGetDto>> GetLodgersAsync()
    {
        return _client.LodgerAllAsync();
    }

    public Task<LodgerGetDto> PostLodgersAsync(LodgerPostDto room)
    {
        return _client.LodgerPOSTAsync(room);
    }

    public Task PutLodgersAsync(int id, LodgerPostDto room)
    {
        return _client.LodgerPUTAsync(id, room);
    }
    public Task DeleteLodgersAsync(int id)
    {
        return _client.LodgerDELETEAsync(id);
    }


    public Task<ICollection<BookedRoomsGetDto>> GetBroomsAsync()
    {
        return _client.BookedRoomsAllAsync();
    }

    public Task<BookedRoomsGetDto> PostBroomsAsync(BookedRoomsPostDto broom)
    {
        return _client.BookedRoomsPOSTAsync(broom);
    }

    public Task PutBroomsAsync(int id, BookedRoomsPostDto room)
    {
        return _client.BookedRoomsPUTAsync(id, room);
    }
    public Task DeleteBroomsAsync(int id)
    {
        return _client.BookedRoomsDELETEAsync(id);
    }

    public Task<ICollection<HotelGetDto>> InfoHotelsAsync()
    {
        return _client.InfoHotelsAsync();
    }

    public Task<ICollection<LodgerGetDto>> InfoClientsInHotelsAsync(string name)
    {
        return _client.InfoClientsInHotelsAsync(name);
    }

    public Task<ICollection<HotelGetDto>> Top5MostBookedAsync()
    {
        return _client.Top5MostBookedAsync();
    }

    public Task<ICollection<RoomGetDto>> AvailableRoomsAsync(string city)
    {
        return _client.AvailableRoomsAsync(city);
    }

    public Task<ICollection<LodgerGetDto>> ClientsWithMostDaysAsync()
    {
        return _client.ClientsWithMostDaysAsync();
    }
}
