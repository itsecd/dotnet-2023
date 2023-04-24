using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntrantResultController : ControllerBase
{
    private readonly ILogger<EntrantResultController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public EntrantResultController(ILogger<EntrantResultController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all EntrantResults
    /// </summary>
    /// <returns>IEnumerable type EntrantResultGetDto</returns>
    [HttpGet]
    public async Task<IEnumerable<EntrantResultGetDto>> Get()
    {
        _logger.LogInformation("Get all EntrantResults");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrantRes = await ctx.EntrantResults.ToArrayAsync();
        return _mapper.Map<IEnumerable<EntrantResultGetDto>>(entrantRes);
    }

    /// <summary>
    /// Get EntrantResult by id
    /// </summary>
    /// <param name="idEntrantRes">id EntrantResult</param>
    /// <returns>Ok with EntrantResultGetDto or NotFound</returns>
    [HttpGet("{idEntrantRes}")]
    public async Task<ActionResult<EntrantResultGetDto>> Get(int idEntrantRes)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrantRes = await ctx.EntrantResults.FirstOrDefaultAsync(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
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
    public async Task<ActionResult> Post([FromBody] EntrantResultPostDto entrantRes)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var checkEntrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == entrantRes.EntrantId);
        if (checkEntrant == null)
        {
            _logger.LogInformation("Can't work post: Entrant doesn't exist with this id {entrantRes.EntrantId}", entrantRes.EntrantId);
            return BadRequest($"Entrant doesn't exist with this id {entrantRes.EntrantId}");
        }

        var checkResult = await ctx.Results.FirstOrDefaultAsync(result => result.IdResult == entrantRes.ResultId);
        if (checkResult == null)
        {
            _logger.LogInformation("Can't work post: Result doesn't exist with this id {entrantRes.ResultId}", entrantRes.ResultId);
            return BadRequest($"Result doesn't exist with this id {entrantRes.ResultId}");
        }

        var checkEntrantResult = await ctx.EntrantResults.Where(entRes => entRes.EntrantId == entrantRes.EntrantId).ToListAsync();
        if (checkEntrantResult.Count == 3)
        {
            _logger.LogInformation("Can't work post:entrant already have 3 exam results");
            return BadRequest("Entrant already have 3 exam results");
        }

        _logger.LogInformation("Create new EntrantResult");
        await ctx.EntrantResults.AddAsync(_mapper.Map<EntrantResult>(entrantRes));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Update information about EntrantResult
    /// </summary>
    /// <param name="idEntrantRes">id EntrantResult</param>
    /// <param name="entrantResultToPut">EntrantResult that is update</param>
    /// <returns>Ok or NotFound or BadRequest</returns>
    [HttpPut("{idEntrantRes}")]
    public async Task<IActionResult> Put(int idEntrantRes, [FromBody] EntrantResultPostDto entrantResultToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrantRes = await ctx.EntrantResults.FirstOrDefaultAsync(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
        if (entrantRes == null)
        {
            _logger.LogInformation("Not found EntrantResult : {idEntrantRes}", idEntrantRes);
            return NotFound($"The EntrantResult does't exist by this id {idEntrantRes}");
        }

        var checkEntrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == entrantResultToPut.EntrantId);
        if (checkEntrant == null)
        {
            _logger.LogInformation("Can't work put: Entrant doesn't exist with this id {entrantResultToPut.EntrantId}", entrantResultToPut.EntrantId);
            return BadRequest($"Entrant doesn't exist with this id {entrantResultToPut.EntrantId}");
        }

        var checkResult = await ctx.Results.FirstOrDefaultAsync(result => result.IdResult == entrantResultToPut.ResultId);
        if (checkResult == null)
        {
            _logger.LogInformation("Can't work put: Result doesn't exist with this id {entrantResultToPut.ResultId}", entrantResultToPut.ResultId);
            return BadRequest($"Result doesn't exist with this id {entrantResultToPut.ResultId}");
        }


        var checkEntrantResult = await ctx.EntrantResults.Where(entrRes => entrRes.EntrantId == entrantResultToPut.EntrantId).ToListAsync();
        if (checkEntrantResult.Count == 3)
        {
            _logger.LogInformation("Can't work put:entrant already have 3 exam results");
            return BadRequest("Entrant already have 3 exam results");
        }

        _logger.LogInformation("Update EntrantResult by id {idEntrantRes}", idEntrantRes);
        _mapper.Map(entrantResultToPut, entrantRes);

        ctx.EntrantResults.Update(_mapper.Map<EntrantResult>(entrantRes));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Delete by id EntrantResult
    /// </summary>
    /// <param name="idEntrantRes"> id EntrantResult</param>
    /// <returns>Ok or Notfound</returns>
    [HttpDelete("{idEntrantRes}")]
    public async Task<IActionResult> Delete(int idEntrantRes)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrantRes = await ctx.EntrantResults.FirstOrDefaultAsync(entrantRes => entrantRes.IdEntrantResult == idEntrantRes);
        if (entrantRes == null)
        {
            _logger.LogInformation("Not found EntrantResult : {idEntrantRes}", idEntrantRes);
            return NotFound($"The EntrantResult does't exist by this id {idEntrantRes}");
        }
        else
        {
            _logger.LogInformation("Delete EntrantResult by id {idEntrantRes}", idEntrantRes);
            ctx.EntrantResults.Remove(entrantRes);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}