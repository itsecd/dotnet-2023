using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatementController : ControllerBase
{
    private readonly ILogger<StatementController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public StatementController(ILogger<StatementController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Statements
    /// </summary>
    /// <returns>IEnumerable type Statement</returns>
    [HttpGet]
    public IEnumerable<StatementGetDto> Get()
    {
        _logger.LogInformation("Get all Statements");
        return _admissionCommitteeRepository.Statements.Select(statement => _mapper.Map<StatementGetDto>(statement));
    }

    /// <summary>
    /// Get Statement by id
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <returns>Ok with StatementGetDto or NotFound</returns>
    [HttpGet("{idStatement}")]
    public ActionResult<StatementGetDto> Get(int idStatement)
    {
        var statement = _admissionCommitteeRepository.Statements.FirstOrDefault(statement => statement.IdStatement == idStatement);
        if (statement == null)
        {
            _logger.LogInformation("Not found Statement : {idStatement}", idStatement);
            return NotFound($"The Statement does't exist by this id {idStatement}");
        }
        else
        {
            _logger.LogInformation("Get Statement by {idStatement}", idStatement);
            return Ok(_mapper.Map<StatementGetDto>(statement));
        }
    }

    /// <summary>
    /// Create new Statement
    /// </summary>
    /// <param name="statement">new Statement</param>
    [HttpPost]
    public void Post([FromBody] StatementPostDto statement)
    {
        _logger.LogInformation("Create new Statement");
        _admissionCommitteeRepository.Statements.Add(_mapper.Map<Statement>(statement));
    }

    /// <summary>
    /// Update information about Statement
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <param name="statementToPut">Statement that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idStatement}")]
    public IActionResult Put(int idStatement, [FromBody] StatementPostDto statementToPut)
    {
        var statement = _admissionCommitteeRepository.Statements.FirstOrDefault(statement => statement.IdStatement == idStatement);
        if (statement == null)
        {
            _logger.LogInformation("Not found Statement : {idStatement}", idStatement);
            return NotFound($"The Statement does't exist by this id {idStatement}");
        }
        else
        {
            _logger.LogInformation("Update Statement by id {idStatement}", idStatement);
            _mapper.Map(statementToPut, statement);
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Statement
    /// </summary>
    /// <param name="idStatement">id Statement by delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idStatement}")]
    public IActionResult Delete(int idStatement)
    {
        var statement = _admissionCommitteeRepository.Statements.FirstOrDefault(statement => statement.IdStatement == idStatement);
        if (statement == null)
        {
            _logger.LogInformation("Not found Statement : {idStatement}", idStatement);
            return NotFound($"The Statement does't exist by this id {idStatement}");
        }
        else
        {
            _logger.LogInformation("Delete Statement by id {idStatement}", idStatement);
            _admissionCommitteeRepository.Statements.Remove(statement);
            return Ok();
        }
    }
}