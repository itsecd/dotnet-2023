using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;

    private readonly INonResidentialFundRepository _organizationsRepository;

    private readonly IMapper _mapper;

    public OrganizationController(ILogger<OrganizationController> logger, INonResidentialFundRepository organizationsRepository, IMapper mapper)
    {
        _logger = logger;
        _organizationsRepository = organizationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all organizations
    /// </summary>
    /// <returns>List of organizations</returns>
    [HttpGet]
    public IEnumerable<Organization> Get()
    {
        _logger.LogInformation("Get all organization");
        return _organizationsRepository.Organizations;
    }

    /// <summary>
    /// Returns the organization by the specified id
    /// </summary>
    /// <param name="id">id of the organization</param>
    /// <returns>Result of operation and organization object</returns>
    [HttpGet("{id}")]
    public ActionResult<Organization> Get(int id)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get organization with id: {id}", id);
            return Ok(organization);
        }
    }

    /// <summary>
    /// Creates new organization
    /// </summary>
    /// <param name="organization">Organization to be created</param>
    [HttpPost]
    public void Post([FromBody] OrganizationPostDto organization)
    {
        _organizationsRepository.Organizations.Add(_mapper.Map<Organization>(organization));
    }

    /// <summary>
    /// Changes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be changed</param>
    /// <param name="organizationToPut">New organization data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] OrganizationPostDto organizationToPut)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(organizationToPut, organization);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _organizationsRepository.Organizations.Remove(organization);
            return Ok();
        }
    }
}
