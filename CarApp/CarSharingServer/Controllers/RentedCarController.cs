using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
/// <summary>
/// Rented car controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentedCarController : ControllerBase
{
    private readonly ILogger<RentedCarController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for RentedCarController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="carRepository"></param>
    /// <param name="mapper"></param>
    public RentedCarController(ILogger<RentedCarController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get info about all rented cars
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<RentedCarGetDto> Get()
    {
        _logger.LogInformation("Get the rented cars");
        return _carRepository.RentedCars.Select(rentedCar => _mapper.Map<RentedCarGetDto>(rentedCar));
    }
    /// <summary>
    /// Get rented car by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<RentedCarGetDto> Get(uint id)
    {
        _logger.LogInformation("Get the rented car with id {id} ", id);
        var rentedCarInfo = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCarInfo == null)
        {
            _logger.LogInformation("Not found a car with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<RentedCarGetDto>(rentedCarInfo));
        }
    }
    /// <summary>
    /// Post a new rented car
    /// </summary>
    /// <param name="rentedCar"></param>
    [HttpPost]
    public void Post([FromBody] RentedCarPostDto rentedCar)
    {
        _logger.LogInformation("Post a new car");
        _carRepository.RentedCars.Add(_mapper.Map<RentedCar>(rentedCar));
    }
   /// <summary>
   /// Put a rented car
   /// </summary>
   /// <param name="id"></param>
   /// <param name="rentedCarToPut"></param>
   /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(uint id, [FromBody] RentedCarPostDto rentedCarToPut)
    {
        var rentedCar = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCar == null)
        {
            _logger.LogInformation("Not found rented car with id {id}", id);
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
    /// Delete rented car
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(uint id)
    {
        var rentedCar = _carRepository.RentedCars.FirstOrDefault(info => info.Id == id);
        if (rentedCar == null)
        {
            _logger.LogInformation("Not found a car with id {id}", id);
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
