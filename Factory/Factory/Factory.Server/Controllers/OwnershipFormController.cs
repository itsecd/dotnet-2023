using Factory.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OwnershipFormController : ControllerBase
{
    private readonly ILogger<OwnershipFormController> _logger;

    private readonly FactoryRepository _factoryRepository;

    public OwnershipFormController(ILogger<OwnershipFormController> logger, FactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    // GET: api/<OwnershipFormController>
    [HttpGet]
    public IEnumerable<OwnershipForm> Get()
    {
        _logger.LogInformation("Get Ownership Forms");
        return _factoryRepository.OwnershipForms;
    }

    // GET api/<OwnershipFormController>/5
    [HttpGet("{id}")]
    public ActionResult<OwnershipForm> Get(int id)
    {
        var ownershipForm = _factoryRepository.OwnershipForms.FirstOrDefault(ownershipForm => ownershipForm.OwnershipFormID == id);
        if (ownershipForm == null)
        {
            _logger.LogInformation($"Not found ownership form: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get ownership form with id {id}");
            return Ok(ownershipForm);
        }
    }
}
