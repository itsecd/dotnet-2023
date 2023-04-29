using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;
using RecruitmentAgencyServer.Repository;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
///     Controller for companies applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;
    private readonly IRecruitmentAgencyServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public RequestsController(ILogger<RequestsController> logger, IRecruitmentAgencyServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///   Display information about all applicants looking for a job in a given position, sorted by full name.
    /// </summary>
    /// <param name="jobTitle"> Job title</param>
    /// <returns>
    ///     Display information about all applicants looking for a job
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("applicants_requests/{jobTitle}")]
    public ActionResult<IEnumerable<JobApplicationGetDto>> GetApplicantsRequestsForSpecificJobTitle(string jobTitle)
    {
        var xId = 666;
        if(jobTitle == "Backend")
        {
            xId = 0;
        }
        if (jobTitle == "Frontend")
        {
            xId = 1;
        }
        var query = (from jobApplications in _companiesRepository.JobApplications
                     where jobApplications.TitleId == xId
                     orderby jobApplications?.EmployeeId
                     select _mapper.Map<JobApplicationGetDto>(jobApplications)).ToList();
        if (query.Count == 0)
        {
            _logger.LogInformation("No applications for the title={jobTitle} position were found", jobTitle);
            return NotFound();
        }

        _logger.LogInformation("Get applications for the title = {jobTitle}", jobTitle);
        return Ok(query);
    }

    /// <summary>
    ///     Output all applicants who left applications during the specified period.
    /// </summary>
    /// <param name="minDate"> Start date</param>
    /// <param name="maxDate"> End date</param>
    /// <returns>
    ///     Return list of applicants
    /// </returns>
    [HttpGet("applicants_over_given_period")]
    public ActionResult<IEnumerable<EmployeeGetDto>> GetPassengerOverGivenPeriod(DateTime minDate, DateTime maxDate)
    {
        var query = (from jobApplications in _companiesRepository.JobApplications
                     where jobApplications.Date >= minDate && jobApplications.Date <= maxDate
                     select jobApplications.EmployeeId).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found applicants over given period");
            return NotFound();
        }

        _logger.LogInformation("Get applicants over given period");
        return Ok(query);
    }
}
