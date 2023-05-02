using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// DriversController class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    /// <summary>
    /// TaxiDepoDbContext class object
    /// </summary>
    private readonly TaxiDepoDbContext _context;

    /// <summary>
    /// Mapper for DriversController class
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Logger for DriversController class
    /// </summary>
    private readonly ILogger<DriversController> _logger;

    /// <summary>
    /// Constructor with params of DriversController class 
    /// </summary>
    /// <param name="context">TaxiDepoDbContext class object</param>
    /// <param name="mapper">IMapper object</param>
    /// <param name="logger">ILogger object</param>
    public DriversController(TaxiDepoDbContext context, IMapper mapper, ILogger<DriversController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get all drivers from collection
    /// </summary>
    /// <returns>DriverDto object</returns>
    [HttpGet("GetAllDrivers")]
    public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers()
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Get all drivers from collection");
        return await _mapper.ProjectTo<DriverDto>(_context.Drivers).ToListAsync();
    }

    /// <summary>
    /// Get driver by id from collection
    /// </summary>
    /// <param name="id">Needed driver id</param>
    /// <returns>DriverDto object</returns>
    [HttpGet("GetDriverBy{id}")]
    public async Task<ActionResult<DriverDto>> GetDriver(int id)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Get driver by id from collection");
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Not found a driver by id");
            return NotFound();
        }

        return _mapper.Map<DriverDto>(driver);
    }

    /// <summary>
    /// Put driver from collection
    /// </summary>
    /// <param name="id">Needed id to put</param>
    /// <param name="driver">Driver to put</param>
    /// <returns>No content</returns>
    [HttpPut("PutDriverBy{id}")]
    public async Task<IActionResult> PutDriver(int id, DriverDto driver)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Put a driver by id from collection");
        var driverToModify = await _context.Drivers.FindAsync(id);
        if (driverToModify == null)
        {
            _logger.LogInformation("Not found a driver by id");
            return NotFound();
        }

        _mapper.Map(driver, driverToModify);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Post driver to collection
    /// </summary>
    /// <param name="driver">Driver to post</param>
    /// <returns>Created action</returns>
    [HttpPost("PostDriver")]
    [ProducesResponseType(201)]
    public async Task<ActionResult<DriverDto>> PostDriver(DriverDto driver)
    {
        if (_context.Drivers == null)
        {
            return Problem("Entity set 'TaxiDepoDbContext.Drivers'  is null.");
        }

        _logger.LogInformation("Posting driver to collection");
        var mappedDriver = _mapper.Map<Driver>(driver);
        _context.Drivers.Add(mappedDriver);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostDriver", new { id = mappedDriver.Id }, _mapper.Map<DriverDto>(mappedDriver));
    }

    /// <summary>
    /// Delete driver from collection
    /// </summary>
    /// <param name="id">Needed id to delete</param>
    /// <returns>No content</returns>
    [HttpDelete("DeleteDriverBy{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Not found a drivers");
            return NotFound();
        }

        _logger.LogInformation("Deletion driver from collection");
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Not found a driver by id");
            return NotFound();
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

