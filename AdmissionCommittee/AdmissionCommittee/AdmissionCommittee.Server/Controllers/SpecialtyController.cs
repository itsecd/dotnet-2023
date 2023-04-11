using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpecialtyController : ControllerBase
{
    private readonly ILogger<SpecialtyController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public SpecialtyController(ILogger<SpecialtyController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Specialties
    /// </summary>
    /// <returns> IEnumerable type Specialty </returns>
    [HttpGet]
    public IEnumerable<SpecialtyGetDto> Get()
    {
        _logger.LogInformation("Get all Specialties");
        return _admissionCommitteeRepository.Specialties.Select(specialty => _mapper.Map<SpecialtyGetDto>(specialty));
    }

    /// <summary>
    /// Get Specialty by id
    /// </summary>
    /// <param name="idSpecialty">id Speciality</param>
    /// <returns>Ok with SpecialtyGetDto or NotFound</returns>
    [HttpGet("{idSpecialty}")]
    public ActionResult<SpecialtyGetDto> Get(int idSpecialty)
    {
        var specialty = _admissionCommitteeRepository.Specialties.FirstOrDefault(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation("Not found Specialty : {idSpecialty}", idSpecialty);
            return NotFound($"The Specialty does't exist by this idSpecialty {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Get Specialty by {idSpecialty}", idSpecialty);
            return Ok(_mapper.Map<SpecialtyGetDto>(specialty));
        }
    }

    /// <summary>
    /// Create new Specialty
    /// </summary>
    /// <param name="specialty">new Specialty</param>
    [HttpPost]
    public void Post([FromBody] SpecialtyPostDto specialty)
    {
        _logger.LogInformation("Create new Specialty");
        _admissionCommitteeRepository.Specialties.Add(_mapper.Map<Specialty>(specialty));
    }

    /// <summary>
    /// Update information about Specialty
    /// </summary>
    /// <param name="idSpecialty">id Specialty</param>
    /// <param name="specialtyToPut">Specialty that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idSpecialty}")]
    public IActionResult Put(int idSpecialty, [FromBody] SpecialtyPostDto specialtyToPut)
    {
        var specialty = _admissionCommitteeRepository.Specialties.FirstOrDefault(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation("Not found Specialty : {idSpecialty}", idSpecialty);
            return NotFound($"The Specialty does't exist by this id {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Update Specialty by id {idSpecialty}", idSpecialty);
            _mapper.Map(specialtyToPut, specialty);
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Specialty
    /// </summary>
    /// <param name="idSpecialty">id Specialty for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idSpecialty}")]
    public IActionResult Delete(int idSpecialty)
    {
        var specialty = _admissionCommitteeRepository.Specialties.FirstOrDefault(specialty => specialty.IdSpecialty == idSpecialty);
        if (specialty == null)
        {
            _logger.LogInformation($"Not found Specialty : {idSpecialty}");
            return NotFound($"The Specialty does't exist by this id {idSpecialty}");
        }
        else
        {
            _logger.LogInformation("Delete Specialty by id {idSpecialty}", idSpecialty);
            _admissionCommitteeRepository.Specialties.Remove(specialty);
            return Ok();
        }
    }
}