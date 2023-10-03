using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for WorkersAndDepartments of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkersAndDepartmentsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<WorkersAndDepartmentsController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the WorkersAndDepartmentsController
    /// </summary>
    public WorkersAndDepartmentsController(IMapper mapper, ILogger<WorkersAndDepartmentsController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all elements of WorkersAndDepartments database
    /// </summary>
    /// <returns>All elements of WorkersAndDepartments database</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkersAndDepartmentsGetDto>>> GetWorkersAndDepartments()
    {
        if (_context.WorkersAndDepartmentsDb == null)
        {
            _logger.LogInformation("WorkersAndDepartments database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<WorkersAndDepartmentsGetDto>(_context.WorkersAndDepartmentsDb).ToListAsync();
    }


    /// <summary>
    /// Method returns element from WorkersAndDepartments database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndDepartments database</param>
    /// <returns>Element from WorkersAndDepartments database with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkersAndDepartmentsGetDto>> GetWorkersAndDepartments(int id)
    {
        if (_context.WorkersAndDepartmentsDb == null)
        {
            _logger.LogInformation("WorkersAndDepartments database is empty");
            return NotFound();
        }
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.FindAsync(id);
        if (workersAndDepartments == null)
        {
            _logger.LogInformation("Element from WorkersAndDepartments database with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<WorkersAndDepartmentsGetDto>(workersAndDepartments);
    }


    /// <summary>
    /// Method updates element from WorkersAndDepartments database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndDepartments database</param>
    /// <param name="workersAndDepartments">New element</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkersAndDepartments(int id, WorkersAndDepartmentsPostDto workersAndDepartments)
    {
        if (_context.WorkersAndDepartmentsDb == null)
        {
            _logger.LogInformation("WorkersAndDepartments database is empty");
            return NotFound();
        }
        var workersAndDepartmentsToModify = await _context.WorkersAndDepartmentsDb.FindAsync(id);
        if (workersAndDepartmentsToModify == null)
        {
            _logger.LogInformation("Element from WorkersAndDepartments database with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(workersAndDepartments, workersAndDepartmentsToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds element to WorkersAndDepartments database
    /// </summary>
    /// <param name="workersAndDepartments">New element</param>
    /// <returns>Added element and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkersAndDepartmentsGetDto>> PostWorkersAndDepartments(WorkersAndDepartmentsPostDto workersAndDepartments)
    {
        if (_context.WorkersAndDepartmentsDb == null)
        {
            _logger.LogInformation("WorkersAndDepartments database is empty");
            return NotFound();
        }
        var mappedWorkersAndDepartments = _mapper.Map<WorkersAndDepartments>(workersAndDepartments);

        _context.WorkersAndDepartmentsDb.Add(mappedWorkersAndDepartments);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostWorkersAndDepartments", new { id = mappedWorkersAndDepartments.Id }, _mapper.Map<WorkersAndDepartmentsGetDto>(mappedWorkersAndDepartments));
    }


    /// <summary>
    /// Method deletes element from WorkersAndDepartments database by id
    /// </summary>
    /// <param name="id">Id of element from WorkersAndDepartments database</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkersAndDepartments(int id)
    {
        if (_context.WorkersAndDepartmentsDb == null)
        {
            _logger.LogInformation("WorkersAndDepartments database is empty");
            return NotFound();
        }
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.FindAsync(id);
        if (workersAndDepartments == null)
        {
            _logger.LogInformation("Element from WorkersAndDepartments database with Id {id} is not found", id);
            return NotFound();
        }

        _context.WorkersAndDepartmentsDb.Remove(workersAndDepartments);
        await _context.SaveChangesAsync();

        return Ok();
    }
}