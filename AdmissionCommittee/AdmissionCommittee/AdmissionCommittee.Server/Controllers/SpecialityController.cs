using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpecialityController : ControllerBase
{
    private readonly ILogger<SpecialityController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public SpecialityController(ILogger<SpecialityController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Specialities
    /// </summary>
    /// <returns> IEnumerable type Speciality </returns>
    [HttpGet("GetAllSpecialities")]
    public IEnumerable<Speciality> Get()
    {
        _logger.LogInformation("Get all Specialities");
        return _admissionCommitteeRepository.GetSpecialities;
    }

    /// <summary>
    /// Get Speciality by id
    /// </summary>
    /// <param name="idSpeciality">id entrant</param>
    /// <returns>Speciality with http code</returns>
    [HttpGet("GetSpecialityById")]
    public ActionResult<Speciality> Get(int idSpeciality)
    {
        var speciality = _admissionCommitteeRepository.GetSpecialities.FirstOrDefault(speciality => speciality.IdSpeciality == idSpeciality);
        if (speciality == null)
        {
            _logger.LogInformation("Not found Speciality : {idSpeciality}", idSpeciality);
            return NotFound($"The Speciality does't exist by this idSpeciality {idSpeciality}");
        }
        else
        {
            _logger.LogInformation("Get Speciality by {idSpeciality}", idSpeciality);
            return Ok(speciality);
        }
    }

    /// <summary>
    /// Create new Speciality
    /// </summary>
    /// <param name="speciality">new Speciality</param>
    [HttpPost("CreateSpeciality")]
    public void Post([FromBody] SpecialityPostDto speciality)
    {
        _logger.LogInformation("Create new Speciality");
        _admissionCommitteeRepository.GetSpecialities.Add(_mapper.Map<Speciality>(speciality));
    }

    /// <summary>
    /// Update information about Speciality
    /// </summary>
    /// <param name="idSpeciality">id Speciality</param>
    /// <param name="specialityToPut">Speciality that is updated</param>
    /// <returns></returns>
    [HttpPut("UpdateSpecialityById")]
    public IActionResult Put(int idSpeciality, [FromBody] SpecialityPostDto specialityToPut)
    {
        var speciality = _admissionCommitteeRepository.GetSpecialities.FirstOrDefault(speciality => speciality.IdSpeciality == idSpeciality);
        if (speciality == null)
        {
            _logger.LogInformation("Not found Speciality : {idSpeciality}", idSpeciality);
            return NotFound($"The Speciality does't exist by this id {idSpeciality}");
        }
        else
        {
            _logger.LogInformation("Update Speciality by id {idSpeciality}", idSpeciality);
            _mapper.Map(specialityToPut, speciality);
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Speciality
    /// </summary>
    /// <param name="idSpeciality">id Speciality for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("DeleteSpecialityById")]
    public IActionResult Delete(int idSpeciality)
    {
        var speciality = _admissionCommitteeRepository.GetSpecialities.FirstOrDefault(speciality => speciality.IdSpeciality == idSpeciality);
        if (speciality == null)
        {
            _logger.LogInformation($"Not found Speciality : {idSpeciality}");
            return NotFound($"The Speciality does't exist by this id {idSpeciality}");
        }
        else
        {
            _logger.LogInformation("Delete Speciality by id {idSpeciality}", idSpeciality);
            _admissionCommitteeRepository.GetSpecialities.Remove(speciality);
            return Ok();
        }
    }
}