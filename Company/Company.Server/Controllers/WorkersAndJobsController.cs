using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for WorkersAndJobs of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkersAndJobsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<WorkersAndJobsController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the WorkersAndJobsController
    /// </summary>
    public WorkersAndJobsController(IMapper mapper, ILogger<WorkersAndJobsController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all elements of WorkersAndJobs database
    /// </summary>
    /// <returns>All elements of WorkersAndJobs database</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkersAndJobsGetDto>>> GetWorkersAndJobs()
    {
        if (_context.WorkersAndJobsDb == null)
        {
            _logger.LogInformation("WorkersAndJobs database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<WorkersAndJobsGetDto>(_context.WorkersAndJobsDb).ToListAsync();
    }


    /// <summary>
    /// Method returns element from WorkersAndJobs database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndJobs database</param>
    /// <returns>Element from WorkersAndJobs database with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkersAndJobsGetDto>> GetWorkersAndJobs(int id)
    {
        if (_context.WorkersAndJobsDb == null)
        {
            _logger.LogInformation("WorkersAndJobs database is empty");
            return NotFound();
        }
        var workersAndJobs = await _context.WorkersAndJobsDb.FindAsync(id);
        if (workersAndJobs == null)
        {
            _logger.LogInformation("Element from WorkersAndJobs database with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<WorkersAndJobsGetDto>(workersAndJobs);
    }


    /// <summary>
    /// Method updates element from WorkersAndJobs database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndJobs database</param>
    /// <param name="workersAndJobs">New element</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkersAndJobs(int id, WorkersAndJobsPostDto workersAndJobs)
    {
        if (_context.WorkersAndJobsDb == null)
        {
            _logger.LogInformation("WorkersAndJobs database is empty");
            return NotFound();
        }
        var workersAndJobsToModify = await _context.WorkersAndJobsDb.FindAsync(id);
        if (workersAndJobsToModify == null)
        {
            _logger.LogInformation("Element from WorkersAndJobs database with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(workersAndJobs, workersAndJobsToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds element to WorkersAndJobs database
    /// </summary>
    /// <param name="workersAndJobs">New element</param>
    /// <returns>Added element and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkersAndJobsGetDto>> PostWorkersAndJobs(WorkersAndJobsPostDto workersAndJobs)
    {
        if (_context.WorkersAndJobsDb == null)
        {
            _logger.LogInformation("WorkersAndJobs database is empty");
            return NotFound();
        }
        var mappedWorkersAndJobs = _mapper.Map<WorkersAndJobs>(workersAndJobs);

        _context.WorkersAndJobsDb.Add(mappedWorkersAndJobs);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostWorkersAndJobs", new { id = mappedWorkersAndJobs.Id }, _mapper.Map<WorkersAndJobsGetDto>(mappedWorkersAndJobs));
    }


    /// <summary>
    /// Method deletes element from WorkersAndJobs database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndJobs database</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkersAndJobs(int id)
    {
        if (_context.WorkersAndJobsDb == null)
        {
            _logger.LogInformation("WorkersAndJobs database is empty");
            return NotFound();
        }
        var workersAndJobs = await _context.WorkersAndJobsDb.FindAsync(id);
        if (workersAndJobs == null)
        {
            _logger.LogInformation("Element from WorkersAndJobs database with Id {id} is not found", id);
            return NotFound();
        }

        _context.WorkersAndJobsDb.Remove(workersAndJobs);
        await _context.SaveChangesAsync();

        return Ok();
    }
}