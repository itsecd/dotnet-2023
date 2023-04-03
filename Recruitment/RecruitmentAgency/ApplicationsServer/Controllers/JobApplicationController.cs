using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.Dto;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
///     Controller for job applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly ILogger<JobApplicationController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public JobApplicationController(ILogger<JobApplicationController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all job applications
    /// </summary>
    /// <returns>Returns a list of all job applications</returns>
    [HttpGet]
    public IEnumerable<JobApplicationGetDto> Get()
    {
        _logger.LogInformation("Get job applications");
        return _companiesRepository.JobApplications.Select(jobApplication=>_mapper.Map<JobApplicationGetDto>(jobApplication));
    }
    /// <summary>
    ///  Get method that returns a job Application with a specific id
    /// </summary>
    /// <param name="id">Job Application id</param>
    /// <returns>Job application with required id</returns>
    [HttpGet("{id}")]
    public ActionResult<JobApplicationGetDto> Get(int id)
    {
        _logger.LogInformation($"Get job application with id {id}");
        var jobApplication = _companiesRepository.JobApplications.FirstOrDefault(jobApplication => jobApplication.Id == id);
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
    public void Post([FromBody] JobApplicationGetDto jobApplication)
    {
        _companiesRepository.JobApplications.Add(_mapper.Map<JobApplication>(jobApplication));
     }

    /// <summary>
    /// Put method which allows change the data of a job application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="jobApplicationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] JobApplicationGetDto jobApplicationToPut)
    {
        _logger.LogInformation($" Attempting to change a company with an id equal to =  {id}");
        var jobApplication = _companiesRepository.JobApplications.FirstOrDefault(jobApplication => jobApplication.Id == id);
        if (jobApplication == null) return NotFound();
        _mapper.Map<JobApplicationGetDto, JobApplication>(jobApplicationToPut, jobApplication);
        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a job application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($" Attempting to delete a job application with an id equal to =  {id}");
        var jobApplication = _companiesRepository.JobApplications.FirstOrDefault(jobApplication => jobApplication.Id == id);
        if (jobApplication == null) return NotFound();
        _companiesRepository.JobApplications.Remove(jobApplication);
        return Ok();
    }
}
