using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TransportManagment.Classes;
using TransportManagment.Server.Dto;
using TransportManagment.Server.Repository;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Controller of requests
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;
    private readonly ITransportManagmentRepository _requestsRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="requestsRepository"></param>
    /// <param name="mapper"></param>
    public RequestsController(ILogger<RequestsController> logger, ITransportManagmentRepository requestsRepository, IMapper mapper)
    {
        _logger = logger;
        _requestsRepository = requestsRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Task 1 - Output all information about a specific vehicle.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetAllTransportInfo")]
    public IEnumerable<TransportGetDto> GetAllTransportInfo(int id)
    {
        var result = (from transport in _requestsRepository.Transports
                      where transport.TransportId == id
                      select transport);
        return _mapper.Map<IEnumerable<TransportGetDto>>(result);
    }
    /// <summary>
    /// Task 2 - Output all drivers who have made trips for a given period, sort by full name.
    /// </summary>
    /// <param name="firstDateTime"></param>
    /// <param name="secondDateTime"></param>
    /// <returns></returns>
    [HttpGet("GetAllDriversWithSpecificDate")]
    public IEnumerable<DriverGetDto> GetAllDriversWithSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        var result = (from driver in _requestsRepository.Drivers
                      join route in _requestsRepository.Routes on driver.DriverId equals route.Driver.DriverId
                      orderby driver.LastName
                      where route.Date < secondDateTime && route.Date > firstDateTime
                      select driver).ToList();
        return _mapper.Map<IEnumerable<DriverGetDto>>(result);
    }
    /// <summary>
    /// Task 3 - Output the total travel time of the vehicle of each type and model.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTotalTimeTravelEveryTypeAndModel")]
    public IEnumerable<TransportTimeModelDto> GetTotalTimeTravelEveryTypeAndModel()
    {
        var result = (from transport in _requestsRepository.Transports
                      join route in _requestsRepository.Routes on transport.TransportId equals route.Transport.TransportId
                      group route by new { transport.Model, transport.Type } into res
                      orderby res.Sum(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary()) descending
                      select new TransportTimeModelDto
                      {
                          TransportId = res.First().Transport.TransportId,
                          Type = res.First().Transport.Type,
                          Model = res.First().Transport.Model,
                          Time = res.Sum(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary())
                      }
                      ).ToList();
        return _mapper.Map<IEnumerable<TransportTimeModelDto>>(result);
    }
    /// <summary>
    /// Task 4 - Output the top 5 drivers by the number of trips made.
    /// </summary>
    /// <returns></returns>
    [HttpGet("TopFiveDrivers")]
    public IEnumerable<DriverGetDto> TopFiveDrivers()
    {
        var result = (from driver in _requestsRepository.Drivers
                      join route in _requestsRepository.Routes on driver.DriverId equals route.Driver.DriverId
                      group route by driver.DriverId into res
                      orderby res.Count() descending
                      select res.First().Driver).Take(5);
        return _mapper.Map<IEnumerable<DriverGetDto>>(result);
    }
    /// <summary>
    /// Task 5 - Display information about the number of trips, average time and maximum travel time for each driver.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravel")]
    public IEnumerable<DriverPropertiesRouteDto> GetInfoAboutCountTravelAvgTimeTranvelMaxTimeTravel()
    {
        var result = (from driver in _requestsRepository.Drivers
                      join route in _requestsRepository.Routes on driver.DriverId equals route.Driver.DriverId
                      group route by driver.DriverId into res
                      select new DriverPropertiesRouteDto
                      {
                          DriverId = res.First().DriverId,
                          SumTime = res.Sum(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary()),
                          AvgTime = res.Average(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary()),
                          MaxTime = res.Max(route => route.TimeFrom.ToBinary() - route.TimeTo.ToBinary())
                      });
        return _mapper.Map<IEnumerable<DriverPropertiesRouteDto>>(result);
    }
    /// <summary>
    /// Task 6 - Display information about vehicles that have made the maximum number of trips during the specified period.
    /// </summary>
    /// <param name="firstDateTime"></param>
    /// <param name="secondDateTime"></param>
    /// <returns></returns>
    [HttpGet("GetTransportInfoWithMaxCountForSpecificDate")]
    public IEnumerable<TransportGetDto> GetTransportInfoWithMaxCountForSpecificDate(DateTime firstDateTime, DateTime secondDateTime)
    {
        var result = (from transport in _requestsRepository.Transports
                      join route in _requestsRepository.Routes on transport.TransportId equals route.Transport.TransportId
                      group route by route.Transport.TransportId into res
                      orderby res.Count()
                      where res.First().Date < secondDateTime && res.First().Date > firstDateTime && res.Count() == 2
                      select res.First().Transport);
        return _mapper.Map<IEnumerable<TransportGetDto>>(result);
    }
}