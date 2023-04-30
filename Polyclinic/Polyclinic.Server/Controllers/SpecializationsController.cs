using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Book specializations controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationsController : ControllerBase
{
    private readonly ILogger<SpecializationsController> _logger;
    private readonly IPolyclinicRepository _polyclinicRepository;

    public SpecializationsController(ILogger<SpecializationsController> logger, IPolyclinicRepository polyclinicRepository)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
    }

    /// <summary>
    /// Get specializations
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Specializations> Get()
    {
        _logger.LogInformation("Get Specializations");
        return _polyclinicRepository.Specializations;
    }

    /// <summary>
    /// Get specialization by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Specializations> Get(int id)
    {
        var specialization = _polyclinicRepository.Specializations.FirstOrDefault(specialization => specialization.Id == id);
        if (specialization == null)
        {
            _logger.LogInformation($"Not found speciaization: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialization with id {id}");
            return Ok(specialization);
        }
    }

}
