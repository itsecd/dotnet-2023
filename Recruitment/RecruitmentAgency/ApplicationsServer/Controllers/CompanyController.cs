using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.DTO;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;

/// <summary>
///     Controller for companies
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ILogger<CompanyController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Controller constructor
    /// </summary>
    public CompanyController(ILogger<CompanyController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns a list of all companies
    /// </summary>
    /// <returns>Returns a list of all companies</returns>
    [HttpGet]
    public IEnumerable<CompanyGetDTO> Get()
    {
        _logger.LogInformation("Get companies");
        return _companiesRepository.Companies.Select(employee=>_mapper.Map<CompanyGetDTO>(employee));
    }
    /// <summary>
    ///  Get method that returns a company with a specific id
    /// </summary>
    /// <param name="id">Company id</param>
    /// <returns>Company with required id</returns>
    [HttpGet("{id}")]
    public ActionResult<CompanyGetDTO> Get(int id)
    {
        _logger.LogInformation($"Get company with id {id}");
        var company = _companiesRepository.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null) 
        {
            _logger.LogInformation("Not found company with id equals to: {id}", id);
            return NotFound(); 
        }
        return Ok(_mapper.Map<CompanyGetDTO>(company));
    }
    /// <summary>
    /// Post method that adding a new company 
    /// </summary>
    /// <param name="company"></param>
    [HttpPost]
    public void Post([FromBody] CompanyPostDTO company)
    {
        _companiesRepository.Companies.Add(_mapper.Map<Company>(company));
     }

    /// <summary>
    /// Put method which allows change the data of a company with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="companyToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CompanyPostDTO companyToPut)
    {
        _logger.LogInformation($" Attempting to change a company with an id equal to =  {id}");
        var company = _companiesRepository.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null) return NotFound();
        _mapper.Map<CompanyPostDTO, Company>(companyToPut, company);

        return Ok();
    }
    /// <summary>
    /// Delete method which allows delete a company with a specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($" Attempting to delete a company with an id equal to =  {id}");
        var company = _companiesRepository.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null) return NotFound();
        _companiesRepository.Companies.Remove(company);
        return Ok();
    }
}
