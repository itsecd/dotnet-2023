using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;
using TransportMgmtServer.Repository;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for driver
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<DriverController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ITransportMgmtRepository _transportRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public DriverController(ILogger<DriverController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a list of all drivers
    /// </summary>
    /// <returns> Returns a list of all drivers </returns>
    [HttpGet]

    public IEnumerable<DriverGetDto> Get()
    {
        _logger.LogInformation("Get drivers");
        return _transportRepository.Drivers.Select(driver => _mapper.Map<DriverGetDto>(driver));
    }

    /// <summary>
    /// Get method that returns driver with a specific id
    /// </summary>
    /// <param name="id"> Driver id </param>
    /// <returns> Driver with required id </returns>
    [HttpGet("{id}")]

    public ActionResult<DriverGetDto> Get(int id)
    {
        _logger.LogInformation("Get driver with id= {id}", id);
        var driver = _transportRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id= {id} ", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<DriverGetDto>(driver));
    }

    /// <summary>
    /// Post method that adding a new driver
    /// </summary>
    /// <param name="driver"></param>
    [HttpPost]

    public void Post([FromBody] DriverPostDto driver)
    {
        _transportRepository.Drivers.Add(_mapper.Map<Driver>(driver));
        _logger.LogInformation("Successfully added");
    }

    /// <summary>
    /// Put method which allows change the data of driver with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="driverToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] DriverPostDto driverToPut)
    {
        var driver = _transportRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(driverToPut, driver);
            _logger.LogInformation("Successfully updates");
            return Ok();
        }
    }

    /// <summary>
    /// Delete method which allows delete a driver with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        var driver = _transportRepository.Drivers.FirstOrDefault(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _transportRepository.Drivers.Remove(driver);
            _logger.LogInformation("Successfully removed");
            return Ok();
        }
    }
}
