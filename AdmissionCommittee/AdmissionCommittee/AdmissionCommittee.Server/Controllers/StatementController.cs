using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatementController : ControllerBase
{
    private readonly ILogger<StatementController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public StatementController(ILogger<StatementController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Statements
    /// </summary>
    /// <returns>IEnumerable type Statement</returns>
    [HttpGet]
    public async Task<IEnumerable<StatementGetDto>> Get()
    {
        _logger.LogInformation("Get all Statements");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var statements = await ctx.Statements.ToArrayAsync();
        return _mapper.Map<IEnumerable<StatementGetDto>>(statements);
    }

    /// <summary>
    /// Get Statement by id
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <returns>Ok with StatementGetDto or NotFound</returns>
    [HttpGet("{idStatement}")]
    public async Task<ActionResult<StatementGetDto>> Get(int idStatement)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var statement = await ctx.Statements.FirstOrDefaultAsync(statement => statement.IdStatement == idStatement);
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
    public async Task<ActionResult> Post([FromBody] StatementPostDto statement)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var checkEntrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == statement.EntrantId);
        if (checkEntrant == null)
        {
            _logger.LogInformation("Can't work post: Entrant doesn't exist with this id {statement.EntrantId}", statement.EntrantId);
            return BadRequest($"Entrant doesn't exist with this id {statement.EntrantId}");
        }
        _logger.LogInformation("Create new Statement");
        await ctx.Statements.AddAsync(_mapper.Map<Statement>(statement));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Update information about Statement
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <param name="statementToPut">Statement that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idStatement}")]
    public async Task<IActionResult> Put(int idStatement, [FromBody] StatementPostDto statementToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var statement = await ctx.Statements.FirstOrDefaultAsync(statement => statement.IdStatement == idStatement);
        if (statement == null)
        {
            _logger.LogInformation("Not found Statement : {idStatement}", idStatement);
            return NotFound($"The Statement does't exist by this id {idStatement}");
        }

        var checkEntrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == statementToPut.EntrantId);
        if (checkEntrant == null)
        {
            _logger.LogInformation("Can't work put: Entrant doesn't exist with this id {statementToPut.EntrantId}", statementToPut.EntrantId);
            return BadRequest($"Entrant doesn't exist with this id {statementToPut.EntrantId}");
        }

        _logger.LogInformation("Update Statement by id {idStatement}", idStatement);
        _mapper.Map(statementToPut, statement);

        ctx.Statements.Update(_mapper.Map<Statement>(statement));
        await ctx.SaveChangesAsync();
        return Ok();

    }

    /// <summary>
    /// Delete by id Statement
    /// </summary>
    /// <param name="idStatement">id Statement by delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idStatement}")]
    public async Task<IActionResult> Delete(int idStatement)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var statement = await ctx.Statements.Include(statement => statement.Entrant)
                                            .Include(statement => statement.StatementSpecialties)
                                            .FirstOrDefaultAsync(statement => statement.IdStatement == idStatement);
        if (statement == null)
        {
            _logger.LogInformation("Not found Statement : {idStatement}", idStatement);
            return NotFound($"The Statement does't exist by this id {idStatement}");
        }
        else
        {
            _logger.LogInformation("Delete Statement by id {idStatement}", idStatement);
            ctx.Statements.Remove(statement);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}