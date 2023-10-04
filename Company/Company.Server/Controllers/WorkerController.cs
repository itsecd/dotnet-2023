using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for Worker of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<WorkerController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the WorkerController
    /// </summary>
    public WorkerController(IMapper mapper, ILogger<WorkerController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all Workers in the Company
    /// </summary>
    /// <returns>All Workers in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkerGetDto>>> GetWorkers()
    {
        if (_context.WorkerDb == null)
        {
            _logger.LogInformation("Workers database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<WorkerGetDto>(_context.WorkerDb).ToListAsync();
    }


    /// <summary>
    /// Method returns Worker by id
    /// </summary>
    /// <param name="id">Id of Worker</param>
    /// <returns>Worker with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkerGetDto>> GetWorker(int id)
    {
        if (_context.WorkerDb == null)
        {
            _logger.LogInformation("Workers database is empty");
            return NotFound();
        }
        var worker = await _context.WorkerDb.FindAsync(id);
        if (worker == null)
        {
            _logger.LogInformation("The Worker with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<WorkerGetDto>(worker);
    }


    /// <summary>
    /// Method updates Worker information by id
    /// </summary>
    /// <param name="id">Id of Worker</param>
    /// <param name="worker">New information about Worker</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorker(int id, WorkerPostDto worker)
    {
        if (_context.WorkerDb == null)
        {
            _logger.LogInformation("Workers database is empty");
            return NotFound();
        }
        var workerToModify = await _context.WorkerDb.FindAsync(id);
        if (workerToModify == null)
        {
            _logger.LogInformation("The Worker with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(worker, workerToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds Worker in Company
    /// </summary>
    /// <param name="worker">New Worker</param>
    /// <returns>Added Worker and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<WorkerGetDto>> PostWorker(WorkerPostDto worker)
    {
        if (_context.WorkerDb == null)
        {
            _logger.LogInformation("Workers database is empty");
            return NotFound();
        }
        var mappedWorker = _mapper.Map<Worker>(worker);

        _context.WorkerDb.Add(mappedWorker);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostWorker", new { id = mappedWorker.Id }, _mapper.Map<WorkerGetDto>(mappedWorker));
    }


    /// <summary>
    /// Method deletes Worker by id
    /// </summary>
    /// <param name="id">Id of Worker</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorker(int id)
    {
        if (_context.WorkerDb == null)
        {
            _logger.LogInformation("Workers database is empty");
            return NotFound();
        }
        var worker = await _context.WorkerDb.FindAsync(id);
        if (worker == null)
        {
            _logger.LogInformation("The Worker with Id {id} is not found", id);
            return NotFound();
        }

        _context.WorkerDb.Remove(worker);
        await _context.SaveChangesAsync();

        return Ok();
    }
}