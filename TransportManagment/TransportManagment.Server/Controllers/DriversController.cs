using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportManagment.Models;
using TransportManagment.Server.Dto;
namespace TransportManagment.Server.Controllers;
/// <summary>
/// Drivers
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    private readonly TransportManagmentDbContext _context;
    private readonly ILogger<DriversController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public DriversController(ILogger<DriversController> logger, TransportManagmentDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Get all drivers
    /// </summary>
    /// <returns> List of drivers </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DriverGetDto>>> GetDrivers()
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Drivers is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get drivers");
        return await _mapper.ProjectTo<DriverGetDto>(_context.Drivers).ToListAsync();
    }
    /// <summary>
    /// Get driver for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Driver </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DriverGetDto>> GetDriver(int id)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Driver is not founded");
            return NotFound();
        }
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Driver is not founded");
            return NotFound();
        }
        _logger.LogInformation("Get driver with this id");
        return _mapper.Map<DriverGetDto>(driver);
    }
    /// <summary>
    /// Changing information about driver
    /// </summary>
    /// <param name="id"></param>
    /// <param name="driver"> Changed information about driver </param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDriver(int id, [FromBody] DriverPostDto driver)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("There is no driver");
            return NotFound();
        }
        var driverToChanged = await _context.Drivers.FindAsync(id);
        if (driverToChanged == null)
        {
            _logger.LogInformation("Driver is not founded");
            return NotFound();
        }
        _mapper.Map(driver, driverToChanged);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Driver was changimg");
        return NoContent();
    }
    /// <summary>
    /// Method posts a new driver
    /// </summary>
    /// <param name="driver"> New driver </param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<DriverGetDto>> PostDriver([FromBody] DriverPostDto driver)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("There is no driver");
            return Problem("Entity set 'DriverManagmentDbContext.Drivers'  is null.");
        }
        var addedDriver = _mapper.Map<Driver>(driver);
        _context.Drivers.Add(addedDriver);
        await _context.SaveChangesAsync();
        _logger.LogInformation("New driver recorded");
        return CreatedAtAction("GetDriver", new { id = addedDriver.DriverId }, _mapper.Map<DriverGetDto>(addedDriver));
    }
    /// <summary>
    /// Deleting driver for id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        if (_context.Drivers == null)
        {
            _logger.LogInformation("Driver is not founded");
            return NotFound();
        }
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("There is no driver");
            return NotFound();
        }
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Driver deleted");
        return NoContent();
    }
}