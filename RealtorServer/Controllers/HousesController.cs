using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtor;
using AutoMapper;
using RealtorServer.Dto;

namespace RealtorServer.Controllers;
/// <summary>
///     Controller for houses table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HousesController : ControllerBase
{
    private readonly ILogger<HousesController> _logger;
    private readonly RealtorDbContext _context;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Constructor for HousesController
    /// </summary>
    public HousesController(RealtorDbContext context, IMapper mapper, ILogger<HousesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    ///     Get method for houses table
    /// </summary>
    /// <returns>
    ///     Return Houses list
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HouseGetDto>>> GetHouses()
    {
        if (_context.Houses == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get houses");
        return await _mapper.ProjectTo<HouseGetDto>(_context.Houses).ToListAsync();
    }
    /// <summary>
    ///     Get by id method for houses table
    /// </summary>
    /// <param name="id"> house id </param>
    /// <returns>
    ///     Return house with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<HouseGetDto>> GetHouse(int id)
    {
        _logger.LogInformation("Get house with id {id}", id);
        if (_context.Houses == null)
        {
            return NotFound();
        }
        var house = await _context.Houses.FindAsync(id);
        if (house == null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound();
        }
        return _mapper.Map<HouseGetDto>(house);
    }
    /// <summary>
    /// Change house info
    /// </summary>
    /// <param name="id">House id</param>
    /// <param name="house">Changing house</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHouse(int id, HousePostDto house)
    {
        if (_context.Houses == null)
        {
            return NotFound();
        }
        var houseToPut = await _context.Houses.FindAsync(id);
        if(houseToPut==null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound();
        }
        _mapper.Map(house,houseToPut);
        _logger.LogInformation("Updated");
        await _context.SaveChangesAsync();
        return NoContent();
    }
    /// <summary>
    ///     Post method for houses table
    /// </summary>
    /// <param name="house"> House</param>
    /// <returns>
    ///     Create house
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<HouseGetDto>> PostHouse(HousePostDto house)
    {
        if (_context.Houses == null)
        {
            return Problem("Entity set 'RealtorDbContext.Houses'  is null.");
        }
        var newHouse = _mapper.Map<House>(house);
        _context.Houses.Add(newHouse);
        _logger.LogInformation("Added");
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostHouse", new { id = newHouse.Id },_mapper.Map<HouseGetDto>(newHouse));
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of house which would be deleted </param>
    /// <returns>
    ///     Action Result
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHouse(int id)
    {
        if (_context.Houses == null)
        {
            return NotFound();
        }
        var house = await _context.Houses.FindAsync(id);
        if (house == null)
        {
            _logger.LogInformation("Not found house with id {id}", id);
            return NotFound();
        }
        _context.Houses.Remove(house);
        _logger.LogInformation("Deleted");
        await _context.SaveChangesAsync();
        return NoContent();
    }    
}
