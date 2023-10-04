using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for Workshop of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkshopController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<WorkshopController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the WorkshopController
    /// </summary>
    public WorkshopController(IMapper mapper, ILogger<WorkshopController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all Workshops in the Company
    /// </summary>
    /// <returns>All Workshops in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkshopGetDto>>> GetWorkshops()
    {
        if (_context.WorkshopDb == null)
        {
            _logger.LogInformation("Workshops database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<WorkshopGetDto>(_context.WorkshopDb).ToListAsync();
    }


    /// <summary>
    /// Method returns Workshop by id
    /// </summary>
    /// <param name="id">Id of Workshop</param>
    /// <returns>Workshop with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkshopGetDto>> GetWorkshop(int id)
    {
        if (_context.WorkshopDb == null)
        {
            _logger.LogInformation("Workshops database is empty");
            return NotFound();
        }
        var workshop = await _context.WorkshopDb.FindAsync(id);
        if (workshop == null)
        {
            _logger.LogInformation("The Workshop with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<WorkshopGetDto>(workshop);
    }


    /// <summary>
    /// Method updates Workshop information by id
    /// </summary>
    /// <param name="id">Id of Workshop</param>
    /// <param name="workshop">New information about Workshop</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkshop(int id, WorkshopPostDto workshop)
    {
        if (_context.WorkshopDb == null)
        {
            _logger.LogInformation("Workshops database is empty");
            return NotFound();
        }
        var workshopToModify = await _context.WorkshopDb.FindAsync(id);
        if (workshopToModify == null)
        {
            _logger.LogInformation("The Workshop with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(workshop, workshopToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds Workshop in Company
    /// </summary>
    /// <param name="workshop">New Workshop</param>
    /// <returns>Added Workshop and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkshopGetDto>> PostWorkshop(WorkshopPostDto workshop)
    {
        if (_context.WorkshopDb == null)
        {
            _logger.LogInformation("Workshops database is empty");
            return NotFound();
        }
        var mappedWorkshop = _mapper.Map<Workshop>(workshop);

        _context.WorkshopDb.Add(mappedWorkshop);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostWorkshop", new { id = mappedWorkshop.Id }, _mapper.Map<WorkshopGetDto>(mappedWorkshop));
    }


    /// <summary>
    /// Method deletes Workshop by id
    /// </summary>
    /// <param name="id">Id of Workshop</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkshop(int id)
    {
        if (_context.WorkshopDb == null)
        {
            _logger.LogInformation("Workshops database is empty");
            return NotFound();
        }
        var workshop = await _context.WorkshopDb.FindAsync(id);
        if (workshop == null)
        {
            _logger.LogInformation("The Workshop with Id {id} is not found", id);
            return NotFound();
        }

        _context.WorkshopDb.Remove(workshop);
        await _context.SaveChangesAsync();

        return Ok();
    }
}