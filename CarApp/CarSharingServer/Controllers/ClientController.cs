using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;

namespace CarSharingServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly ICarSharingRepository _carRepository;
    private readonly IMapper _mapper;
    public ClientController(ILogger<ClientController> logger, ICarSharingRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// returns info about all clients
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ClientGetDto> Get()
    {
        _logger.LogInformation("Get the clients");
        return _carRepository.Clients.Select(client => _mapper.Map<ClientGetDto>(client));
    }
    /// <summary>
    /// returns client info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ClientGetDto> Get(uint id)
    {
        _logger.LogInformation($"Get the client with id {id} ", id);
        var clientInfo = _carRepository.Clients.FirstOrDefault(info => info.Uid == id);
        if (clientInfo == null)
        {
            _logger.LogInformation($"Not found a client with id {id}", id);
            return NotFound();
        }
        else 
        { 
            return Ok(_mapper.Map<ClientGetDto>(clientInfo)); 
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    [HttpPost]
    public void Post([FromBody] ClientPostDto client)
    {
        _logger.LogInformation("Post a new client");
        _carRepository.Clients.Add(_mapper.Map<Client>(client));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [HttpPut("{id}")]
    public IActionResult Put(uint id, [FromBody] ClientPostDto clientToPut)
    {
        var client = _carRepository.Clients.FirstOrDefault(info => info.Uid == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found a client with id {id}", id);
            return NotFound();
        }
        else
        {
            
            _mapper.Map(clientToPut, client);
            _logger.LogInformation("Put a new client - success");
            return Ok();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(uint id)
    {
        var client = _carRepository.Clients.FirstOrDefault(info => info.Uid == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found a client with id {id}", id);
            return NotFound();
        }
        else
        {
            _carRepository.Clients.Remove(client);
            _logger.LogInformation("Delete a client - success");
            return Ok();
        }
    }
}
