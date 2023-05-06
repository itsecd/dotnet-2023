using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiDepo.Model;
using TaxiDepo.Server.Dto;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// UsersController class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// TaxiDepoDbContext class object
    /// </summary>
    private readonly TaxiDepoDbContext _context;

    /// <summary>
    /// Mapper for UsersController class
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Logger for UsersController class
    /// </summary>
    private readonly ILogger<UsersController> _logger;

    /// <summary>
    /// Constructor with params of UsersController class 
    /// </summary>
    /// <param name="context">TaxiDepoDbContext class object</param>
    /// <param name="mapper">IMapper object</param>
    /// <param name="logger">ILogger object</param>
    public UsersController(TaxiDepoDbContext context, IMapper mapper, ILogger<UsersController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get all users from collection
    /// </summary>
    /// <returns>UserDto object</returns>
    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a users");
            return NotFound();
        }

        _logger.LogInformation("Get all users from collection");
        return await _mapper.ProjectTo<UserDto>(_context.Users).ToListAsync();
    }

    /// <summary>
    /// Get user by id from collection
    /// </summary>
    /// <param name="id">Needed user id</param>
    /// <returns>UserDto object</returns>
    [HttpGet("GetUserBy{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a users");
            return NotFound();
        }

        _logger.LogInformation("Get user by id from collection");
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            _logger.LogInformation("Not found a user by id");
            return NotFound();
        }

        return _mapper.Map<UserDto>(user);
    }

    /// <summary>
    /// Put user from collection
    /// </summary>
    /// <param name="id">Needed id to put</param>
    /// <param name="user">User to put</param>
    /// <returns>No content</returns>
    [HttpPut("PutUserBy{id}")]
    public async Task<IActionResult> PutUser(int id, UserDto user)
    {
        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a users");
            return NotFound();
        }

        _logger.LogInformation("Put a user by id from collection");
        var userToModify = await _context.Users.FindAsync(id);
        if (userToModify == null)
        {
            _logger.LogInformation("Not found a user by id");
            return NotFound();
        }

        _mapper.Map(user, userToModify);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Post user to collection
    /// </summary>
    /// <param name="user">User to post</param>
    /// <returns>Created action</returns>
    [HttpPost("PostUser")]
    [ProducesResponseType(201)]
    public async Task<ActionResult<UserDto>> PostUser(UserDto user)
    {
        if (_context.Users == null)
        {
            return Problem("Entity set 'TaxiDepoDbContext.Users'  is null.");
        }

        _logger.LogInformation("Posting user to collection");
        var mappedUser = _mapper.Map<User>(user);
        _context.Users.Add(mappedUser);
        await _context.SaveChangesAsync();
        return CreatedAtAction("PostUser", new { id = mappedUser.Id }, _mapper.Map<UserDto>(mappedUser));
    }

    /// <summary>
    /// Delete user from collection
    /// </summary>
    /// <param name="id">Needed id to delete</param>
    /// <returns>No content</returns>
    [HttpDelete("DeleteUserBy{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (_context.Users == null)
        {
            _logger.LogInformation("Not found a users");
            return NotFound();
        }

        _logger.LogInformation("Deletion user from collection");
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            _logger.LogInformation("Not found a user by id");
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}