using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for driver
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<DriverController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public DriverController(IDbContextFactory<TransportMgmtContext> contextFactory, ILogger<DriverController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all drivers
    /// </summary>
    /// <returns> Returns a list of all drivers </returns>
    [HttpGet]
    public async Task<IEnumerable<DriverGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get drivers");
        return _mapper.Map<IEnumerable<DriverGetDto>>(context.Drivers);
    }
    /// <summary>
    /// Get method that returns driver with a specific id
    /// </summary>
    /// <param name="id"> Driver id </param>
    /// <returns> Driver with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DriverGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get driver with id= {id}", id);
        var driver = await context.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
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
    public async Task Post([FromBody] DriverPostDto driver)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Drivers.AddAsync(_mapper.Map<Driver>(driver));
        _logger.LogInformation("Successfully added");
        await context.SaveChangesAsync();
    }
    /// <summary>
    /// Put method which allows change the data of driver with a specific id
    /// </summary>
    /// <param name="id"> Driver id whose data will change </param>
    /// <param name="driverToPut"> New driver data </param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] DriverPostDto driverToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var driver = await context.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(driverToPut, driver);
            _logger.LogInformation("Successfully updates");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete method which allows delete a driver with a specific id
    /// </summary>
    /// <param name="id"> Driver id </param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var driver = await context.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id= {id} ", id);
            return NotFound();
        }
        else
        {
            context.Drivers.Remove(driver);
            _logger.LogInformation("Successfully removed");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
