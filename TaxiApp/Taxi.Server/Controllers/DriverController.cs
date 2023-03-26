using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DriverController : ControllerBase
{
    private readonly ILogger<DriverController> _logger;
    
    private readonly ITaxiRepository _taxiRepository;

    private readonly IMapper _mapper;
    
    public DriverController(ILogger<DriverController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Driver> Get()
    {
        _logger.LogInformation("Get driver");
        return _taxiRepository.Drivers;
    }

    [HttpGet("{id}")]
    public ActionResult<Driver> Get(ulong id)
    {
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation($"Not found driver with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get driver with id={id}");
            return Ok(driver);
        }
    }

    [HttpPost]
    public void Post([FromBody] DriverPostDto driver)
    {
        _logger.LogInformation($"Post driver");
        _taxiRepository.Drivers.Add(_mapper.Map<Driver>(driver));
    }
    
    [HttpPut("{id}")]

    public IActionResult Put(ulong id, [FromBody] DriverPostDto driverToPut)
    {
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation($"Not found driver with id={id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put driver with id={id}", id);
            _mapper.Map(driverToPut, driver);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    
    public IActionResult Delete(ulong id)
    {
        var driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation($"Not found driver with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete driver with id={id}");
            _taxiRepository.Drivers.Remove(driver);
            return Ok();
        }
    }
}