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
        var organizations = await ctx.Organizations.ToListAsync();
        return _mapper.Map<IEnumerable<OrganizationGetDto>>(organizations);
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
        var organization = await ctx.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
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
    public async Task<ActionResult<OrganizationGetDto>> Post([FromBody] OrganizationPostDto organization)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var organizationToPut = _mapper.Map<Organization>(organization);
        ctx.Organizations.Add(organizationToPut);
        await ctx.SaveChangesAsync();
        return Ok(_mapper.Map<OrganizationGetDto>(organizationToPut));
    }

    /// <summary>
    /// Changes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be changed</param>
    /// <param name="organizationToPut">New organization data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<OrganizationGetDto>> Put(int id, [FromBody] OrganizationPostDto organizationToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var organization = await ctx.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Organizations.Update(_mapper.Map(organizationToPut, organization));
            await ctx.SaveChangesAsync();
            return Ok(_mapper.Map<OrganizationGetDto>(organization));
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
        var organization = await ctx.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Organizations.Remove(organization);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
