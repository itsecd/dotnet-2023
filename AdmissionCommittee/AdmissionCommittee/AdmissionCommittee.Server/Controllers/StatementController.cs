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
    [HttpGet("GetAllStatements")]
    public IEnumerable<StatementGetDto> Get()
    {
        _logger.LogInformation("Get all Statements");
        return _admissionCommitteeRepository.GetStatements.Select(statement => _mapper.Map<StatementGetDto>(statement));
    }

    // GET api/<StatementController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<StatementController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<StatementController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<StatementController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
