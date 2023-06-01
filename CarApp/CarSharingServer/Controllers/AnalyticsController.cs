using AutoMapper;
using CarSharingDomain;
using CarSharingServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace CarSharingServer.Controllers;
/// <summary>
/// Analytics controller for queries
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IMapper _mapper;
    private readonly IDbContextFactory<CarSharingDbContext> _contextFactory;
    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="contextFactory">
    /// </param>
    /// <param name="logger">
    /// </param>
    /// <param name="mapper"></param>
    public AnalyticsController(IDbContextFactory<CarSharingDbContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///Get info about all cars
    /// </summary>
    /// <returns>
    /// List of all cars
    /// </returns>
    [HttpGet("all_cars")]
    public async Task<ActionResult<CarGetDto>> GetAllCars()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.Cars == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get info about all cars");
        var result = await (from car in ctx.Cars
                            select _mapper.Map<CarGetDto>(car)).ToListAsync();
        return Ok(result);
    }
    /// <summary>
    ///Get info about clients who rented car by id
    /// </summary>
    /// <param name="id">
    /// Identification number of car
    /// </param>
    /// <returns>
    /// List of clients who ever rented a car by id
    /// </returns>
    [HttpGet("clients_who_rented_model_by_id")]
    public async Task<IActionResult> GetClientsRentedCar(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentedCars == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get info about clients rented the car with id");
        var result = await (from client in ctx.RentedCars where client.Car.Id == id select client.Client.LastName).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("No one rented car with id {id}", id);
            return NotFound();
        }
        else return Ok(result);
    }
    /// <summary>
    ///Get info about all cars which are now in rent
    /// </summary>
    /// <returns>
    /// List of cars which are now in rent
    /// </returns>
    [HttpGet("all_cars_in_rent")]
    public async Task<IActionResult> GetAllCarsInRent()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentedCars == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get info about cars in rent");
        var result = await (from car in ctx.RentedCars where car.TimeOfReturn > DateTime.Now select car.Car.Model).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("There are no cars in rent right now");
            return NotFound();
        }
        else return Ok(result);
    }
    /// <summary>
    ///Get top five cars by the number of rents
    /// </summary>
    /// <returns>
    /// List of five most popular car models ordered by number of rents
    /// </returns>
    [HttpGet("top_five_rented_cars")]
    public async Task<ActionResult<IEnumerable<TopCarsGetDto>>> TopFiveCars()
    {
         await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentedCars == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get info about top five rented cars");
    var counter = await (from car in ctx.RentedCars
                             group car by car.Car.Model into carGroup
                             select new TopCarsGetDto
                             {
                                 // carmodel = carGroup.Key,
                               Model=carGroup.Key,
                                 Rating =carGroup.Count()
                             }).ToListAsync();
     
        var result = (from rents in counter orderby rents.Rating descending  select rents).Take(5).ToList();
        return Ok(result);
    }

  
       
    
    /// <summary>
    ///Get info about how much each car was rented
    /// </summary>
    /// <returns>
    /// List of cars and number of rents for each model
    /// </returns>
    [HttpGet("number_of_rents_for_each_car")]
    public async Task<IActionResult> GetNumOfRents()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentedCars == null)
        {
            return NotFound();
        }
        var result = await (from rent in ctx.RentedCars
                            group rent by rent.Car.Model into carGroup
                            select new
                            {
                                model = carGroup.Key,
                                counter = carGroup.Distinct().Count()
                            }).ToListAsync();
        return Ok(result);
    }
    /// <summary>
    ///Get info about rental point where max number of cars were rented
    /// </summary>
    /// <returns>
    /// Rental point with max number of rented cars ever
    /// </returns>
    [HttpGet("rental_points_with_max_number_of_clients")]
    public async Task<IActionResult> GetRentalPointsStatistics()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        if (ctx.RentedCars == null)
        {
            return NotFound();
        }
        var counter = await (from rentalPoint in ctx.RentedCars
                             group rentalPoint by rentalPoint.Point.PointName into rentalPointGroup
                             select new
                             {
                                 name = rentalPointGroup.Key,
                                 counter = rentalPointGroup.Distinct().Count()
                             }).ToListAsync();
        var result = (from rentNum in counter where (rentNum.counter == counter.Max(point => point.counter)) select rentNum.name).ToList();
        return Ok(result);
    }
}
