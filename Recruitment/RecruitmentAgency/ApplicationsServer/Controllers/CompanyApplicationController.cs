using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.Dto;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
///     Controller for companies applications
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyApplicationController : ControllerBase
{
    private readonly ILogger<CompanyApplicationController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public CompanyApplicationController(ILogger<CompanyApplicationController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all companies applications
    /// </summary>
    /// <returns>Returns a list of all companies applications</returns>
    [HttpGet]
    public IEnumerable<CompanyApplicationGetDto> Get()
    {
        _logger.LogInformation("Get companies applications");
        return _companiesRepository.CompaniesApplications.Select(companyApplication=>_mapper.Map<CompanyApplicationGetDto>(companyApplication));
    }
    /// <summary>
    ///  Get method that returns company application with a specific id
    /// </summary>
    /// <param name="id">Company application id</param>
    /// <returns>Company with required id</returns>
    [HttpGet("{id}")]
    public ActionResult<CompanyApplicationGetDto> Get(int id)
    {
        _logger.LogInformation($"Get company application with id {id}");
        var companyApplication = _companiesRepository.CompaniesApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null) 
        {
            _logger.LogInformation("Not found company application with id equals to: {id}", id);
            return NotFound(); 
        }
        return Ok(_mapper.Map<CompanyApplicationGetDto>(companyApplication));
    }
    /// <summary>
    /// Post method that adding a new company application
    /// </summary>
    /// <param name="companyApplication"></param>
    [HttpPost]
    public void Post([FromBody] CompanyApplicationGetDto companyApplication)
    {
        _companiesRepository.CompaniesApplications.Add(_mapper.Map<CompanyApplication>(companyApplication));
    }

    /// <summary>
    /// Put method which allows change the data of company application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="companyApplicationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CompanyApplicationGetDto companyApplicationToPut)
    {
        _logger.LogInformation($" Attempting to change a company application with an id equal to =  {id}");
        var companyApplication = _companiesRepository.CompaniesApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null) return NotFound();
        _mapper.Map<CompanyApplicationGetDto, CompanyApplication>(companyApplicationToPut, companyApplication);

        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a company application with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($" Attempting to delete a company application with an id equal to =  {id}");
        var companyApplication = _companiesRepository.CompaniesApplications.FirstOrDefault(companyApplication => companyApplication.Id == id);
        if (companyApplication == null) return NotFound();
        _companiesRepository.CompaniesApplications.Remove(companyApplication);
        return Ok();
    }
}
