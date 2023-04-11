using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AirplaneBookingSystem.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airlines.Server.Controllers;
/// <summary>
/// Controller for client table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IAirplaneBookingSystemRepository _airplaneBookingSystemRepository;
    private readonly IMapper _mapper;
    public ClientController(ILogger<ClientController> logger, IAirplaneBookingSystemRepository airplaneBookingSystemRepository, IMapper mapper)
    {
        _logger = logger;
        _airplaneBookingSystemRepository = airplaneBookingSystemRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for client table
    /// </summary>
    /// <returns>
    /// Return all clients
    /// </returns>
    [HttpGet]
    public IEnumerable<ClientGetDto> Get()
    {
        _logger.LogInformation("Get clients");
        return _airplaneBookingSystemRepository.Client.Select(client => _mapper.Map<ClientGetDto>(client));
    }
    /// <summary>
    /// Get by id method for client table
    /// </summary>
    /// <returns>
    /// Return client with specified id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<ClientGetDto> Get(int id)
    {
        _logger.LogInformation($"Get client with id ({id})");
        var client = _airplaneBookingSystemRepository.Client.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ClientGetDto>(client));
        }
    }
    /// <summary>
    /// Post method for client table
    /// </summary>
    /// <param name="client"> Client class instance to insert to table</param>
    [HttpPost]
    public void Post([FromBody] ClientPostDto client)
    {
        _logger.LogInformation("Post");
        _airplaneBookingSystemRepository.Client.Add(_mapper.Map<Client>(client));
    }
    /// <summary>
    /// Put method for client table
    /// </summary>
    /// <param name="id">An id of client which would be changed </param>
    /// <param name="clientToPut">Client class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientPostDto clientToPut)
    {
        _logger.LogInformation("Put client with id {0}", id);
        var client = _airplaneBookingSystemRepository.Client.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(clientToPut, client);
            return Ok();
        }
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of client which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation($"Put client with id ({id})");
        var client = _airplaneBookingSystemRepository.Client.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client with id ({id})");
            return NotFound();
        }
        else
        {
            _airplaneBookingSystemRepository.Client.Remove(client);
            return Ok();
        }
    }
}