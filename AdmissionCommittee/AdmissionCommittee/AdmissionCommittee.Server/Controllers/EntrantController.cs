using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntrantController : ControllerBase
{
    private readonly ILogger<EntrantController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public EntrantController(ILogger<EntrantController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Entrants
    /// </summary>
    /// <returns> IEnumerable type EntrantGetDto </returns>
    [HttpGet]
    public async Task<IEnumerable<EntrantGetDto>> Get()
    {
        _logger.LogInformation("Get all Entrants");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrants = await ctx.Entrants.ToArrayAsync();
        return _mapper.Map<IEnumerable<EntrantGetDto>>(entrants);
    }

    /// <summary>
    /// Get Entrant by id
    /// </summary>
    /// <param name="idEntrant">id entrant</param>
    /// <returns>Ok with EntrantGetDto or NotFound</returns>
    [HttpGet("{idEntrant}")]
    public async Task<ActionResult<EntrantGetDto>> Get(int idEntrant)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation("Not found Entrant : {idEntrant}", idEntrant);
            return NotFound($"The Entrant does't exist by this id {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Get Entrant by {idEntrant}", idEntrant);
            return Ok(_mapper.Map<EntrantGetDto>(entrant));
        }
    }

    /// <summary>
    /// Create new Entrant
    /// </summary>
    /// <param name="entrant">new Entrant</param>
    [HttpPost]
    public async Task Post([FromBody] EntrantPostDto entrant)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new Entrant");
        await ctx.Entrants.AddAsync(_mapper.Map<Entrant>(entrant));
        await ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Update information about Entrant
    /// </summary>
    /// <param name="idEntrant">id Entrant</param>
    /// <param name="entrantToPut">Entrant that is updated</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idEntrant}")]
    public async Task<IActionResult> Put(int idEntrant, [FromBody] EntrantPostDto entrantToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrant = await ctx.Entrants.FirstOrDefaultAsync(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation("Not found Entrant : {idEntrant}", idEntrant);
            return NotFound($"The Entrant does't exist by this id {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Update Entrant by id {idEntrant}", idEntrant);
            _mapper.Map(entrantToPut, entrant);
            ctx.Entrants.Update(_mapper.Map<Entrant>(entrant));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Entrant
    /// </summary>
    /// <param name="idEntrant">id Entrant for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idEntrant}")]
    public async Task<IActionResult> Delete(int idEntrant)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var entrant = await ctx.Entrants.Include(entrant => entrant.Statement)
                                        .Include(entrant => entrant.EntrantResults)
                                        .FirstOrDefaultAsync(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation($"Not found Entrant : {idEntrant}");
            return NotFound($"The entrant does't exist by this id {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Delete Entrant by id {idEntrant}", idEntrant);
            ctx.Entrants.Remove(entrant);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}