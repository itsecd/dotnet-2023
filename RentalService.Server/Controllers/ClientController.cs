using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    
    private readonly IRentalServiceRepository _rentalServiceRepository;

    private readonly IMapper _mapper;
    
    public ClientController(ILogger<ClientController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<ClientGetDto> Get()
    {
        return _rentalServiceRepository.Clients.Select(client => _mapper.Map<ClientGetDto>(client));
    }
    
    [HttpGet("{id}")]
    public ActionResult<ClientGetDto> Get(ulong id)
    {
        var client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(_mapper.Map<RentalPointGetDto>(client));
        }
    }
    
    [HttpPost]
    public void Post([FromBody] ClientPostDto client)
    {
        _rentalServiceRepository.Clients.Add(_mapper.Map<Client>(client));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] ClientPostDto clientToPut)
    {
        var client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(clientToPut, client);
    
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.Clients.Remove(client);
            return Ok();
        }
    }
}

