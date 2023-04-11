using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatementSpecialtyController : ControllerBase
{
    private readonly ILogger<StatementSpecialtyController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public StatementSpecialtyController(ILogger<StatementSpecialtyController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all StatementSpecialty
    /// </summary>
    /// <returns>IEnumerable type StatementSpecialtyGetDto</returns>
    [HttpGet]
    public IEnumerable<StatementSpecialtyGetDto> Get()
    {
        _logger.LogInformation("Get all StatementSpecialty");
        return _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.Select(stSpecialty => _mapper.Map<StatementSpecialtyGetDto>(stSpecialty));
    }

    /// <summary>
    /// Get StatementSpecialty by id
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <returns>Ok with StatementSpecialtyGetDto or NotFound</returns>
    [HttpGet("{idStSpecialty}")]
    public ActionResult<StatementSpecialtyGetDto> Get(int idStSpecialty)
    {
        var stSpecialty = _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.FirstOrDefault(stSpecialty => stSpecialty.IdStatementSpecialty == idStSpecialty);
        if (stSpecialty == null)
        {
            _logger.LogInformation("Not found StatementSpecialty : {idStSpecialty}", idStSpecialty);
            return NotFound($"The StatementSpecialty does't exist by this id {idStSpecialty}");
        }
        else
        {
            _logger.LogInformation("Get StatementSpecialty by {idStSpecialty}", idStSpecialty);
            return Ok(_mapper.Map<StatementSpecialtyGetDto>(stSpecialty));
        }
    }

    /// <summary>
    /// Create new StatementSpecialty
    /// </summary>
    /// <param name="stSpecialty">new StatementSpecialty</param>
    /// <returns>Ok or BadRequest</returns>
    [HttpPost]
    public ActionResult Post([FromBody] StatementSpecialtyPostDto stSpecialty)
    {
        var checkStatementSpecialty = _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.Where(st => st.StatementId == stSpecialty.StatementId).ToList();
        if (checkStatementSpecialty.Count == 3)
        {
            _logger.LogInformation("Can't work post:entrant already have 3 specialties");
            return BadRequest("Entrant already have 3 specialties");
        }
        else
        {
            _logger.LogInformation("Create new StatementSpecialty");
            _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.Add(_mapper.Map<StatementSpecialty>(stSpecialty));
            return Ok();
        }
    }

    /// <summary>
    /// Update information about StatementSpecialty
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <param name="stSpecialtyToPut">StatementSpecialty that is updated</param>
    /// <returns>Ok or NotFound or BadRequest</returns>
    [HttpPut("{idStSpecialty}")]
    public IActionResult Put(int idStSpecialty, [FromBody] StatementSpecialtyPostDto stSpecialtyToPut)
    {
        var stSpeciality = _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.FirstOrDefault(stSpeciality => stSpeciality.IdStatementSpecialty == idStSpecialty);
        if (stSpeciality == null)
        {
            _logger.LogInformation("Not found StatementSpecialty : {idStSpecialty}", idStSpecialty);
            return NotFound($"The StatementSpecialty does't exist by this id {idStSpecialty}");
        }
        else
        {
            var checkStatementSpecialty = _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.Where(st => st.StatementId == stSpecialtyToPut.StatementId).ToList();
            if (checkStatementSpecialty.Count == 3)
            {
                _logger.LogInformation("Can't work put:entrant already have 3 specialties");
                return BadRequest("Entrant already have 3 specialties");
            }
            else
            {
                _logger.LogInformation("Update StatementSpecialty by id {idSttSpecialty}", idStSpecialty);
                _mapper.Map(stSpecialtyToPut, stSpeciality);
                return Ok();
            }
        }
    }

    /// <summary>
    /// Delete by id StatementSpecialty 
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <returns>Ok or Notfound</returns>
    [HttpDelete("{idStSpecialty}")]
    public IActionResult Delete(int idStSpecialty)
    {
        var stSpecialty = _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.FirstOrDefault(stSpecialty => stSpecialty.IdStatementSpecialty == idStSpecialty);
        if (stSpecialty == null)
        {
            _logger.LogInformation("Not found StatementSpecialty : {idStSpecialty}", idStSpecialty);
            return NotFound($"The StatementSpecialty does't exist by this id {idStSpecialty}");
        }
        else
        {
            _logger.LogInformation("Delete StatementSpecialty by id {idStSpecialty}", idStSpecialty);
            _admissionCommitteeRepository.StatementSpecialtiesWithSpecialty.Remove(stSpecialty);
            return Ok();
        }
    }
}