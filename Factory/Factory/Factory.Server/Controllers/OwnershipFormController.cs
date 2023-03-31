using Factory.Domain;
using Factory.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Server.Controllers;

/// <summary>
/// Ownership form controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OwnershipFormController : ControllerBase
{
    private readonly ILogger<OwnershipFormController> _logger;

    private readonly IFactoryRepository _factoryRepository;

    public OwnershipFormController(ILogger<OwnershipFormController> logger, IFactoryRepository factoryRepository)
    {
        _logger = logger;
        _factoryRepository = factoryRepository;
    }

    /// <summary>
    /// Get ownership forms
    /// </summary>
    /// <returns>ownership forms</returns>
    [HttpGet]
    public IEnumerable<OwnershipForm> Get()
    {
        _logger.LogInformation("Get Ownership Forms");
        return _factoryRepository.OwnershipForms;
    }

    /// <summary>
    /// Get ownership form by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ownership forms</returns>
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
