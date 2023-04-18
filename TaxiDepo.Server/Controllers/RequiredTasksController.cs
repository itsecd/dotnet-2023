using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet("getCarDriver")]
    public IEnumerable<DriverDto> GetCarAndDriver()
    {
        _logger.LogInformation("Get driver and his car");
        var request = (from drive in _taxiRepository.Drivers
            where (drive.DriverSurname == "Antonov") 
            select _mapper.Map<DriverDto>(drive));
        return request;
    }
    /// <summary>
    /// Task 2 - Print info about user who driven in date range sort by surname
    /// </summary>
    /// <returns>User object</returns>
    [HttpGet("getUserByDate")]
    public IEnumerable<UserDto> GetUserByDate(DateTime dateBefore, DateTime dateAfter)
    {
        _logger.LogInformation("Get driver and his car");
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
    [HttpGet("userRidesAmount")]
    public IEnumerable<UserDto> GetUserRides()
    {
        _logger.LogInformation("Get driver and his car");
        var user = (from obj in _taxiRepository.Rides
            where (obj.UserInfo == new User(1, "Kotov", "Stanislav", "Pavlovich", "89290334434"))
            select _mapper.Map<UserDto>(obj.UserInfo));
        return user;
    }
    /// <summary>
    /// Task 4 - Print top five drivers with max amount rides
    /// </summary>
    /// <returns>Drivers object</returns>
    [HttpGet("topDriversRides")]
    public IEnumerable<DriverDto> GetTopFiveDriversByRides()
    {
        _logger.LogInformation("Get driver and his car");
        var driver = (from obj in _taxiRepository.Rides
            where (obj.TripCar != null)
            select _mapper.Map<DriverDto>(obj.TripCar.AssignedDriver)).Take(5);
        return driver;
    }

    /// <summary>
    /// Task 5 - Print info about min trip time
    /// </summary>
    /// <returns>String</returns>
    [HttpGet("minDriversTripTime")]
    public IEnumerable<string> GetMinTime()
    {
        _logger.LogInformation("Get driver and his car");

        var time = (from obj in _taxiRepository.Rides
            where (obj.TripCar == new Car(0, "A279TT163", "BMW E34", "Purple"))
            select obj.TripTime).ToList();
        var minTime = time.Min();

        var request = new List<string>() { $"max: {minTime}"};
        return request;
    }
    /// <summary>
    /// Task 6 - Print info about users, who made max amount of rides
    /// </summary>
    /// <returns>User object</returns>
    [HttpGet("usersWithAmountRidesByDateRange")]
    public IEnumerable<UserDto> GetUserByDateRange(DateTime date)
    {
        _logger.LogInformation("Get driver and his car");
        var user = (from obj in _taxiRepository.Rides
            where (obj.TripDate < date)
            orderby obj.UserInfo.UserRides.Count descending 
            select _mapper.Map<UserDto>(obj.UserInfo)).Take(1);
        return user;
    }
}