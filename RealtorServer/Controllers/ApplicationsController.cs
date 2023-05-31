using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtor;
using AutoMapper;
using RealtorServer.Dto;

namespace RealtorServer.Controllers;
/// <summary>
///     Controller for application table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly RealtorDbContext _context;
    private readonly ILogger<ApplicationsController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Constructor for ApplicationsController
    /// </summary>
    public ApplicationsController(RealtorDbContext context, IMapper mapper, ILogger<ApplicationsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    ///     Get method for application table
    /// </summary>
    /// <returns>
    ///     Return applications list
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationGetDto>>> GetApplications()
    {
      if (_context.Applications == null)
      {
          return NotFound();
      }
      _logger.LogInformation("Get applications");
      return await _mapper.ProjectTo<ApplicationGetDto>(_context.Applications).ToListAsync();
    }
    /// <summary>
    ///     Get by id method for application table
    /// </summary>
    /// <param name="id"> application id </param>
    /// <returns>
    ///     Return application with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationGetDto>> GetApplication(int id)
    {
        _logger.LogInformation("Get application with id {id}", id);
        if (_context.Applications == null)
      {
          return NotFound();
      }
        var application = await _context.Applications.FindAsync(id);
        if (application == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        return _mapper.Map<ApplicationGetDto>(application);
    }
    /// <summary>
    /// Change application info
    /// </summary>
    /// <param name="id">application id</param>
    /// <param name="application">Changing application</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApplication(int id, Application application)
    {
        if (_context.Applications== null)
        {
            return NotFound();
        }
        var applicationToPut = await _context.Applications.FindAsync(id);
        if (applicationToPut == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        _mapper.Map(application, applicationToPut);
        _logger.LogInformation("Updated");
        await _context.SaveChangesAsync();
        return NoContent();
    }
    /// <summary>
    ///     Post method for application table
    /// </summary>
    /// <param name="application"> application</param>
    /// <returns>
    ///     Create application
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<ApplicationGetDto>> PostApplication(Application application)
    {
        if (_context.Applications == null)
        {
            return Problem("Entity set 'RealtorDbContext.Applications'  is null.");
        }
        var newApplication = _mapper.Map<Application>(application);
        _context.Applications.Add(newApplication);
        _logger.LogInformation("Added");
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostApplication", new { id = newApplication.Id }, _mapper.Map<ApplicationGetDto>(newApplication));
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of application which would be deleted </param>
    /// <returns>
    ///     Action Result
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        if (_context.Applications == null)
        {
            return NotFound();
        }
        var application = await _context.Applications.FindAsync(id);
        if (application == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        _context.Applications.Remove(application);
        _logger.LogInformation("Deleted");
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
