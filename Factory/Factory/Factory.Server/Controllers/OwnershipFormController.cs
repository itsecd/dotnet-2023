using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Ownership form controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OwnershipFormController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<OwnershipFormController> _logger;

    private readonly IMapper _mapper;

    public OwnershipFormController(IDbContextFactory<FactoryContext> contextFactory, ILogger<OwnershipFormController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get ownership forms
    /// </summary>
    /// <returns>ownership forms</returns>
    [HttpGet]
    public async Task<IEnumerable<OwnershipFormGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get Ownership Forms");
        return _mapper.Map<IEnumerable<OwnershipFormGetDto>>(ctx.OwnershipForms);
    }

    /// <summary>
    /// Get ownership form by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ownership forms</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OwnershipFormGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var ownershipForm = await ctx.FindAsync<OwnershipForm>(id);
        if (ownershipForm == null)
        {
            _logger.LogInformation($"Not found ownership form: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get ownership form with id {id}");
            return Ok(_mapper.Map<OwnershipFormGetDto>(ownershipForm));
        }
    }
}
