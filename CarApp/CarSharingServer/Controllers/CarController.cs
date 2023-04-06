using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
/// <summary>
/// Car controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for CarController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="carRepository"></param>
    /// <param name="mapper"></param>
    public CarController(ILogger<CarController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get info about all cars
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<CarGetDto> Get()
    {
        _logger.LogInformation("Get the cars");
        return _carRepository.Cars.Select(car => _mapper.Map<CarGetDto>(car));
    }
    /// <summary>
    /// Get car info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<CarGetDto> Get(uint id)
    {
        _logger.LogInformation($"Get the car with id {id} ", id);
        var carInfo = _carRepository.Cars.FirstOrDefault(info => info.CarId == id);
        if (carInfo == null)
        {
            _logger.LogInformation($"Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<CarGetDto>(carInfo));
        }
    }
    /// <summary>
    /// Post a new car
    /// </summary>
    /// <param name="car"></param>
    [HttpPost]
    public void Post([FromBody] CarPostDto car)
    {
        _logger.LogInformation("Post a new car");
        _carRepository.Cars.Add(_mapper.Map<Car>(car));
    }
    /// <summary>
    /// Put car
    /// </summary>
    /// <param name="id"></param>
    /// <param name="carToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(uint id, [FromBody] CarPostDto carToPut)
    {
        var car = _carRepository.Cars.FirstOrDefault(info => info.CarId == id);
        if (car == null)
        {
            _logger.LogInformation($"Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {

            _mapper.Map(carToPut, car);
            _logger.LogInformation("Put a new car - success");
            return Ok();
        }
    }
    /// <summary>
    /// Delete a car
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(uint id)
    {
        var car = _carRepository.Cars.FirstOrDefault(info => info.CarId == id);
        if (car == null)
        {
            _logger.LogInformation($"Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {
            _carRepository.Cars.Remove(car);
            _logger.LogInformation("Delete a car - success");
            return Ok();
        }
    }
}
