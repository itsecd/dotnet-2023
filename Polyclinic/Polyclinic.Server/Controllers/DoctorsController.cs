using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Doctors controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly ILogger<DoctorsController> _logger;
    private readonly IPolyclinicRepository _polyclinicRepository;
    private readonly IMapper _mapper;
    public DoctorsController(ILogger<DoctorsController> logger, IPolyclinicRepository polyclinicRepository, IMapper mapper)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get doctors
    /// </summary>
    /// <returns>doctors</returns>
    [HttpGet]
    public IEnumerable<DoctorGetDto> Get()
    {
        _logger.LogInformation("Get Doctors");
        return _polyclinicRepository.Doctors.Select(doctor => _mapper.Map<DoctorGetDto>(doctor));

    }

    /// <summary>
    /// Get doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>doctor</returns>
    [HttpGet("{id}")]
    public ActionResult<DoctorGetDto> Get(int id)
    {
        var doctor = _polyclinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get doctor with id {id}");
            return Ok(_mapper.Map<DoctorGetDto>(doctor));
        }
    }

    /// <summary>
    /// Post doctor
    /// </summary>
    /// <param name="doctor"></param>
    [HttpPost]
    public void Post([FromBody] DoctorPostDto doctor)
    {
        _logger.LogInformation("Post doctor");
        _polyclinicRepository.Doctors.Add(_mapper.Map<Doctor>(doctor));
    }

    /// <summary>
    /// Put doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="doctorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DoctorPostDto doctorToPut)
    {
        var doctor = _polyclinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put doctor with id {id}");
            _mapper.Map(doctorToPut, doctor);
            return Ok();
        }
    }

    /// <summary>
    /// Delete doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var doctor = _polyclinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put doctor with id {id}");
            _polyclinicRepository.Doctors.Remove(doctor);
            return Ok();
        }
    }
}
