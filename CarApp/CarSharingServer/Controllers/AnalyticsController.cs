using AutoMapper;
using CarSharingServer.Dto;
using CarSharingServer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarSharingServer.Controllers;
/// <summary>
/// Analytics controller for queries
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="carRepository"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AnalyticsController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///Get info about all cars
    /// </summary>
    /// <returns></returns>
    [HttpGet("all_cars")]
    public List<CarGetDto> GetAllCars()
    {
        _logger.LogInformation("Get info about all cars");
        return (from car in _carRepository.Cars
                select _mapper.Map<CarGetDto>(car)).ToList();
    }
    /// <summary>
    ///Get info about clients who rented car by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("clients_who_rented_this_model")]
    public IActionResult GetClientsRentedRolls(uint id)
    {
        _logger.LogInformation("Get info about clients rented the car with id");
        var result = (from client in _carRepository.RentedCars where client.CarId == id select client.Client.FirstName).ToList();
        if (result.Count == 0)
        {
            _logger.LogInformation($"No one rented car with id {id}", id);
            return NotFound();
        }
        else return Ok(result);
    }
    /// <summary>
    ///Get info about all cars which are now in rent
    /// </summary>
    /// <returns></returns>
    [HttpGet("all_cars_in_rent")]
    public IActionResult GetAllCarsInRent()
    {
        _logger.LogInformation("Get info about cars in rent");
        var result = (from car in _carRepository.RentedCars where car.TimeOfReturn > DateTime.Now select car.Car.Model).ToList();
        return Ok(result);
    }
    /// <summary>
    ///Get top five cars by the number of rents
    /// </summary>
    /// <returns></returns>
    [HttpGet("top_five_rented_cars")]
    public IActionResult GetTopFiveCars()
    {
        _logger.LogInformation("Get info about top five rented cars");
        var counter = (from car in _carRepository.RentedCars
                       group car by car.Car.CarId into g
                       select new
                       {
                           carmodel = g.Key,
                           count = g.Count()
                       }).ToList();
        var result = (from c in counter orderby c.count descending select c).Take(5).ToList();
        return Ok(result);
    }
    /// <summary>
    ///Get info about how much each car was rented
    /// </summary>
    /// <returns></returns>
    [HttpGet("number_of_rents_for_each_car")]
    public IActionResult GetNumOfRents()
    {
        var result = (from rent in _carRepository.RentedCars
                      group rent by rent.Car.Model into g
                      select new
                      {
                          model = g.Key,
                          cntr = g.Distinct().Count()
                      }).ToList();
        return Ok(result);
    }
    /// <summary>
    ///Get info about rental point where max number of cars were rented
    /// </summary>
    /// <returns></returns>
    [HttpGet("rental_points_with_max_number_of_clients")]
    public IActionResult GetRentalPoints()
    {
        var counter = (from rentalPoint in _carRepository.RentedCars
                       group rentalPoint by rentalPoint.Point.PointName into g
                       select new
                       {
                           name = g.Key,
                           counter = g.Distinct().Count()
                       }).ToList();
        var result = (from rentNum in counter where (rentNum.counter == counter.Max(x => x.counter)) select rentNum.name).ToList();
        return Ok(result);
    }
}
