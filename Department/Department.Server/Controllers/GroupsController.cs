using AutoMapper;
using Department.Domain;
using Department.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Department.Server.Controllers;

/// <summary>
/// Groups
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GroupsController : ControllerBase
{
    private readonly DepartmentDbContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<GroupsController> _logger;

    public GroupsController(DepartmentDbContext context, IMapper mapper, ILogger<GroupsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// View all groups
    /// </summary>
    /// <returns>Groups list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupGetDto>>> GetGroups()
    {
        return await _mapper.ProjectTo<GroupGetDto>(_context.Groups).ToListAsync();
    }

    /// <summary>
    /// View group by id (group number)
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Group</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupGetDto>> GetGroup(int id)
    {
        var group = await _context.Groups.FindAsync(id);

        if (group == null)
        {
            return NotFound();
        }

        return _mapper.Map<GroupGetDto>(group);
    }


    /// <summary>
    /// Change group info
    /// </summary>
    /// <param name="id">Group id</param>
    /// <param name="group">Changing group</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGroup(int id, GroupSetDto group)
    {
        var groupToModify = await _context.Groups.FindAsync(id);
        if (groupToModify == null)
        {
            _logger.LogInformation("Group not found");
            return NotFound();
        }

        _mapper.Map(group, groupToModify);

        _logger.LogInformation("Successfully updated");

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new group
    /// </summary>
    /// <param name="group">Group</param>
    /// <returns>Added group</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<GroupGetDto>> PostGroup(GroupSetDto group)
    {
        var mappedGroup = _mapper.Map<Group>(group);

        _context.Groups.Add(mappedGroup);

        _logger.LogInformation("Successfully added");

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostGroup", new { id = mappedGroup.Id }, _mapper.Map<GroupGetDto>(mappedGroup));
    }

    /// <summary>
    /// Deleting a group
    /// </summary>
    /// <param name="id">Deleted group id</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        var group = await _context.Groups.FindAsync(id);
        if (group == null)
        {
            return NotFound();
        }

        _context.Groups.Remove(group);

        _logger.LogInformation("Successfully deleted");

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
