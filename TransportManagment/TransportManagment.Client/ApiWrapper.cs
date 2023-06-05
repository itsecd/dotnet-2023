using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TransportManagment.Client;
public class ApiWrapper
{
    private readonly AppClient _client;
    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new AppClient(serverUrl, new HttpClient());
    }
    public Task<ICollection<DriverGetDto>> GetDriversAsync()
    {
        return _client.DriversAllAsync();
    }
    public Task<DriverGetDto> AddDriverAsync(DriverPostDto driver)
    {
        return _client.DriversAsync(driver);
    }
    public Task UpdateDriverAsync(int id, DriverPostDto driver)
    {
        return _client.Drivers3Async(id, driver);
    }
    public Task DeleteDriverAsync(int id) 
    {
        return _client.Drivers4Async(id);
    }
    public Task<ICollection<TransportGetDto>> GetTransportAsync()
    {
        return _client.TransportsAllAsync();
    }
    public Task<TransportGetDto> AddTransportAsync(TransportPostDto transport)
    {
        return _client.TransportsAsync(transport);
    }
    public Task UpdateTransportAsync(int id, TransportPostDto transport)
    {
        return _client.Transports3Async(id, transport);
    }
    public Task DeleteTransportAsync(int id)
    {
        return _client.Transports4Async(id);
    }
    public Task<ICollection<RouteGetDto>> GetRouteAsync()
    {
        return _client.RoutesAllAsync();
    }
    public Task<RouteGetDto> AddRouteAsync(RoutePostDto route)
    {
        return _client.RoutesAsync(route);
    }
    public Task UpdateRouteAsync(int id, RoutePostDto route)
    {
        return _client.Routes3Async(id, route);
    }
    public Task DeleteRouteAsync(int id)
    {
        return _client.Routes4Async(id);
    }
    public Task<ICollection<DriverPropertiesRouteDto>> GetDriverPropertiesAsync()
    {
        return _client.GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravelAsync();
    }
    public Task<ICollection<TopDriversDto>> GetTopDriversAsync()
    {
        return _client.TopFiveDriversAsync();
    }
    public Task<ICollection<TransportInfoDto>> GetTransportsInfoAsync(DateTimeOffset firstDate, DateTimeOffset secondDate)
    {
        return _client.GetTransportInfoWithMaxCountForSpecificDateAsync(firstDate, secondDate);
    }
    public Task<ICollection<TransportTimeModelDto>> GetTransportsTimeModelAsync()
    {
        return _client.GetTotalTimeTravelEveryTypeAndModelAsync();
    }
    public Task<ICollection<TransportGetDto>> GetTransportWithId(int id)
    {
        return _client.GetAllTransportInfoAsync(id);
    }
    public Task<ICollection<DriverGetDto>> GetDriversWithDate(DateTimeOffset firstDate, DateTimeOffset secondDate)
    {
        return _client.GetAllDriversWithSpecificDateAsync(firstDate, secondDate);
    }
}
