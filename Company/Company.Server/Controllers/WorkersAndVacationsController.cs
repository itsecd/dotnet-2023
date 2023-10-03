using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for WorkersAndVacations of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkersAndVacationsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<WorkersAndVacationsController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the WorkersAndVacationsController
    /// </summary>
    public WorkersAndVacationsController(IMapper mapper, ILogger<WorkersAndVacationsController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all elements of WorkersAndVacations database
    /// </summary>
    /// <returns>All elements of WorkersAndVacations database</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkersAndVacationsGetDto>>> GetWorkersAndVacations()
    {
        if (_context.WorkersAndVacationsDb == null)
        {
            _logger.LogInformation("WorkersAndVacations database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<WorkersAndVacationsGetDto>(_context.WorkersAndVacationsDb).ToListAsync();
    }


    /// <summary>
    /// Method returns element from WorkersAndVacations database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndVacations database</param>
    /// <returns>Element from WorkersAndVacations database with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkersAndVacationsGetDto>> GetWorkersAndVacations(int id)
    {
        if (_context.WorkersAndVacationsDb == null)
        {
            _logger.LogInformation("WorkersAndVacations database is empty");
            return NotFound();
        }
        var workersAndVacations = await _context.WorkersAndVacationsDb.FindAsync(id);
        if (workersAndVacations == null)
        {
            _logger.LogInformation("Element from WorkersAndVacations database with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<WorkersAndVacationsGetDto>(workersAndVacations);
    }


    /// <summary>
    /// Method updates element from WorkersAndVacations database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndVacations database</param>
    /// <param name="workersAndVacations">New element</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkersAndVacations(int id, WorkersAndVacationsPostDto workersAndVacations)
    {
        if (_context.WorkersAndVacationsDb == null)
        {
            _logger.LogInformation("WorkersAndVacations database is empty");
            return NotFound();
        }
        var workersAndVacationsToModify = await _context.WorkersAndVacationsDb.FindAsync(id);
        if (workersAndVacationsToModify == null)
        {
            _logger.LogInformation("Element from WorkersAndVacations database with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(workersAndVacations, workersAndVacationsToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds element to WorkersAndVacations database
    /// </summary>
    /// <param name="workersAndVacations">New element</param>
    /// <returns>Added element and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkersAndVacationsGetDto>> PostWorkersAndVacations(WorkersAndVacationsPostDto workersAndVacations)
    {
        if (_context.WorkersAndVacationsDb == null)
        {
            _logger.LogInformation("WorkersAndVacations database is empty");
            return NotFound();
        }
        var mappedWorkersAndVacations = _mapper.Map<WorkersAndVacations>(workersAndVacations);

        _context.WorkersAndVacationsDb.Add(mappedWorkersAndVacations);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostWorkersAndVacations", new { id = mappedWorkersAndVacations.Id }, _mapper.Map<WorkersAndVacationsGetDto>(mappedWorkersAndVacations));
    }


    /// <summary>
    /// Method deletes element from WorkersAndVacations database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndVacations database</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkersAndVacations(int id)
    {
        if (_context.WorkersAndVacationsDb == null)
        {
            _logger.LogInformation("WorkersAndVacations database is empty");
            return NotFound();
        }
        var workersAndVacations = await _context.WorkersAndVacationsDb.FindAsync(id);
        if (workersAndVacations == null)
        {
            _logger.LogInformation("Element from WorkersAndVacations database with Id {id} is not found", id);
            return NotFound();
        }

        _context.WorkersAndVacationsDb.Remove(workersAndVacations);
        await _context.SaveChangesAsync();

        return Ok();
    }
}