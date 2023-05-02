using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// RequiredController class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequiredController : ControllerBase
{
    /// <summary>
    /// Logger for RequiredController class
    /// </summary>
    private readonly ILogger<RequiredController> _logger;

    /// <summary>
    /// TaxiDepoDbContext class object
    /// </summary>
    private readonly TaxiDepoDbContext _context;

    /// <summary>
    /// Mapper for RequiredController class
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor with params of RequiredController class
    /// </summary>
    /// <param name="context">TaxiDepoDbContext class object</param>
    /// <param name="mapper">IMapper object</param>
    /// <param name="logger">ILogger object</param>
    public RequiredController(TaxiDepoDbContext context, IMapper mapper, ILogger<RequiredController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Task 1 - Print info about driver, his car
    /// </summary>
    /// <returns>CarDto object</returns>
    [HttpGet("GetCarAndDriver")]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetCarAndDriver(int id)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a car");
            return NotFound();
        }

        _logger.LogInformation("Get car and driver");
        var request = (from cars in _context.Cars where (cars.Id == id) select cars).Include(car => car.AssignedDriver);

        return await _mapper.ProjectTo<CarDto>(request).ToListAsync();
    }

    /// <summary>
    /// Task 2 - Print info about user who driven in date range sort by surname
    /// </summary>
    /// <param name="dateBefore">date before for filter</param>
    /// <param name="dateAfter">date after for filter</param>
    /// <returns>UserDto object</returns>
    [HttpGet("GetUsersByDate")]
    public async Task<ActionResult<dynamic>> GetUsersByDate(DateTime dateBefore, DateTime dateAfter)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        _logger.LogInformation("Get user by date of trip");
        
        var users = await (from rides in _context.Rides
            where (rides.TripDate > dateBefore && rides.TripDate < dateAfter)
            group rides by rides.UserId
            into newobj
            select new
            {
                Id = newobj.Key,
                Surname = 
                    (from users in _context.Users where users.Id == newobj.Key select users.UserSurname).Single(),
                Name = (from users in _context.Users where users.Id == newobj.Key select users.UserName).Single(),
                Patronymic =
                    (from users in _context.Users where users.Id == newobj.Key select users.UserPatronymic)
                    .Single(),
                PhoneNumber = (from users in _context.Users
                    where users.Id == newobj.Key
                    select users.UserPhoneNumber).Single(),
                AmountRides = newobj.Count(),
            }).ToListAsync();
        return users;
    }

    /// <summary>
    /// Task 3 - Print user rides amount
    /// </summary>
    /// <returns>UserDto object</returns>
    [HttpGet("GetUserRides")]
    public async Task<ActionResult<dynamic>> GetUserRides()
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a user");
            return NotFound();
        }

        _logger.LogInformation("Get user rides");
        var userAmountRides = await (from rides in _context.Rides
            group rides by rides.UserId
            into newobj
            select new
            {
                Id = newobj.Key,
                Surname = 
                   (from users in _context.Users where users.Id == newobj.Key select users.UserSurname).Single(),
                Name = (from users in _context.Users where users.Id == newobj.Key select users.UserName).Single(),
                Patronymic =
                    (from users in _context.Users where users.Id == newobj.Key select users.UserPatronymic)
                    .Single(),
                PhoneNumber = (from users in _context.Users
                    where users.Id == newobj.Key
                    select users.UserPhoneNumber).Single(),
                AmountRides = newobj.Count(),
            }).ToListAsync();
        return userAmountRides;
    }

    /// <summary>
    /// Task 4 - Print top five drivers with max amount rides
    /// </summary>
    /// <returns>DriverDto object</returns>
    [HttpGet("TopFiveDrivers")]
    public async Task<ActionResult<dynamic>> TopFiveDrivers()
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Get top five drivers");
        var userAmountRides = await (from rides in _context.Rides
                orderby rides.TripCar.CarRide.Count() descending
                group rides by rides.TripCar.DriverId
                into rar
                select new
                {
                    Id = rar.Key,
                    Surname =
                        (from drivers in _context.Drivers where drivers.Id == rar.Key select drivers.DriverSurname)
                        .Single(),
                    Name =
                        (from drivers in _context.Drivers where drivers.Id == rar.Key select drivers.DriverName)
                        .Single(),
                    Patronymic =
                        (from drivers in _context.Drivers where drivers.Id == rar.Key select drivers.DriverPatronymic)
                        .Single(),
                    PhoneNumber =
                        (from drivers in _context.Drivers where drivers.Id == rar.Key select drivers.DriverPhoneNumber)
                        .Single(),
                    Address =
                        (from drivers in _context.Drivers where drivers.Id == rar.Key select drivers.DriverAddress)
                        .Single(),
                    PassportId = (from drivers in _context.Drivers
                        where drivers.Id == rar.Key
                        select drivers.DriverPassportId).Single(),
                    AmountRides = rar.Count()
                }).Take(5)
            .ToListAsync();
        return userAmountRides;
    }

    /// <summary>
    /// Task 5 - Print info about drivers, his trip time and max trip time
    /// </summary>
    /// <returns>DriversDto object</returns>
    [HttpGet("DriversTripTime")]
    public async Task<ActionResult<dynamic>> DriversTripTime()
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Get drivers with his trip info");
        var request = await (from rides in _context.Rides
            group rides by (rides.TripCar.AssignedDriver.Id)
            into newobj
            select new
            {
                Id = newobj.Key,
                Surname =
                    (from drivers in _context.Drivers where drivers.Id == newobj.Key select drivers.DriverSurname)
                    .Single(),
                Name =
                    (from drivers in _context.Drivers where drivers.Id == newobj.Key select drivers.DriverName)
                    .Single(),
                Patronymic =
                    (from drivers in _context.Drivers where drivers.Id == newobj.Key select drivers.DriverPatronymic)
                    .Single(),
                PhoneNumber =
                    (from drivers in _context.Drivers where drivers.Id == newobj.Key select drivers.DriverPhoneNumber)
                    .Single(),
                Address =
                    (from drivers in _context.Drivers where drivers.Id == newobj.Key select drivers.DriverAddress)
                    .Single(),
                PassportId =
                    (from drivers in _context.Drivers where drivers.Id ==newobj.Key select drivers.DriverPassportId)
                    .Single(),
                MaxTime = (from rides in _context.Rides
                    where rides.TripCar.AssignedDriver.Id == newobj.Key
                    select rides.TripTime).Max(),
                AverageTime = 
                    (from rides in _context.Rides
                        where rides.TripCar.AssignedDriver.Id == newobj.Key
                        select rides.TripTime.TotalMinutes).Take(1).Single()/newobj.Count()/60
            }).ToListAsync();
        return request;
    }

    /// <summary>
    /// Task 6 - Print info about users, with max amount of rides
    /// </summary>
    /// <returns>UserDto object</returns>
    [HttpGet("UserWithAmountRidesByDate")]
    public async Task<ActionResult<dynamic>> UsesWithAmountRidesByDate(DateTime dateBefore, DateTime dateAfter)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a user");
            return NotFound();
        }

        _logger.LogInformation("Get user with max amount of rides by date");
        var userAmountRides = await (from rides in _context.Rides
                orderby rides.UserInfo.AmountRides descending
                where (rides.TripDate < dateAfter && rides.TripDate > dateBefore)
                group rides by rides.UserId
                into rar
                select new
                {
                    Id = rar.Key,
                    Surname =
                        (from users in _context.Users where users.Id == rar.Key select users.UserSurname).Single(),
                    Name = (from users in _context.Users where users.Id == rar.Key select users.UserName).Single(),
                    Patronymic =
                        (from users in _context.Users where users.Id == rar.Key select users.UserPatronymic).Single(),
                    PhoneNumber =
                        (from users in _context.Users where users.Id == rar.Key select users.UserPhoneNumber).Single(),
                    AmountRides = rar.Count()
                }).Take(1)
            .ToListAsync();
        return userAmountRides;
    }
}