using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Group controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public GroupController(ILogger<GroupController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all groups
    /// </summary>
    /// <returns>Return all groups</returns>
    [HttpGet]
    public async Task<IEnumerable<GroupGetDto>> GetGroups()
    {
        _logger.LogInformation("Get all groups");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var groups = await ctx.Groups.ToArrayAsync();
        return _mapper.Map<IEnumerable<GroupGetDto>>(groups);
    }
    /// <summary>
    /// Get group info by id
    /// </summary>
    /// <param name="idGroup">Group Id</param>
    /// <returns>Return group with specified id</returns>
    [HttpGet("{idGroup}")]
    public async Task<ActionResult<GroupGetDto>> GetGroup(int idGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var group = await ctx.Groups.FirstOrDefaultAsync(group => group.Id == idGroup);
        if (group == null)
        {
            _logger.LogInformation("Not found group : {idGroup}", idGroup);
            return NotFound($"The group does't exist by this id {idGroup}");
        }
        else
        {
            _logger.LogInformation("Not found group : {idGroup}", idGroup);
            return Ok(_mapper.Map<GroupGetDto>(group));
        }
    }
    /// <summary>
    /// Post a new group
    /// </summary>
    /// <param name="group">Group class instance to insert to table</param>
    [HttpPost]
    public async Task PostGroup([FromBody] GroupPostDto group)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new group");
        await ctx.Groups.AddAsync(_mapper.Map<Group>(group));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put group
    /// </summary>
    /// <param name="idGroup">An id of group which would be changed</param>
    /// <param name="groupToPut">Group class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{idGroup}")]
    public async Task<IActionResult> PutGroup(int idGroup, [FromBody] GroupPostDto groupToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var group = await ctx.Groups.FirstOrDefaultAsync(group => group.Id == idGroup);
        if (group == null)
        {
            _logger.LogInformation("Not found group : {idGroup}", idGroup);
            return NotFound($"The group does't exist by this id {idGroup}");
        }
        else
        {
            _logger.LogInformation("Update group by id {idGroup}", idGroup);
            _mapper.Map(groupToPut, group);
            ctx.Groups.Update(_mapper.Map<Group>(group));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a group
    /// </summary>
    /// <param name="idGroup">An id of group which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{idGroup}")]
    public async Task<IActionResult> DeleteGroup(int idGroup)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var group = await ctx.Groups.Include(group => group.Products)
                                        .FirstOrDefaultAsync(group => group.Id == idGroup);
        if (group == null)
        {
            _logger.LogInformation("Not found group: {idGroup}", idGroup);
            return NotFound($"The group does't exist by this id {idGroup}");
        }
        else
        {
            _logger.LogInformation("Delete group by id {idGroup}", idGroup);
            ctx.Groups.Remove(group);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}