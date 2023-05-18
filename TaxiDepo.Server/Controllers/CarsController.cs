using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// CarsController class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    /// <summary>
    /// TaxiDepoDbContext class object
    /// </summary>
    private readonly TaxiDepoDbContext _context;

    /// <summary>
    /// Mapper for CarsController class
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Logger for CarsController class
    /// </summary>
    private readonly ILogger<CarsController> _logger;

    /// <summary>
    /// Constructor with params of CarsController class 
    /// </summary>
    /// <param name="context">TaxiDepoDbContext class object</param>
    /// <param name="mapper">IMapper object</param>
    /// <param name="logger">ILogger object</param>
    public CarsController(TaxiDepoDbContext context, IMapper mapper, ILogger<CarsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get all cars from collection
    /// </summary>
    /// <returns>CarDto object</returns>
    [HttpGet("GetAllCars")]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a cars");
            return NotFound();
        }

        _logger.LogInformation("Get all cars from collection");
        return await _mapper.ProjectTo<CarDto>(_context.Cars).ToListAsync();
    }

    /// <summary>
    /// Get car by id from collection
    /// </summary>
    /// <param name="id">Needed car id</param>
    /// <returns>CarDto object</returns>
    [HttpGet("GetCarBy{id}")]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a cars");
            return NotFound();
        }

        _logger.LogInformation("Get car by id from collection");
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            _logger.LogInformation("Not found a car by id");
            return NotFound();
        }

        return _mapper.Map<CarDto>(car);
    }

    /// <summary>
    /// Put car from collection
    /// </summary>
    /// <param name="id">Needed id to put</param>
    /// <param name="car">Car to put</param>
    /// <returns>No content</returns>
    [HttpPut("PutCarBy{id}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> PutCar(int id, CarDto car)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a cars");
            return NotFound();
        }

        _logger.LogInformation("Put a car by id from collection");
        var carToModify = await _context.Cars.FindAsync(id);
        if (carToModify == null)
        {
            _logger.LogInformation("Not found a car by id to modify");
            return NotFound();
        }

        _mapper.Map(car, carToModify);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [ProducesResponseType(201)]
    /// <summary>
    /// Post car to collection
    /// </summary>
    /// <param name="car">Car to post</param>
    /// <returns>Created action</returns>
    [HttpPost("PostCar")]
    public async Task<ActionResult<CarDto>> PostCar(CarDto car)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a cars");
            return Problem("Entity set 'TaxiDepoDbContext.Cars' is null.");
        }

        _logger.LogInformation("Posting car to collection");
        var mappedCar = _mapper.Map<Car>(car);
        _context.Cars.Add(mappedCar);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostCar", new { id = mappedCar.Id }, _mapper.Map<CarDto>(mappedCar));
    }

    /// <summary>
    /// Delete car from collection
    /// </summary>
    /// <param name="id">Needed id to delete</param>
    /// <returns>No content</returns>
    [ProducesResponseType(204)]
    [HttpDelete("DeleteCarBy{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        if (_context.Cars == null)
        {
            _logger.LogInformation("Not found a cars");
            return NotFound();
        }

        _logger.LogInformation("Deletion car from collection");
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            _logger.LogInformation("Not found a car by id");
            return NotFound();
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}