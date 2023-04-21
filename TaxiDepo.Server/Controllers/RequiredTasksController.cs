using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;
using TaxiDepo.Server.Repositories;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// RequiredTasks controller class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequiredTasksController : ControllerBase
{
    /// <summary>
    /// RequiredTasks logger
    /// </summary>
    private readonly ILogger<RequiredTasksController> _logger;
    /// <summary>
    /// TaxiDepo repository
    /// </summary>
    private readonly ITaxiDepoRepository _taxiRepository;
    /// <summary>
    /// Mapper
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// RequiredTasksController class constructor with params
    /// </summary>
    /// <param name="logger">Car logger</param>
    /// <param name="taxiRepository">Taxi repository</param>
    /// <param name="mapper">Mapper</param>
    public RequiredTasksController(ILogger<RequiredTasksController> logger, ITaxiDepoRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Task 1 - Print info about driver, his car
    /// </summary>
    /// <returns>Driver object</returns>
    [HttpGet("GetCarDriver")]
    public IEnumerable<DriverDto> GetCarAndDriver(int driverId)
    {
        _logger.LogInformation("Get driver and his car");
        var request = (from drive in _taxiRepository.Drivers
            where (drive.Id == driverId) 
            select _mapper.Map<DriverDto>(drive));
        return request;
    }
    /// <summary>
    /// Task 2 - Print info about user who driven in date range sort by surname
    /// </summary>
    /// <returns>User object</returns>
    [HttpGet("GetUserByDate")]
    public IEnumerable<UserDto> GetUserByDate(DateTime dateBefore, DateTime dateAfter)
    {
        _logger.LogInformation("Get user by date");
        var user = (from obj in _taxiRepository.Rides
            where (obj.TripDate > dateBefore &&
                   obj.TripDate < dateAfter)
            orderby obj.UserInfo.UserSurname descending 
            select _mapper.Map<UserDto>(obj.UserInfo));
        return user;
    }
    /// <summary>
    /// Task 3 - Print user rides amount
    /// </summary>
    /// <returns>Users object</returns>
    [HttpGet("UserRidesAmount")]
    public IEnumerable<UserDto> GetUserRides()
    {
        _logger.LogInformation("Get user rides amount");
        var user = (from obj in _taxiRepository.Users
            select _mapper.Map<UserDto>(obj));
        return user;
    }
    /// <summary>
    /// Task 4 - Print top five drivers with max amount rides
    /// </summary>
    /// <returns>Drivers object</returns>
    [HttpGet("TopDriversRides")]
    public IEnumerable<DriverDto> GetTopFiveDriversByRides()
    {
        _logger.LogInformation("Get drivers ride");
        var driver = (from obj in _taxiRepository.Rides
            where (obj.TripCar != null)
            select _mapper.Map<DriverDto>(obj.TripCar.AssignedDriver)).Take(5);
        return driver;
    }
    /// <summary>
    /// Task 5 - Print info about max trip time
    /// </summary>
    /// <returns>String</returns>
    [HttpGet("MaxDriversTripTime")]
    public IEnumerable<string> GetMaxTime()
    {
        var cars = (from obj in _taxiRepository.Rides
            group obj by obj.TripCar).ToList();
        var maxTime = new List<TimeSpan>();
        var avg = new List<TimeSpan>();
        for (var i = 0; i < cars.Capacity; i++) {
            var tmp = new List<TimeSpan>();
            var singleRides = cars[i].Key.CarRides?.ToList();
            if (singleRides != null) {
                foreach (var t in singleRides) {
                    tmp.Add(t.TripTime);
                }
            }
            else 
                tmp.Add(new TimeSpan());
            maxTime.Add(tmp.Max());
            avg.Add(new TimeSpan(Convert.ToInt64(tmp.Average(timeSpan => timeSpan.Ticks))));
        }
        var request = new List<string>();
        for (var i = 0; i < _taxiRepository.Drivers.Count; i++)
        {
            request.Add($"driverId: {i}, max: {maxTime[i]}, average: {avg[i]}");
        }
        return _mapper.Map<IEnumerable<string>>(request);
    }
    /// <summary>
    /// Task 6 - Print info about users, with max amount of rides
    /// </summary>
    /// <returns>User object</returns>
    [HttpGet("UsersWithAmountRidesByDate")]
    public ActionResult<UserDto> GetUserByDateRange(DateTime dateBefore, DateTime dateAfter)
    {
        _logger.LogInformation("Get user and with max amount of rides");
        var user = (from obj in _taxiRepository.Rides
            where (obj.TripDate < dateAfter && obj.TripDate > dateBefore)
            orderby obj.UserInfo.AmountRides descending
            select obj.UserInfo).First();
        return _mapper.Map<UserDto>(user);
    }
}