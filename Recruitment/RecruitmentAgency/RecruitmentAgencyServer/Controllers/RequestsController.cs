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
    /// <param name="jobTitle">Job title</param>
    /// <returns>
    ///     Display information about all applicants looking for a job
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("applicants_requests/{jobTitle}")]
    public async Task<IEnumerable<EmployeeGetDto>> GetApplicantsRequestsForSpecificJobTitle(int jobTitle)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from employee in ctx.Employees
                            join jobApplication in ctx.JobApplications on employee.Id equals jobApplication.EmployeeId
                            join title in ctx.Titles on jobApplication.TitleId equals title.Id
                            where title.Id == jobTitle
                            select employee).ToListAsync();
        _logger.LogInformation("Get applications for the title = {jobTitle}", jobTitle);
        return _mapper.Map<IEnumerable<EmployeeGetDto>>(result);
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
    public async Task<IEnumerable<EmployeeGetDto>> GetPassengerOverGivenPeriod(DateTime minDate, DateTime maxDate)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from jobApplication in ctx.JobApplications
                     join employee in ctx.Employees on jobApplication.EmployeeId equals employee.Id
                     where jobApplication.Date >= minDate && jobApplication.Date <= maxDate
                     select employee).ToList();
        _logger.LogInformation("Get applicants over given period");
        return _mapper.Map<IEnumerable<EmployeeGetDto>>(query);
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
    public async Task<IEnumerable<ApplicationsMatchesDto>> GetApplicantsThatMatchCompanyApplication(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = await (from employee in ctx.Employees
                           join jobApplication in ctx.JobApplications on employee.Id equals jobApplication.EmployeeId
                           join companyApplication in ctx.CompanyApplications on jobApplication.TitleId equals companyApplication.TitleId
                           where jobApplication.TitleId == id &&
                                 employee.Salary <= companyApplication.Salary &&
                                 employee.Education == companyApplication.Education
                           select new ApplicationsMatchesDto
                           {
                               PersonalName = employee.PersonalName,
                               Salary = employee.Salary,
                               CompanySalary = companyApplication.Salary,
                               CompanyId = companyApplication.CompanyId
                           }).ToListAsync();
        _logger.LogInformation("Get the employees that match the company's application with id = {id}", id);
        return _mapper.Map<IEnumerable<ApplicationsMatchesDto>>(query);
    }

    /// <summary>
    ///   Output information about the number of applications for each section and position.
    /// </summary>
    /// <returns>
    ///     Output information about the number of applications for each section and position.
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("applications_number")]
    public async Task<IEnumerable<NumberApplicationsDto>> GetNumberApplications()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from titles in ctx.Titles
                     join jobApplications in ctx.JobApplications on titles.Id equals jobApplications.TitleId into jobApplicationsGroup
                     select new NumberApplicationsDto
                     {
                         JobSection = titles.Section,
                         JobTitle = titles.JobTitle,
                         NumJobApplications = jobApplicationsGroup.Count(),
                         NumCompanyApplications = titles.CompanyApplications.Count()
                     }).ToList();
        _logger.LogInformation("Get the number of requests}");
        return _mapper.Map<IEnumerable<NumberApplicationsDto>>(query);
    }

    /// <summary>
    ///   Output information about the most popular companies
    /// </summary>
    /// <returns>   
    ///     Output information about the most popular companies
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("the_most_popular_companies")]
    public async Task<IEnumerable<MostPopularCompaniesDto>> GetTheMostPopularCompanies()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from company in ctx.Companies
                     join companyApplication in ctx.CompanyApplications on company.Id equals companyApplication.CompanyId into gj
                     orderby gj.Count() descending
                     select new MostPopularCompaniesDto
                     {
                         CompanyName = company.CompanyName,
                         NumberOfApplications = gj.Count()
                     }).Take(5).ToList();
        _logger.LogInformation("Get the most popular companies");
        return _mapper.Map<IEnumerable<MostPopularCompaniesDto>>(query);
    }

    /// <summary>
    ///   Output information about the company that pays the highest wages
    /// </summary>
    /// <returns>
    ///     Output information about the company that pays the highest wages
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("the_highest_wage")]
    public async Task<IEnumerable<CompanyGetDto>> GetTheCompanyWithHighestWage()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var query = (from companyApplication in ctx.CompanyApplications
                     join company in ctx.Companies on companyApplication.CompanyId equals company.Id
                     where companyApplication.Salary == (from companyApplicationSalaries in ctx.CompanyApplications
                                                         select companyApplicationSalaries.Salary).Max()
                     select new CompanyGetDto
                     {
                         CompanyName = company.CompanyName,
                         ContactName = company.ContactName,
                         Telephone = company.Telephone
                     }).ToList();
        _logger.LogInformation("Get the company with biggest wage");
        return _mapper.Map<IEnumerable<CompanyGetDto>>(query);
    }
}
