using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentedCarController : ControllerBase
{
    private readonly ILogger<RentedCarController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    public RentedCarController(ILogger<RentedCarController> logger, ICarSharingRepository carRepository, IMapper mapper)
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
    public IEnumerable<RentedCarGetDto> Get()
    {
        _logger.LogInformation("Get the rented cars");
        return _carRepository.RentedCars.Select(rentedCar => _mapper.Map<RentedCarGetDto>(rentedCar));
    }
    /// <summary>
    /// returns car info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<RentedCarGetDto> Get(uint id)
    {
        _logger.LogInformation($"Get the rented car with id {id} ", id);
        var rentedCarInfo = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCarInfo == null)
        {
            _logger.LogInformation($"Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<RentedCarGetDto>(rentedCarInfo));
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="car"></param>
    [HttpPost]
    public void Post([FromBody] RentedCarPostDto rentedCar)
    {
        _logger.LogInformation("Post a new car");
        _carRepository.RentedCars.Add(_mapper.Map<RentedCar>(rentedCar));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public IActionResult Put(uint id, [FromBody] RentedCarPostDto rentedCarToPut)
    {
        var rentedCar = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCar == null)
        {
            _logger.LogInformation($"Not found rented car with id {id}", id);
            return NotFound();
        }
        else
        {

            _mapper.Map(rentedCarToPut, rentedCar);
            _logger.LogInformation("Put a new rented car - success");
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
        var rentedCar = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCar == null)
        {
            _logger.LogInformation($"Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {
            _carRepository.RentedCars.Remove(rentedCar);
            _logger.LogInformation("Delete a car - success");
            return Ok();
        }
    }
}
