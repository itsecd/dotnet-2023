using Factory.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Factory.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TypeIndustryController : ControllerBase
{
    private readonly ILogger<TypeIndustryController> _logger;
    private readonly FactoryRepository _factoryRepository;

    public TypeIndustryController(ILogger<TypeIndustryController> logger, FactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }
   
    // GET: api/<TypeIndustryController>
    [HttpGet]
    public IEnumerable<TypeIndustry> Get()
    {
        _logger.LogInformation("Get IndustryType");
        return _factoryRepository.IndustryTypes;
    }

    // GET api/<TypeIndustryController>/5
    [HttpGet("{id}")]
    public TypeIndustry? Get(int id)
    {
        _logger.LogInformation($"Get Industry Type with id {id}");
        return _factoryRepository.IndustryTypes.FirstOrDefault(industryType => industryType.TypeID == id);
    }
}
