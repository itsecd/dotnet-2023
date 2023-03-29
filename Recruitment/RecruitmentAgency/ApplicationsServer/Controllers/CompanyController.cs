using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency;
using ApplicationsServer.DTO;
using ApplicationsServer.Repository;
using AutoMapper;

namespace ApplicationsServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ILogger<CompanyController> _logger;
    private readonly IApplicationsServerRepository _companiesRepository;
    private readonly IMapper _mapper;
    public CompanyController(ILogger<CompanyController> logger, IApplicationsServerRepository companiesRepository, IMapper mapper)
    {
        _logger = logger;
        _companiesRepository = companiesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all companies
    /// </summary>
    /// <returns>Returns a list of all companies</returns>
    [HttpGet]
    public IEnumerable<CompanyGetDTO> Get()
    {
        _logger.LogInformation("Get companies");
        return _companiesRepository.Companies.Select(company =>_mapper.Map<CompanyGetDTO>(company));
    }

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

    [HttpPost]
    public void Post([FromBody] CompanyPostDTO company)
    {
        _companiesRepository.Companies.Add(_mapper.Map<Company>(company));
     }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CompanyPostDTO companyToPut)
    {
        _logger.LogInformation($" Attempting to change a company with an id equal to =  {id}");
        var company = _companiesRepository.Companies.FirstOrDefault(company => company.Id == id);
        if (company == null) return NotFound();
        _mapper.Map<CompanyPostDTO, Company>(companyToPut, company);

        return Ok();
    }
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
