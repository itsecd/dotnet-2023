using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Factory.Server.Controllers;

/// <summary>
/// Type industry controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeIndustryController : ControllerBase
{
    private readonly IDbContextFactory<FactoryContext> _contextFactory;

    private readonly ILogger<TypeIndustryController> _logger;

    private readonly IMapper _mapper;

    public TypeIndustryController(IDbContextFactory<FactoryContext> contextFactory, ILogger<TypeIndustryController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get type industry
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeIndustryGetDto> Get()
    {
        using var ctx = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get IndustryType");
        return _mapper.Map<IEnumerable<TypeIndustryGetDto>>(ctx.IndustryTypes);
    }

    /// <summary>
    /// Get type industry by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeIndustryGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var typeIndustry = await ctx.FindAsync<TypeIndustry>(id);
        if (typeIndustry == null)
        {
            _logger.LogInformation($"Not found type industry: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get Industry Type with id {id}");
            return Ok(_mapper.Map<TypeIndustryGetDto>(typeIndustry));
        }
    }
}
