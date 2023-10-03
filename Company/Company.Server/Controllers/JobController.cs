using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for Job of a Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<JobController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the JobController
    /// </summary>
    public JobController(IMapper mapper, ILogger<JobController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all Jobs in the Company
    /// </summary>
    /// <returns>All Jobs in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
    {
        if (_context.JobDb == null)
        {
            _logger.LogInformation("Jobs database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<JobGetDto>(_context.JobDb).ToListAsync();
    }


    /// <summary>
    /// Method returns Job by id
    /// </summary>
    /// <param name="id">Id of Job</param>
    /// <returns>Job with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<JobGetDto>> GetJob(int id)
    {
        if (_context.JobDb == null)
        {
            _logger.LogInformation("Jobs database is empty");
            return NotFound();
        }
        var job = await _context.JobDb.FindAsync(id);
        if (job == null)
        {
            _logger.LogInformation("The Job with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<JobGetDto>(job);
    }


    /// <summary>
    /// Method updates Job information by id
    /// </summary>
    /// <param name="id">Id of Job</param>
    /// <param name="job">New information about Job</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJob(int id, JobPostDto job)
    {
        if (_context.JobDb == null)
        {
            _logger.LogInformation("Jobs database is empty");
            return NotFound();
        }
        var jobToModify = await _context.JobDb.FindAsync(id);
        if (jobToModify == null)
        {
            _logger.LogInformation("The Job with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(job, jobToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds Job in Company
    /// </summary>
    /// <param name="job">New Job</param>
    /// <returns>Added Job and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<JobGetDto>> PostJob(JobPostDto job)
    {
        if (_context.JobDb == null)
        {
            _logger.LogInformation("Jobs database is empty");
            return NotFound();
        }
        var mappedJob = _mapper.Map<Job>(job);

        _context.JobDb.Add(mappedJob);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostJob", new { id = mappedJob.Id }, _mapper.Map<JobGetDto>(mappedJob));
    }


    /// <summary>
    /// Method deletes Job by id
    /// </summary>
    /// <param name="id">Id of Job</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        if (_context.JobDb == null)
        {
            _logger.LogInformation("Jobs database is empty");
            return NotFound();
        }
        var job = await _context.JobDb.FindAsync(id);
        if (job == null)
        {
            _logger.LogInformation("The Job with Id {id} is not found", id);
            return NotFound();
        }

        _context.JobDb.Remove(job);
        await _context.SaveChangesAsync();

        return Ok();
    }
}