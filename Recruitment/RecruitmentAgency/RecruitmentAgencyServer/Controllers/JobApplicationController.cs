using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
///     Controller for job applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly ILogger<JobApplicationController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public JobApplicationController(ILogger<JobApplicationController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all job applications
    /// </summary>
    /// <returns>Returns a list of all job applications</returns>
    [HttpGet]
    public async Task<IEnumerable<JobApplicationGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get job applications");
        var jobApplications = _mapper.Map<IEnumerable<JobApplicationGetDto>>(await ctx.JobApplications.ToListAsync());
        return jobApplications;
    }
    /// <summary>
    ///  Get method that returns a job Application with a specific id
    /// </summary>
    /// <param name="id">Job Application id</param>
    /// <returns>Job application with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplicationGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get job application with id {id}");
        var jobApplication = ctx.Companies.FirstOrDefault(jobApplication => jobApplication.Id == id);
        if (jobApplication == null)
        {
            _logger.LogInformation("Not found job application with id equals to: {id}", id);
            return NotFound();
        }
        return Ok(_mapper.Map<JobApplicationGetDto>(jobApplication));
    }
    /// <summary>
    /// Post method that adding a new job application
    /// </summary>
    /// <param name="jobApplication"></param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] JobApplicationPostDto jobApplication)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post job application");
        var titleExists = await ctx.Titles.AnyAsync(title => title.Id == jobApplication.TitleId);
        var employeeExists = await ctx.Employees.AnyAsync(employee => employee.Id == jobApplication.TitleId);
        if (!titleExists || !employeeExists)
        {
            return BadRequest("Title does not exist");
        }
        await ctx.JobApplications.AddAsync(_mapper.Map<JobApplication>(jobApplication));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put method which allows change the data of a job application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="jobApplicationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] JobApplicationPostDto jobApplicationToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put job application with id {id}", id);
        var jobApplication = ctx.JobApplications.FirstOrDefault(jobApplication => jobApplication.Id == id);
        if (jobApplication == null)
        {
            _logger.LogInformation("Not found jobApplication with id {id}", id);
            return NotFound();
        }
        ctx.Update(_mapper.Map(jobApplicationToPut, jobApplication));
        await ctx.SaveChangesAsync();
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a job application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Delete job application with id ({id})", id);
        var jobApplication = ctx.JobApplications.FirstOrDefault(jobApplication => jobApplication.Id == id);
        if (jobApplication == null)
        {
            _logger.LogInformation("Not found job application with id ({id})", id);
            return NotFound();
        }
        ctx.JobApplications.Remove(jobApplication);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
