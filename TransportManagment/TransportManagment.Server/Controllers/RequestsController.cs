using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Controller of requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly TransportManagmentDbContext _context;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public RequestsController(TransportManagmentDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Task 1 - Output all information about a specific vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetAllTransportInfo")]
    public async Task<IEnumerable<TransportGetDto>> GetAllTransportInfoAsync(int id)
    {
        var result = from transport in _context.Transports
                     where transport.TransportId == id
                     select transport;
        return await _mapper.ProjectTo<TransportGetDto>(result).ToListAsync();
    }
    /// <summary>
    /// Task 2 - Output all drivers who have made trips for a given period, sort by full name.
    /// </summary>
    /// <param name="firstDateTime"></param>
    /// <param name="secondDateTime"></param>
    /// <returns></returns>
    [HttpGet("GetAllDriversWithSpecificDate")]
    public async Task<IEnumerable<DriverGetDto>> GetAllDriversWithSpecificDateAsync(DateTime firstDateTime, DateTime secondDateTime)
    {
        var result = from driver in _context.Drivers
                     orderby driver.LastName
                     where driver.Routes.First().Date < secondDateTime && driver.Routes.First().Date > firstDateTime
                     select driver;
        return await _mapper.ProjectTo<DriverGetDto>(result).ToListAsync();
    }
    /// <summary>
    /// Task 3 - Output the total travel time of the vehicle of each type and model.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTotalTimeTravelEveryTypeAndModel")]
    public async Task<IEnumerable<TransportTimeModelDto>> GetTotalTimeTravelEveryTypeAndModelAsync()
    {
        var result = from transport in _context.Transports
                     group transport by new { transport.Model, transport.Type } into res
                     select new TransportTimeModelDto
                     {
                         TransportId = res.First().TransportId,
                         Type = res.First().Type,
                         Model = res.First().Model,
                         Time = (from route in _context.Routes
                                 where route.TransportId == res.Single().TransportId
                                 select route.TimeFrom.TotalMinutes - route.TimeTo.TotalMinutes).ToImmutableList().Sum(),
                     };
        return await result.ToListAsync();
    }
    /// <summary>
    /// Task 4 - Output the top 5 drivers by the number of trips made.
    /// </summary>
    /// <returns></returns>
    [HttpGet("TopFiveDrivers")]
    public async Task<IEnumerable<TopDriversDto>> TopFiveDriversAsync()
    {
        var result = from driver in _context.Drivers
                     orderby driver.Routes.Count() descending
                     select new TopDriversDto 
                     {
                         FirstName = driver.FirstName,
                         LastName = driver.LastName,
                         Patronymic = driver.Patronymic,
                         Passport = driver.Passport,
                         DriverCard = driver.DriverCard,
                         Number = driver.Number,
                         Count = driver.Routes.Count(),
                     };
        return await result.Take(5).ToListAsync();
    }
    /// <summary>
    /// Task 5 - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravel")]
    public async Task<IEnumerable<DriverPropertiesRouteDto>> GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravelAsync()
    {
        var result = await (from driver in _context.Drivers
                            select new DriverPropertiesRouteDto
                            {
                                DriverId = driver.Routes.Single().DriverId,
                                SumTime = (from route in _context.Routes
                                           where route.DriverId == driver.DriverId
                                           select (route.TimeFrom.TotalMinutes - route.TimeTo.TotalMinutes)).ToImmutableList().Sum(),
                                AvgTime = (from route in _context.Routes
                                           where route.DriverId == driver.DriverId
                                           select (route.TimeFrom.TotalMinutes - route.TimeTo.TotalMinutes)).ToImmutableList().Average(),
                                MaxTime = (from route in _context.Routes
                                           where route.DriverId == driver.DriverId
                                           select (route.TimeFrom.TotalMinutes - route.TimeTo.TotalMinutes)).ToImmutableList().Max()
                            }).ToListAsync();
        return result;
    }
    /// <summary>
    /// Task 6 - Display information about vehicles that have made the maximum number of trips during the specified period.
    /// </summary>
    /// <param name="firstDateTime"></param>
    /// <param name="secondDateTime"></param>
    /// <returns></returns>
    [HttpGet("GetTransportInfoWithMaxCountForSpecificDate")]
    public async Task<IEnumerable<TransportInfoDto>> GetTransportInfoWithMaxCountForSpecificDateAsync(DateTime firstDateTime, DateTime secondDateTime)
    {
        var result = (from transport in _context.Transports
                      orderby transport.Routes.Count()
                      where transport.Routes.First().Date < secondDateTime && transport.Routes.First().Date > firstDateTime && transport.Routes.Count() == 2
                      select new TransportInfoDto 
                      {
                            Type = transport.Type,
                            Model = transport.Model,
                            DateMake = transport.DateMake,
                            Count = transport.Routes.Count()
                      });
        return await result.ToListAsync();
    }
}