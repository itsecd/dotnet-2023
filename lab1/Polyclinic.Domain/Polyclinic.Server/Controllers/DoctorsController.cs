using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;
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

    // GET: api/<DoctorsController>
    [HttpGet]
    public IEnumerable<DoctorGetDto> Get()
    {
        _logger.LogInformation("Get Doctors");
        return _polyclinicRepository.Doctors.Select(doctor => _mapper.Map<DoctorGetDto>(doctor));

    }

    // GET api/<DoctorsController>/5
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

    // POST api/<DoctorsController>
    [HttpPost]
    public void Post([FromBody] DoctorPostDto doctor)
    {
        _polyclinicRepository.Doctors.Add(_mapper.Map<Doctor>(doctor));

    }

    // PUT api/<DoctorsController>/5
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

    // DELETE api/<DoctorsController>/5
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
