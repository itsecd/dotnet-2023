using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntrantResultController : ControllerBase
{
    private readonly ILogger<EntrantResultController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public EntrantResultController(ILogger<EntrantResultController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all EntrantResults
    /// </summary>
    /// <returns>IEnumerable type EntrantResultGetDto</returns>
    [HttpGet]
    public IEnumerable<EntrantResultGetDto> Get()
    {
        _logger.LogInformation("Get all EntrantResults");
        return _admissionCommitteeRepository.EntrantResultsWithResult.Select(entrantRes => _mapper.Map<EntrantResultGetDto>(entrantRes));
    }

    /// <summary>
    /// Get EntrantResult by id
    /// </summary>
    /// <param name="idEntrantRes">id EntrantResult</param>
    /// <returns>Ok with EntrantResultGetDto or NotFound</returns>
    [HttpGet("{idEntrantRes}")]
    public ActionResult<EntrantResultGetDto> Get(int idEntrantRes)
    {
        var entrantRes = _admissionCommitteeRepository.EntrantResultsWithResult.FirstOrDefault(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
        if (entrantRes == null)
        {
            _logger.LogInformation("Not found EntrantResult : {idEntrantRes}", idEntrantRes);
            return NotFound($"The EntrantResult does't exist by this id {idEntrantRes}");
        }
        else
        {
            _logger.LogInformation("Get EntrantResult by {idEntrantRes}", idEntrantRes);
            return Ok(_mapper.Map<EntrantResultGetDto>(entrantRes));
        }
    }

    /// <summary>
    /// Create new EntrantResult
    /// </summary>
    /// <param name="entrantRes">new EntrantResult</param>
    /// <returns>Ok or BadRequest</returns>
    [HttpPost]
    public ActionResult Post([FromBody] EntrantResultPostDto entrantRes)
    {
        var checkEntrantResult = _admissionCommitteeRepository.EntrantResultsWithResult.Where(s => s.EntrantId == entrantRes.EntrantId).ToList();
        if (checkEntrantResult.Count == 3)
        {
            _logger.LogInformation("Can't work post:entrant already have 3 exam results");
            return BadRequest("Entrant already have 3 exam results");
        }

        else
        {
            _logger.LogInformation("Create new EntrantResult");
            _admissionCommitteeRepository.EntrantResultsWithResult.Add(_mapper.Map<EntrantResult>(entrantRes));
            return Ok();
        }
    }

    /// <summary>
    /// Update information about EntrantResult
    /// </summary>
    /// <param name="idEntrantRes">id EntrantResult</param>
    /// <param name="entrantResultToPut">EntrantResult that is update</param>
    /// <returns>Ok or NotFound or BadRequest</returns>
    [HttpPut("{idEntrantRes}")]
    public IActionResult Put(int idEntrantRes, [FromBody] EntrantResultPostDto entrantResultToPut)
    {
        var entrantRes = _admissionCommitteeRepository.EntrantResultsWithResult.FirstOrDefault(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
        if (entrantRes == null)
        {
            _logger.LogInformation("Not found EntrantResult : {idEntrantRes}", idEntrantRes);
            return NotFound($"The EntrantResult does't exist by this id {idEntrantRes}");
        }
        else
        {
            var checkEntrantResult = _admissionCommitteeRepository.EntrantResultsWithResult.Where(entRes => entRes.EntrantId == entrantResultToPut.EntrantId).ToList();
            if (checkEntrantResult.Count == 3)
            {
                _logger.LogInformation("Can't work put:entrant already have 3 exam results");
                return BadRequest("Entrant already have 3 exam results");
            }
            else
            {
                _logger.LogInformation("Update EntrantResult by id {idEntrantRes}", idEntrantRes);
                _mapper.Map(entrantResultToPut, entrantRes);
                return Ok();
            }
        }
    }

    /// <summary>
    /// Delete by id EntrantResult
    /// </summary>
    /// <param name="idEntrantRes"> id EntrantResult</param>
    /// <returns>Ok or Notfound</returns>
    [HttpDelete("{idEntrantRes}")]
    public IActionResult Delete(int idEntrantRes)
    {
        var entrantRes = _admissionCommitteeRepository.EntrantResultsWithResult.FirstOrDefault(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
        if (entrantRes == null)
        {
            _logger.LogInformation("Not found EntrantResult : {idEntrantRes}", idEntrantRes);
            return NotFound($"The EntrantResult does't exist by this id {idEntrantRes}");
        }
        else
        {
            _logger.LogInformation("Delete EntrantResult by id {idEntrantRes}", idEntrantRes);
            _admissionCommitteeRepository.EntrantResultsWithResult.Remove(entrantRes);
            return Ok();
        }
    }
}