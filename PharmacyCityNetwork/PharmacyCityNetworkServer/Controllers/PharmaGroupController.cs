using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// PharmaGroup controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PharmaGroupController : ControllerBase
{
    private readonly ILogger<PharmaGroupController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public PharmaGroupController(ILogger<PharmaGroupController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all pharmaGroups
    /// </summary>
    /// <returns>Return all pharmaGroups</returns>
    [HttpGet]
    public async Task<IEnumerable<PharmaGroupGetDto>> GetPharmaGroups()
    {
        _logger.LogInformation("Get all pharmaGroups");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmaGroups = await ctx.PharmaGroups.ToArrayAsync();
        return _mapper.Map<IEnumerable<PharmaGroupGetDto>>(pharmaGroups);
    }
    /// <summary>
    /// Get pharmaGroup info by id
    /// </summary>
    /// <param name="idPharmaGroup">PharmaGroup Id</param>
    /// <returns>Return pharmaGroup with specified id</returns>
    [HttpGet("{idPharmaGroup}")]
    public async Task<ActionResult<PharmaGroupGetDto>> GetPharmaGroup(int idPharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmaGroup = await ctx.PharmaGroups.FirstOrDefaultAsync(pharmaGroup => pharmaGroup.Id == idPharmaGroup);
        if (pharmaGroup == null)
        {
            _logger.LogInformation("Not found pharmaGroup : {idPharmaGroup}", idPharmaGroup);
            return NotFound($"The pharmaGroup does't exist by this id {idPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Not found pharmaGroup : {idPharmaGroup}", idPharmaGroup);
            return Ok(_mapper.Map<PharmaGroupGetDto>(pharmaGroup));
        }
    }
    /// <summary>
    /// Post a new pharmaGroup
    /// </summary>
    /// <param name="pharmaGroup">PharmaGroup class instance to insert to table</param>
    [HttpPost]
    public async Task PostPharmaGroup([FromBody] PharmaGroupPostDto pharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new pharmaGroup");
        await ctx.PharmaGroups.AddAsync(_mapper.Map<PharmaGroup>(pharmaGroup));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put pharmaGroup
    /// </summary>
    /// <param name="idPharmaGroup">An id of pharmaGroup which would be changed</param>
    /// <param name="pharmaGroupToPut">PharmaGroup class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idPharmaGroup}")]
    public async Task<IActionResult> PutPharmaGroup(int idPharmaGroup, [FromBody] PharmaGroupPostDto pharmaGroupToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmaGroup = await ctx.PharmaGroups.FirstOrDefaultAsync(pharmaGroup => pharmaGroup.Id == idPharmaGroup);
        if (pharmaGroup == null)
        {
            _logger.LogInformation("Not found pharmaGroup : {idPharmaGroup}", idPharmaGroup);
            return NotFound($"The pharmaGroup does't exist by this id {idPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Update pharmaGroup by id {idPharmaGroup}", idPharmaGroup);
            _mapper.Map(pharmaGroupToPut, pharmaGroup);
            ctx.PharmaGroups.Update(_mapper.Map<PharmaGroup>(pharmaGroup));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a pharmaGroup
    /// </summary>
    /// <param name="idPharmaGroup">An id of pharmaGroup which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idPharmaGroup}")]
    public async Task<IActionResult> DeletePharmaGroup(int idPharmaGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var pharmaGroup = await ctx.PharmaGroups.Include(pharmaGroup => pharmaGroup.ProductPharmaGroups)
                                        .FirstOrDefaultAsync(pharmaGroup => pharmaGroup.Id == idPharmaGroup);
        if (pharmaGroup == null)
        {
            _logger.LogInformation("Not found pharmaGroup: {idPharmaGroup}", idPharmaGroup);
            return NotFound($"The pharmaGroup does't exist by this id {idPharmaGroup}");
        }
        else
        {
            _logger.LogInformation("Delete pharmaGroup by id {idPharmaGroup}", idPharmaGroup);
            ctx.PharmaGroups.Remove(pharmaGroup);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}