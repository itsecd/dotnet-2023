using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;
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

    // GET: api/<SpecializationsController>
    [HttpGet]
    public IEnumerable<Specializations> Get()
    {
        _logger.LogInformation("Get Specializations");
        return _polyclinicRepository.Specializations;
    }

    // GET api/<SpecializationsController>/5
    [HttpGet("{id}")]
    public ActionResult<Specializations> Get(int id)
    {
        var specialization = _polyclinicRepository.Specializations.FirstOrDefault(specialization => specialization.IdSpecialization == id);
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
