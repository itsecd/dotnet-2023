using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ResultController : ControllerBase
{
    private readonly ILogger<ResultController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public ResultController(ILogger<ResultController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Results
    /// </summary>
    /// <returns> IEnumerable type collection Result </returns>
    [HttpGet("GetAllResults")]
    public IEnumerable<List<Result>> Get()
    {
        _logger.LogInformation("Get all Results");
        return _admissionCommitteeRepository.GetResults;
    }

    /// <summary>
    /// Get Results by id
    /// </summary>
    /// <param name="idResults">id Results</param>
    /// <returns>collection Results with http code</returns>
    [HttpGet("GetResultsById")]
    public ActionResult<List<Result>> Get(int idResults)
    {
        var results = _admissionCommitteeRepository.GetResults.Where(result => result.All(res => res.IdResult == idResults));
        if (!results.Any())
        {
            _logger.LogInformation("Not found Results : {idResults}", idResults);
            return NotFound($"The Results does't exist by this idResults {idResults}");
        }
        else
        {
            _logger.LogInformation("Get Results by id {idResults}", idResults);
            return Ok(results);
        }
    }

    /// <summary>
    /// Create new Results
    /// </summary>
    /// <param name="results">list results</param>
    /// <returns>Ok or BadRequest</returns>
    [HttpPost("CreateResults")]
    public IActionResult Post(List<ResultPostDto> results)
    {
        if (results.Count() == 3)
        {
            _logger.LogInformation("Create new Results");
            _admissionCommitteeRepository.GetResults.Add(_mapper.Map<List<Result>>(results));
            return Ok();
        }
        else
        {
            _logger.LogInformation("Incorrect data entry, count of Results no equal to 3");
            return BadRequest("Count of Results must be 3!");
        }
    }

    /// <summary>
    /// Update information about Results
    /// </summary>
    /// <param name="idResults">id Results</param>
    /// <param name="resultsToPut">Results that is updated</param>
    /// <returns></returns>
    [HttpPut("UpdateResultsById")]
    public IActionResult Put(int idResults, List<ResultPostDto> resultsToPut)
    {
        if (resultsToPut.Count() == 3)
        {
            var results = _admissionCommitteeRepository.GetResults.Where(result => result.All(res => res.IdResult == idResults)).ElementAtOrDefault(0);
            if (results == null)
            {
                _logger.LogInformation("Not found Results : {idResults}", idResults);
                return NotFound($"The Results does't exist by this id {idResults}");
            }
            else
            {
                _logger.LogInformation("Update Results by id {idResults}", idResults);
                _mapper.Map(resultsToPut, results);
                return Ok();
            }
        }
        else
        {
            _logger.LogInformation("Incorrect data update, count of Results no equal to 3");
            return BadRequest("Count of Results must be 3!");
        }
    }

    /// <summary>
    /// Delete by id Results
    /// </summary>
    /// <param name="idResults">id Results for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("DeleteResultsById")]
    public IActionResult Delete(int idResults)
    {
        var results = _admissionCommitteeRepository.GetResults.Where(result => result.All(res => res.IdResult == idResults)).ElementAtOrDefault(0);
        if (results == null)
        {
            _logger.LogInformation("Not found Results : {idResults}", idResults);
            return NotFound($"The Results does't exist by this id {idResults}");
        }
        else
        {
            _logger.LogInformation("Delete Results by id {idResults}", idResults);
            _admissionCommitteeRepository.GetResults.Remove(results);
            return Ok();
        }
    }
}