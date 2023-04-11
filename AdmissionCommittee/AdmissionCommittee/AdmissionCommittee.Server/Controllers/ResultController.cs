using AdmissionCommittee.Model;
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
    [HttpGet]
    public IEnumerable<ResultGetDto> Get()
    {
        _logger.LogInformation("Get all Results");
        return _admissionCommitteeRepository.Results.Select(result => _mapper.Map<ResultGetDto>(result));
    }

    /// <summary>
    /// Get Result by id
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <returns>Ok with EntrantGetDto or NotFound</returns>
    [HttpGet("{idResult}")]
    public ActionResult<ResultGetDto> Get(int idResult)
    {
        var result = _admissionCommitteeRepository.Results.FirstOrDefault(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this idResult {idResult}");
        }
        else
        {
            _logger.LogInformation("Get Result by id {idResult}", idResult);
            return Ok(_mapper.Map<ResultGetDto>(result));
        }
    }

    /// <summary>
    /// Create new Result
    /// </summary>
    /// <param name="result">new result</param>
    [HttpPost]
    public void Post(ResultPostDto result)
    {
        _logger.LogInformation("Create new Result");
        _admissionCommitteeRepository.Results.Add(_mapper.Map<Result>(result));
    }

    /// <summary>
    /// Update information about Result
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <param name="resultToPut">Result that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idResult}")]
    public IActionResult Put(int idResult, [FromBody] ResultPostDto resultToPut)
    {
        var result = _admissionCommitteeRepository.Results.FirstOrDefault(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this id {idResult}");
        }
        else
        {
            _logger.LogInformation("Update Result by id {idResult}", idResult);
            _mapper.Map(resultToPut, result);
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Result
    /// </summary>
    /// <param name="idResult">id Result for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idResult}")]
    public IActionResult Delete(int idResult)
    {
        var result = _admissionCommitteeRepository.Results.FirstOrDefault(result => result.IdResult == idResult);
        if (result == null)
        {
            _logger.LogInformation("Not found Result : {idResult}", idResult);
            return NotFound($"The Result does't exist by this id {idResult}");
        }
        else
        {
            _logger.LogInformation("Delete Result by id {idResult}", idResult);
            _admissionCommitteeRepository.Results.Remove(result);
            return Ok();
        }
    }
}