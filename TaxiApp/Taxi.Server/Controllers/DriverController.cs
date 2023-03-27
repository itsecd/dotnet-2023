using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for driver table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly ILogger<DriverController> _logger;
    private readonly IMapper _mapper;
    private readonly ITaxiRepository _taxiRepository;

    public DriverController(ILogger<DriverController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all drivers
    /// </summary>
    /// <returns>
    ///     List of drivers
    /// </returns>
    [HttpGet]
    public IEnumerable<Driver> Get()
    {
        _logger.LogInformation("Get drivers");
        return _taxiRepository.Drivers;
    }

    /// <summary>
    ///     Get method which returns driver by id
    /// </summary>
    /// <param name="id"> Identifier of driver</param>
    /// <returns>
    ///     Driver with the required id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<Driver> Get(ulong id)
    {
        Driver? driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get driver with id={id}", id);
        return Ok(driver);
    }

    /// <summary>
    ///     Post method which add new driver in driver table
    /// </summary>
    /// <param name="driver"> New driver for addition</param>
    /// >
    [HttpPost]
    public void Post([FromBody] DriverPostDto driver)
    {
        _logger.LogInformation("Post driver");
        _taxiRepository.Drivers.Add(_mapper.Map<Driver>(driver));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired driver by id
    /// </summary>
    /// <param name="id"> Identifier of driver</param>
    /// <param name="driverToPut"> New driver data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] DriverPostDto driverToPut)
    {
        Driver? driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put driver with id={id}", id);
        _mapper.Map(driverToPut, driver);
        return Ok();
    }

    /// <summary>
    ///     Delete - method for deleting a driver by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of driver </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Driver? driver = _taxiRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete driver with id={id}", id);
        _taxiRepository.Drivers.Remove(driver);
        return Ok();
    }
}