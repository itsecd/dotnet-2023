using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Model;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<OrganizationController> _logger;
    private readonly IMapper _mapper;

    public OrganizationController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<OrganizationController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all organizations
    /// </summary>
    /// <returns>List of organizations</returns>
    [HttpGet]
    public async Task<IEnumerable<OrganizationGetDto>> Get()
    {
        _logger.LogInformation("Get all organization");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<OrganizationGetDto>>(ctx.Organizations);
    }

    /// <summary>
    /// Returns the organization by the specified id
    /// </summary>
    /// <param name="id">id of the organization</param>
    /// <returns>Result of operation and organization object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrganizationGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var organization = ctx.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get organization with id: {id}", id);
            return Ok(_mapper.Map<OrganizationGetDto>(organization));
        }
    }

    /// <summary>
    /// Creates new organization
    /// </summary>
    /// <param name="organization">Organization to be created</param>
    [HttpPost]
    public async void Post([FromBody] OrganizationPostDto organization)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Organizations.Add(_mapper.Map<Organization>(organization));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Changes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be changed</param>
    /// <param name="organizationToPut">New organization data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] OrganizationPostDto organizationToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var organization = ctx.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Organizations.Update(_mapper.Map(organizationToPut, organization));
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Removes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var organization = ctx.Organizations.FirstOrDefault(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Organizations.Remove(organization);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
