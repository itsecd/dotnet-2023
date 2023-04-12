using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Repository;

namespace PoliclinicServer.Controllers;

/// <summary>
/// Specialization controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationController : ControllerBase
{
    private readonly ILogger<SpecializationController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;
    /// <summary>
    /// Constructor for SpecializationController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="policlinicRepository"></param>
    public SpecializationController(ILogger<SpecializationController> logger, IPoliclinicRepository policlinicRepository)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
    }
    /// <summary>
    /// Get specialization info
    /// </summary>
    /// <returns>List of all specializations</returns>
    [HttpGet]
    public IEnumerable<Specialization> Get()
    {
        _logger.LogInformation("Get specializations");
        return _policlinicRepository.Specializations;
    }

    /// <summary>
    /// Get specialization info by id
    /// </summary>
    /// <param name="id">Specialization's id</param>
    /// <returns>Specialization with given id</returns>
    [HttpGet("{id}")]
    public ActionResult<Specialization> Get(int id)
    {
        var specialization = _policlinicRepository.Specializations.FirstOrDefault(specialization => specialization.Id == id);
        if (specialization == null)
        {
            _logger.LogInformation($"Not found specialization with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialization with id {id}");
            return Ok(specialization);
        }
    }
}
