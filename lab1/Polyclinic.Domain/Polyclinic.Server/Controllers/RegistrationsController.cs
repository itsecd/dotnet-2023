using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Registration controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RegistrationsController : ControllerBase
{
    private readonly ILogger<RegistrationsController> _logger;
    private readonly IPolyclinicRepository _polyclinicRepository;
    private readonly IMapper _mapper;
    public RegistrationsController(ILogger<RegistrationsController> logger, IPolyclinicRepository polyclinicRepository, IMapper mapper)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get registrations
    /// </summary>
    /// <returns>patients</returns>
    [HttpGet]
    public IEnumerable<Registration> Get()
    {
        _logger.LogInformation("Get Registrations");
        return _polyclinicRepository.Registrations;
    }

    /// <summary>
    /// Get regiastration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>patient</returns>
    [HttpGet("{id}")]
    public ActionResult<Registration> Get(int id)
    {
        var registration = _polyclinicRepository.Registrations.FirstOrDefault(registration => registration.Id == id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get registration with id {id}");
            return Ok(registration);
        }
    }

    /// <summary>
    /// Post registration
    /// </summary>
    /// <param name="registration"></param>
    [HttpPost]
    public void Post([FromBody] RegistrationPostDto registration)
    {
        _polyclinicRepository.Registrations.Add(_mapper.Map<Registration>(registration));
    }

    /// <summary>
    /// Put registration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="registrationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RegistrationPostDto registrationToPut)
    {
        var registration = _polyclinicRepository.Registrations.FirstOrDefault(registration => registration.Id == id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put registration with id {id}");
            _mapper.Map(registrationToPut, registration);
            return Ok();
        }
    }

    /// <summary>
    /// Delete registration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var registration = _polyclinicRepository.Registrations.FirstOrDefault(registration => registration.Id == id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put registration with id {id}");
            _polyclinicRepository.Registrations.Remove(registration);
            return Ok();
        }
    }
}
