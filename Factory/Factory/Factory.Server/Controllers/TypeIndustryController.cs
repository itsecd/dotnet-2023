using Factory.Domain;
using Factory.Server.Repository;
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

    public TypeIndustryController(IDbContextFactory<FactoryContext> contextFactory, ILogger<TypeIndustryController> logger)
    {
        _contextFactory = contextFactory;
        _logger = logger;
    }

    /// <summary>
    /// Get type industry
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeIndustry> Get()
    {
        using var ctx = _contextFactory.CreateDbContext(); 
        _logger.LogInformation("Get IndustryType");
         return ctx.IndustryTypes;
    }

    /// <summary>
    /// Get type industry by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TypeIndustry> Get(int id)
    {
        using var ctx = _contextFactory.CreateDbContext();
        var typeIndustry = ctx.Find<TypeIndustry>(id);
        if (typeIndustry == null) 
        {
            _logger.LogInformation($"Not found type industry: {id}");
            return NotFound();
        }
        else 
        { 
            _logger.LogInformation($"Get Industry Type with id {id}");
            return Ok(typeIndustry); 
        }
    }
}
