using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Realtor;
using RealtorServer.Dto;
using RealtorServer.Repository;



namespace RealtorServer.Controllers;
/// <summary>
/// Client controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IRealtorRepository _realtorRepository;
    private readonly IMapper _mapper;
    public ClientController(ILogger<ClientController> logger, IRealtorRepository realtorRepository, IMapper mapper)
    {
        _logger = logger;
        _realtorRepository = realtorRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ClientGetDto> Get()
    {
        _logger.LogInformation("Get clients");
        return _realtorRepository.Clients.Select(client => _mapper.Map<ClientGetDto>(client));
    }
    /// <summary>
    /// Get client info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
        var client = _realtorRepository.Clients.FirstOrDefault(Clients => Clients.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ClientGetDto>(client));
        }
    }


    [HttpPost]
    public void Post([FromBody] ClientPostDto client)
    {
        _realtorRepository.Clients.Add(_mapper.Map<Client>(client));
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClientPostDto clientToPut )
    {
        var client = _realtorRepository.Clients.FirstOrDefault(Clients => Clients.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}",id);
            return NotFound();
        }
        else
        {
            _mapper.Map(clientToPut,client);
            return Ok();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var client = _realtorRepository.Clients.FirstOrDefault(Clients => Clients.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}",id);
            return NotFound();
        }
        else
        {
            _realtorRepository.Clients.Remove(client);
            return Ok();
        }
    }
}
