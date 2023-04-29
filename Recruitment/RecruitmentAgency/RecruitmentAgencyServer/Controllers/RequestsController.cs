using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Dto;

namespace RecruitmentAgencyServer.Controllers;

/// <summary>
///     Controller for companies applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;
    private readonly IDbContextFactory<RecruitmentAgencyContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public RequestsController(ILogger<RequestsController> logger, IDbContextFactory<RecruitmentAgencyContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
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
    public async Task<ActionResult<IEnumerable<JobApplicationGetDto>>> GetApplicantsRequestsForSpecificJobTitle(int jobTitle)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from jobApplications in ctx.JobApplications
                     where jobApplications.TitleId == jobTitle
                     orderby jobApplications.EmployeeId
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
    public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> GetPassengerOverGivenPeriod(DateTime minDate, DateTime maxDate)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from jobApplication in ctx.JobApplications
                     join employee in ctx.Employees on jobApplication.EmployeeId equals employee.Id
                     where jobApplication.Date >= minDate && jobApplication.Date <= maxDate
                     select employee).ToList();
        if (query.Count == 0)
        {
            _logger.LogInformation("Not found applicants over given period");
            return NotFound();
        }

        _logger.LogInformation("Get applicants over given period");
        return Ok(query);
    }

    /// <summary>
    ///   Display information about applicants that match a specific company application.
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>
    ///     Display information about all applicants that matches a specific company application
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("applicants_matches/{id}")]
    public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> GetApplicantsThatMatchCompanyApplication(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = from jobApp in ctx.JobApplications
                    join companyApp in ctx.CompanyApplications on jobApp.TitleId equals companyApp.TitleId
                    join employee in ctx.Employees on jobApp.EmployeeId equals employee.Id
                    where companyApp.Id == id
                        && employee.Applications.Any(appId => appId == jobApp.Id)
                    select employee;
        if (!query.Any())
        {
            _logger.LogInformation("No match for company application with id = {id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get the employees that match the company's application with id = {id}", id);
        return Ok(query);
    }

    /// <summary>
    ///   Output information about the number of applications for each section and position.
    /// </summary>
    /// <returns>
    ///     Output information about the number of applications for each section and position.
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("applications_number")]
    public async Task<ActionResult<IEnumerable<TitleGetDto>>> GetNumberApplications()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = from title in ctx.Titles
                    group title by new { title.Section, title.JobTitle } into grp
                    select new
                    {
                        Section = grp.Key.Section,
                        JobTitle = grp.Key.JobTitle,
                        NumApplications = grp.Sum(title => title.EmployeeApplications.Count + title.CompanyApplications.Count)
                    };

        if (!query.Any())
        {
            _logger.LogInformation("There are no requests");
            return NotFound();
        }

        _logger.LogInformation("Get the number of requests}");
        return Ok(query);
    }

    /// <summary>
    ///   Output information about the most popular companies
    /// </summary>
    /// <returns>   
    ///     Output information about the most popular companies
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("the_most_popular_companies")]
    public async Task<ActionResult<IEnumerable<Company>>> GetTheMostPopularCompanies()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = ctx.Companies
                  .OrderByDescending(c => c.Applications.Count)
                  .Take(5)
                  .Select(c => new
                  {
                      CompanyName = c.CompanyName,
                      NumberOfApplications = c.Applications.Count
                  });
        if (!query.Any())
        {
            _logger.LogInformation("There are no companies");
            return NotFound();
        }

        _logger.LogInformation("Get the most popular companies");
        return Ok(query);
    }

    /// <summary>
    ///   Output information about the company that pays the highest wages
    /// </summary>
    /// <returns>
    ///     Output information about the company that pays the highest wages
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("the_highest_wage")]
    public async Task<ActionResult<IEnumerable<CompanyApplication>>> GetTheCompanyWithHighestWage()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = ctx.Companies
                 .OrderByDescending(c => c.Applications
                 .SelectMany(appId => ctx.CompanyApplications
                  .Where(ca => ca.CompanyId == c.Id && ca.Id == appId)
                   .Select(ca => ca.Salary))
                   .Max())
                 .Take(5);

        if (!query.Any())
        {
            _logger.LogInformation("There are no companies");
            return NotFound();
        }

        _logger.LogInformation("Get the company with biggest wage");
        return Ok(query);
    }
}
