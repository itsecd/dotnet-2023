using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Asn1.Pkcs;
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
    public async Task<ActionResult<IEnumerable<CarAndDriverDto>>> GetCarAndDriver(int id)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a car");
            return NotFound();
        }

        _logger.LogInformation("Get car and driver");
        var request = await (from car in _context.Cars where (car.Id == id)
        select new
        {
            car.Id,
            car.CarColor,
            car.CarModel,
            car.CarNumber,
            car.DriverId,
            car.AssignedDriver.DriverSurname,
            car.AssignedDriver.DriverName,
            car.AssignedDriver.DriverPatronymic,
            car.AssignedDriver.DriverPassportId,
            car.AssignedDriver.DriverAddress,
            car.AssignedDriver.DriverPhoneNumber
        }).ToListAsync();
        return Ok(request);
    }

    /// <summary>
    /// Task 2 - Print info about user who driven in date range sort by surname
    /// </summary>
    /// <param name="dateBefore">date before for filter</param>
    /// <param name="dateAfter">date after for filter</param>
    /// <returns>UserDto object</returns>
    [HttpGet("GetUsersByDate")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByDate(string dateBefore, string dateAfter)
    {
        if (_context.Rides == null)
        {
            _logger.LogInformation("Not found a ride");
            return NotFound();
        }

        _logger.LogInformation("Get user by date of trip");

        var users = await (from rides in _context.Rides
                           group rides by rides.UserId
            into newobj
                           select new
                           {
                               user = (from rides in _context.Rides where rides.UserInfo.Id == newobj.Key select _mapper.Map<UserDto>(rides.UserInfo)).Single(),
                               AmountRides = newobj.Count(),
                           }).ToListAsync();
        return Ok(users);
    }

    /// <summary>
    /// Task 3 - Print user rides amount
    /// </summary>
    /// <returns>UserDto object</returns>
    [HttpGet("GetUserRides")]
    public async Task<ActionResult<IEnumerable<CountUserRidesDto>>> GetUserRides()
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
                                     group rides by rides.UserId into newobj
                                     select new
                                     {
                                         UserSurname = (from user in _context.Users
                                                        where user.Id == newobj.Key
                                                        select user.UserSurname).Single(),
                                         UserName = (from user in _context.Users
                                                     where user.Id == newobj.Key
                                                     select user.UserName).Single(),
                                         UserPatronymic = (from user in _context.Users
                                                           where user.Id == newobj.Key
                                                           select user.UserPatronymic).Single(),
                                         AmountRides = newobj.Count(),
                                     }).ToListAsync();
        return Ok(userAmountRides);
    }

    /// <summary>
    /// Task 4 - Print top five drivers with max amount rides
    /// </summary>
    /// <returns>DriverDto object</returns>
    [HttpGet("TopFiveDrivers")]
    public async Task<ActionResult<Driver>> TopFiveDrivers()
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
        var driver = await (from rides in _context.Rides
                                     orderby rides.TripCar.CarRide!.Count() descending
                                     group rides by rides.TripCar.DriverId
                into newobj
                                     select new
                                     {
                                         driver = (from rides in _context.Rides where rides.TripCar.AssignedDriver!.Id == newobj.Key select _mapper.Map<DriverDto>(rides.TripCar.AssignedDriver)).Single(),
                                         AmountRides = newobj.Count()
                                     }).Take(5)
            .ToListAsync();
        return Ok(driver);
    }

    /// <summary>
    /// Task 5 - Print info about drivers, his trip time and max trip time
    /// </summary>
    /// <returns>DriversDto object</returns>
    [HttpGet("DriversTripTime")]
    public async Task<ActionResult<IEnumerable<DriverRidesInfoDto>>> DriversTripTime()
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
        var query = await (from ridesInfo in from ride in _context.Rides
                                             group ride by ride.CarId into grp
                                             select new
                                             {
                                                 CarId = grp.Key,
                                                 AmountRides = grp.Count(),
                                                 max = grp.Max(ride => ride.TripTime),
                                                 rideTimesInSeconds = grp.Select(ride => ride.TripTime)
                                             }
                           from car in _context.Cars!
                           where ridesInfo.CarId == car.Id
                           select new
                           {
                               car.AssignedDriver!.DriverSurname,
                               car.AssignedDriver.DriverName,
                               car.AssignedDriver.DriverPatronymic,
                               ridesInfo.AmountRides,
                               avg = TimeSpan.FromSeconds(ridesInfo.rideTimesInSeconds.Sum() / ridesInfo.AmountRides),
                               ridesInfo.max
                           }).ToListAsync();
        return Ok(query);
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

        var subquery = await (from rides in _context.Rides
                              orderby rides.UserInfo descending
                              group rides by rides.UserId into newobj
                              select new
                              {
                                  UserSurname = (from rides in _context.Rides where rides.UserInfo.Id == newobj.Key select rides.UserInfo.UserSurname).Single(),
                                  UserName = (from rides in _context.Rides where rides.UserInfo.Id == newobj.Key select rides.UserInfo.UserName).Single(),
                                  UserPatronymic = (from rides in _context.Rides where rides.UserInfo.Id == newobj.Key select rides.UserInfo.UserPatronymic).Single(),
                                  AmountRides = newobj.Count()
                              }).ToListAsync();

        if (subquery.Count == 0)
        {
            _logger.LogInformation("Not found passengers");
            return NotFound();
        }

        var max = subquery.Max(elem => elem.AmountRides);

        var query = (from sq in subquery
                     where sq.AmountRides == max
                     select new
                     {
                         sq.UserSurname,
                         sq.UserName,
                         sq.UserPatronymic,
                         max
                     }).ToList();

        _logger.LogInformation("Get passenger with max count of rides");
        return Ok(query);
    }
}