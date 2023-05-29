using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StatementSpecialtyController : ControllerBase
{
    private readonly ILogger<StatementSpecialtyController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public StatementSpecialtyController(ILogger<StatementSpecialtyController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all StatementSpecialty
    /// </summary>
    /// <returns>IEnumerable type StatementSpecialtyGetDto</returns>
    [HttpGet]
    public async Task<IEnumerable<StatementSpecialtyGetDto>> Get()
    {
        _logger.LogInformation("Get all StatementSpecialty");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var stSpecialties = await ctx.StatementSpecialties.ToArrayAsync();
        return _mapper.Map<IEnumerable<StatementSpecialtyGetDto>>(stSpecialties);
    }

    /// <summary>
    /// Get StatementSpecialty by id
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <returns>Ok with StatementSpecialtyGetDto or NotFound</returns>
    [HttpGet("{idStSpecialty}")]
    public async Task<ActionResult<StatementSpecialtyGetDto>> Get(int idStSpecialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var stSpecialty = await ctx.StatementSpecialties.FirstOrDefaultAsync(stSpecialty => stSpecialty.IdStatementSpecialty == idStSpecialty);
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
    public async Task<ActionResult> Post([FromBody] StatementSpecialtyPostDto stSpecialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var checkStatement = await ctx.Statements.FirstOrDefaultAsync(statement => statement.IdStatement == stSpecialty.StatementId);
        if (checkStatement == null)
        {
            _logger.LogInformation("Can't work post: Statement doesn't exist with this id {stSpecialty.StatementId}", stSpecialty.StatementId);
            return BadRequest($"Statement doesn't exist with this id {stSpecialty.StatementId}");
        }

        var checkSpecialty = await ctx.Specialties.FirstOrDefaultAsync(specialty => specialty.IdSpecialty == stSpecialty.SpecialtyId);
        if (checkSpecialty == null)
        {
            _logger.LogInformation("Can't work post: Specialty doesn't exist with this id {stSpecialty.SpecialtyId}", stSpecialty.SpecialtyId);
            return BadRequest($"Specialty doesn't exist with this id {stSpecialty.SpecialtyId}");
        }

        var checkStatementSpecialty = await ctx.StatementSpecialties.Where(stSpec => stSpec.StatementId == stSpecialty.StatementId).ToListAsync();
        if (checkStatementSpecialty.Count == 3)
        {
            _logger.LogInformation("Can't work post:entrant already have 3 specialties");
            return BadRequest("Entrant already have 3 specialties");
        }

        _logger.LogInformation("Create new StatementSpecialty");
        await ctx.StatementSpecialties.AddAsync(_mapper.Map<StatementSpecialty>(stSpecialty));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Update information about StatementSpecialty
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <param name="stSpecialtyToPut">StatementSpecialty that is updated</param>
    /// <returns>Ok or NotFound or BadRequest</returns>
    [HttpPut("{idStSpecialty}")]
    public async Task<IActionResult> Put(int idStSpecialty, [FromBody] StatementSpecialtyPostDto stSpecialtyToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();

        var stSpecialty = await ctx.StatementSpecialties.FirstOrDefaultAsync(stSpecialty => stSpecialty.IdStatementSpecialty == idStSpecialty);
        if (stSpecialty == null)
        {
            _logger.LogInformation("Not found StatementSpecialty : {idStSpecialty}", idStSpecialty);
            return NotFound($"The StatementSpecialty does't exist by this id {idStSpecialty}");
        }

        var checkStatement = await ctx.Statements.FirstOrDefaultAsync(statement => statement.IdStatement == stSpecialtyToPut.StatementId);
        if (checkStatement == null)
        {
            _logger.LogInformation("Can't work put: Statement doesn't exist with this id {stSpecialtyToPut.StatementId}", stSpecialtyToPut.StatementId);
            return BadRequest($"Statement doesn't exist with this id {stSpecialtyToPut.StatementId}");
        }

        var checkSpecialty = await ctx.Specialties.FirstOrDefaultAsync(specialty => specialty.IdSpecialty == stSpecialtyToPut.SpecialtyId);
        if (checkSpecialty == null)
        {
            _logger.LogInformation("Can't work put: Specialty doesn't exist with this id {stSpecialtyToPut.SpecialtyId}", stSpecialtyToPut.SpecialtyId);
            return BadRequest($"Specialty doesn't exist with this id {stSpecialtyToPut.SpecialtyId}");
        }

        _logger.LogInformation("Update StatementSpecialty by id {idSttSpecialty}", idStSpecialty);
        _mapper.Map(stSpecialtyToPut, stSpecialty);
        ctx.StatementSpecialties.Update(_mapper.Map<StatementSpecialty>(stSpecialty));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Delete by id StatementSpecialty 
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <returns>Ok or Notfound</returns>
    [HttpDelete("{idStSpecialty}")]
    public async Task<IActionResult> Delete(int idStSpecialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var stSpecialty = await ctx.StatementSpecialties.FirstOrDefaultAsync(stSpecialty => stSpecialty.IdStatementSpecialty == idStSpecialty);
        if (stSpecialty == null)
        {
            _logger.LogInformation("Not found StatementSpecialty : {idStSpecialty}", idStSpecialty);
            return NotFound($"The StatementSpecialty does't exist by this id {idStSpecialty}");
        }
        else
        {
            _logger.LogInformation("Delete StatementSpecialty by id {idStSpecialty}", idStSpecialty);
            ctx.StatementSpecialties.Remove(stSpecialty);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}