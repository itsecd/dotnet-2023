using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtor;
using RealtorServer.Dto;

namespace RealtorServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationHasHousesController : ControllerBase
{
    private readonly RealtorDbContext _context;
    private readonly ILogger<ApplicationHasHousesController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Constructor for ApplicationHasHousesController
    /// </summary>
    public ApplicationHasHousesController(RealtorDbContext context, IMapper mapper, ILogger<ApplicationHasHousesController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    ///     Get method for ApplicationHasHouses table
    /// </summary>
    /// <returns>
    ///     Return ApplicationHasHouses list
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationHasHouseDto>>> GetApplications()
    {
        if (_context.ApplicationHasHouses == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get applications");
        return await _mapper.ProjectTo<ApplicationHasHouseDto>(_context.ApplicationHasHouses).ToListAsync();
    }
    /// <summary>
    ///     Get by id method for ApplicationHasHouses table
    /// </summary>
    /// <param name="id"> ApplicationHasHouses id </param>
    /// <returns>
    ///     Return ApplicationHasHouses with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationHasHouseDto>> GetApplication(int id)
    {
        _logger.LogInformation("Get application with id {id}", id);
        if (_context.ApplicationHasHouses == null)
        {
            return NotFound();
        }
        var applicationHasHouses = await _context.ApplicationHasHouses.FindAsync(id);
        if (applicationHasHouses == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        return _mapper.Map<ApplicationHasHouseDto>(applicationHasHouses);
    }
    /// <summary>
    /// Change ApplicationHasHouses info
    /// </summary>
    /// <param name="id">ApplicationHasHouses id</param>
    /// <param name="applicationHasHouses">Changing ApplicationHasHouses</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApplication(int id, ApplicationHasHouseDto applicationHasHouses)
    {
        if (_context.ApplicationHasHouses == null)
        {
            return NotFound();
        }
        var applicationHasHousesToPut = await _context.ApplicationHasHouses.FindAsync(id);
        if (applicationHasHousesToPut == null)
        {
            _logger.LogInformation("Not found applicationConnection with id {id}", id);
            return NotFound();
        }
        _mapper.Map(applicationHasHouses, applicationHasHousesToPut);
        _logger.LogInformation("Updated");
        await _context.SaveChangesAsync();
        return NoContent();
    }
    /// <summary>
    ///     Post method for ApplicationHasHouses table
    /// </summary>
    /// <param name="applicationHasHouses"> ApplicationHasHouses</param>
    /// <returns>
    ///     Create ApplicationHasHouses
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<ApplicationHasHouseDto>> PostApplication(ApplicationHasHouseDto applicationHasHouses)
    {
        if (_context.ApplicationHasHouses == null)
        {
            return Problem("Entity set 'RealtorDbContext.Applications'  is null.");
        }
        var newApplicationHasHouse = _mapper.Map<ApplicationHasHouse>(applicationHasHouses);
        _context.ApplicationHasHouses.Add(newApplicationHasHouse);
        _logger.LogInformation("Added");
        await _context.SaveChangesAsync();
        return CreatedAtAction("Post Connection", new { id = newApplicationHasHouse.Id }, _mapper.Map<ApplicationHasHouseDto>(newApplicationHasHouse));
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of ApplicationHasHouses which would be deleted </param>
    /// <returns>
    ///     Action Result
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplicationHasHouse(int id)
    {
        if (_context.ApplicationHasHouses == null)
        {
            return NotFound();
        }
        var applicationHasHouses = await _context.ApplicationHasHouses.FindAsync(id);
        if (applicationHasHouses == null)
        {
            _logger.LogInformation("Not found applicationConnection with id {id}", id);
            return NotFound();
        }
        _context.ApplicationHasHouses.Remove(applicationHasHouses);
        _logger.LogInformation("Deleted");
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
