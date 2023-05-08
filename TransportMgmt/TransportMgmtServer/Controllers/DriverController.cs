using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Drawing.Text;
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
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
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
    public DriverController(IDbContextFactory<TransportMgmtContext> contextFactory, ILogger<DriverController> logger, ITransportMgmtRepository transportRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _transportRepository = transportRepository;
        _mapper = mapper;

        using var ctx = _contextFactory.CreateDbContext();
        Console.WriteLine(ctx.Drivers.Count());
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
    /// <param name="driver"> Added driver </param>
    [HttpPost]
    public void Post([FromBody] DriverPostDto driver)
    {
        _transportRepository.Drivers.Add(_mapper.Map<Driver>(driver));
        _logger.LogInformation("Successfully added");
    }
    /// <summary>
    /// Put method which allows change the data of driver with a specific id
    /// </summary>
    /// <param name="id"> Driver id whose data will change </param>
    /// <param name="driverToPut"> New driver data </param>
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
    /// <param name="id"> Driver id </param>
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
