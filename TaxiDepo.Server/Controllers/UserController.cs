using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiDepo.Domain;
using TaxiDepo.Server.Dto;
using TaxiDepo.Server.Repositories;

namespace TaxiDepo.Server.Controllers;

/// <summary>
/// User controller class 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// User logger
    /// </summary>
    private readonly ILogger<UserController> _logger;
    /// <summary>
    /// TaxiDepo repository
    /// </summary>
    private readonly ITaxiDepoRepository _taxiRepository;
    /// <summary>
    /// Mapper
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// UserController class constructor with params
    /// </summary>
    /// <param name="logger">User logger</param>
    /// <param name="taxiRepository">Taxi repository</param>
    /// <param name="mapper">Mapper</param>
    public UserController(ILogger<UserController> logger, ITaxiDepoRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get request
    /// </summary>
    /// <returns>All users objects</returns>
    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
        
        _logger.LogInformation("Get user");
        return _taxiRepository.Users.Select(user => _mapper.Map<UserDto>(user));
    }
    /// <summary>
    /// Get request with search by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Found object or 404Error</returns>
    [HttpGet("{id:int}")]
    public ActionResult<UserDto> Get(int id)
    {
        var user = _taxiRepository.Users.FirstOrDefault(user => user.Id == id);
        if (user != null)
        {
            _logger.LogInformation("Get user by Id");
            return Ok(_mapper.Map<UserDto>(user));
        }
        _logger.LogInformation("Not found a user with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Insert request with selection by id
    /// </summary>
    /// <param name="user">User object</param>
    [HttpPost]
    public void Post([FromBody] UserDto user)
    {
        _logger.LogInformation("Add user");
        _taxiRepository.Users.Add(_mapper.Map<User>(user));
    }
    /// <summary>
    /// Put request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <param name="userToPut">UserDto object</param>
    /// <returns>Change object or 404Error</returns>
    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] UserDto userToPut)
    {
        var user = _taxiRepository.Users.FirstOrDefault(user => user.Id == id);
        if (user != null)
        {
            _logger.LogInformation("Put user");
            _mapper.Map(userToPut, user);
            return Ok();
        }
        _logger.LogInformation("Not found a user with id: {id}", id);
        return NotFound();
    }
    /// <summary>
    /// Delete request with selection by id
    /// </summary>
    /// <param name="id">Index of search</param>
    /// <returns>Delete object or 404Error</returns>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var user = _taxiRepository.Users.FirstOrDefault(user => user.Id == id);
        if (user != null)
        {
            _logger.LogInformation("Delete user");
            _taxiRepository.Users.Remove(user);
            return Ok();
        }
        _logger.LogInformation("Not found a user with id: {id}", id);
        return NotFound();
    }
}