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
    /// Get Result by id
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <returns>collection Result with http code</returns>
    [HttpGet("GetResultById")]
    public ActionResult<List<Result>> Get(int idResult)
    {
        var result = _admissionCommitteeRepository.GetResults.Where(result => result.All(res => res.IdResult == idResult));
        if (!result.Any())
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this idResult {idResult}");
        }
        else
        {
            _logger.LogInformation("Get Result by id {idResult}", idResult);
            return Ok(result);
        }
    }


    [HttpPost("CreateResult")]
    public void Post([FromBody] ResultPostDto res)
    {
        _logger.LogInformation("Create new Results");
        //_admissionCommitteeRepository.GetResults.Add();
    }


    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }


    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}