using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;
using TaxiDepo.Server.Repositories;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// Car controller class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    /// <summary>
    /// Car logger
    /// </summary>
    private readonly ILogger<CarController> _logger;
    /// <summary>
    /// TaxiDepo repository
    /// </summary>
    private readonly ITaxiDepoRepository _taxiRepository;
    /// <summary>
    /// Mapper
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// CarController class constructor with params
    /// </summary>
    /// <param name="logger">Car logger</param>
    /// <param name="taxiRepository">Taxi repository</param>
    /// <param name="mapper">Mapper</param>
    public CarController(ILogger<CarController> logger, ITaxiDepoRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get request
    /// </summary>
    /// <returns>All cars objects</returns>
    [HttpGet]
    public IEnumerable<CarDto> Get()
    {
        _logger.LogInformation("Get car");
        return _taxiRepository.Cars.Select(car => _mapper.Map<CarDto>(car));
    }
    /// <summary>
    /// Get request with search by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Found object or 404Error</returns>
    [HttpGet("{id:int}")]
    public ActionResult<CarDto> Get(int id)
    {
        var car = _taxiRepository.Cars.FirstOrDefault(car => car.Id == id);
        if (car != null)
        {
            _logger.LogInformation("Get car by Id");
            return Ok(_mapper.Map<CarDto>(car));
        }
        _logger.LogInformation("Not found a car with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Insert request with selection by id
    /// </summary>
    /// <param name="car">Car object</param>
    [HttpPost]
    public void Post([FromBody] CarDto car)
    {
        _logger.LogInformation("Add car");
        _taxiRepository.Cars.Add(_mapper.Map<Car>(car));
    }
    /// <summary>
    /// Put request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <param name="carToPut">CarDto object</param>
    /// <returns>Change object or 404Error</returns>
    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] CarDto carToPut)
    {
        var car = _taxiRepository.Cars.FirstOrDefault(car => car.Id == id);
        if (car != null)
        {
            _mapper.Map(carToPut, car);
            _logger.LogInformation("Put car");
            return Ok();
        }
        _logger.LogInformation("Not found a car with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Delete request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Delete object or 404Error</returns>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var car = _taxiRepository.Cars.FirstOrDefault(car => car.Id == id);
        if (car != null)
        {
            _logger.LogInformation("Delete car");
            return Ok();
        }
        _logger.LogInformation("Not found a car with id: {id}", id);
        return NotFound();
    }
}
