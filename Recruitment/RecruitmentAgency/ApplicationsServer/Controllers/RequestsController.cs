using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.DTO;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
///     Controller for companies applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public RequestsController(ILogger<RequestsController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
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
    public ActionResult<IEnumerable<JobApplicationGetDTO>> GetApplicantsRequestsForSpecificJobTitle(string jobTitle)
    {
        var query = (from jobApplications in _companiesRepository.JobApplications
                     where jobApplications.Title == jobTitle
                     orderby jobApplications.Employee.PersonalName
                     select _mapper.Map<JobApplicationGetDTO>(jobApplications)).ToList();
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
    public ActionResult<IEnumerable<EmployeeGetDTO>> GetPassengerOverGivenPeriod(DateTime minDate, DateTime maxDate)
    {
        var query = (from jobApplications in _companiesRepository.JobApplications
                     where jobApplications.Date >= minDate && jobApplications.Date <= maxDate
                     select jobApplications.Employee).ToList();

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
    public ActionResult<IEnumerable<EmployeeGetDTO>> GetApplicantsThatMatchCompanyApplication(int id)
    {
        var query = from applications in _companiesRepository.Titles
                    from appCompany in applications.CompanyApplications.Where(appCompany => appCompany.Id == id)
                    from appEmployee in applications.EmployeeApplications.Where(appEmployee => appEmployee.Employee.Salary <= appCompany.Salary &&
                    appEmployee.Employee.Education == appCompany.Education && appEmployee.Title == appCompany.Title.JobTitle &&
                    appEmployee.Employee.WorkExperience >= appCompany.WorkExperience)
                    select new
                    {
                        Employee = appEmployee,
                    };
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
    public ActionResult<IEnumerable<TitleGetDTO>> GetNumberApplications()
    {
        var query = from titles in _companiesRepository.Titles
                     select new
                     {
                         JobSection = titles.Section,
                         JobTitle = titles.JobTitle,
                         NumJobApplications = titles.EmployeeApplications.Count(jobApplication => jobApplication.Title == titles.JobTitle),
                         NumCompanyApplications = titles.CompanyApplications.Count(companyApplication => companyApplication.Title.JobTitle == titles.JobTitle)
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
    public ActionResult<IEnumerable<Company>> GetTheMostPopularCompanies()
    {
        var query = (from companyApplication in _companiesRepository.CompaniesApplications
                     group companyApplication by companyApplication.Company.CompanyName into tableGroup
                     orderby tableGroup.Count() descending
                     select new
                     {
                         Company = tableGroup.Key,
                         NumRequests = tableGroup.Count()
                     }).Take(5).ToList();

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
    public ActionResult<IEnumerable<CompanyApplication>> GetTheCompanyWithHighestWage()
    {
        var query = from companyApplication in _companiesRepository.CompaniesApplications
                     where companyApplication.Salary == (from companyApplicationSalaries in _companiesRepository.CompaniesApplications
                                                         select companyApplicationSalaries.Salary).Max()
                     select new
                     {
                         CompanyRequest = companyApplication,
                     };

        if (!query.Any())
        {
            _logger.LogInformation("There are no companies");
            return NotFound();
        }

        _logger.LogInformation("Get the company with biggest wage");
        return Ok(query);
    }
}
