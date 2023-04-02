using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    public CarController(ILogger<CarController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// returns info about all cars
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<CarGetDto> Get()
    {
        _logger.LogInformation("Get the cars");
        return _carRepository.Cars.Select(car => _mapper.Map<CarGetDto>(car));
    }
    /// <summary>
    /// returns car info by id
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
    /// 
    /// </summary>
    /// <param name="car"></param>
    [HttpPost]
    public void Post([FromBody] CarPostDto car)
    {
        _logger.LogInformation("Post a new car");
        _carRepository.Cars.Add(_mapper.Map<Car>(car));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
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
    /// 
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
