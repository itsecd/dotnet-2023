using Factory.Domain;
using Factory.Server.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Factory.Server.Controllers;

/// <summary>
/// Type industry controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeIndustryController : ControllerBase
{
    private readonly ILogger<TypeIndustryController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    public TypeIndustryController(ILogger<TypeIndustryController> logger, IFactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    /// <summary>
    /// Get type industry
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeIndustry> Get()
    {
        _logger.LogInformation("Get IndustryType");
        return _factoryRepository.IndustryTypes;
    }

    /// <summary>
    /// Get type industry by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TypeIndustry> Get(int id)
    {
        var typeIndustry = _factoryRepository.IndustryTypes.FirstOrDefault(industryType => industryType.TypeID == id);
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
