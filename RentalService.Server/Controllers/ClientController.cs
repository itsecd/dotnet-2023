using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for client table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IMapper _mapper;
    private readonly IRentalServiceRepository _rentalServiceRepository;

    public ClientController(ILogger<ClientController> logger, IRentalServiceRepository rentalServiceRepository,
        IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all clients
    /// </summary>
    [HttpGet]
    public IEnumerable<ClientGetDto> Get()
    {
        return _rentalServiceRepository.Clients.Select(client => _mapper.Map<ClientGetDto>(client));
    }

    /// <summary>
    ///     Get method which returns clients by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ClientGetDto> Get(ulong id)
    {
        Client? client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<ClientGetDto>(client));
    }

    /// <summary>
    ///     Post method which add new client
    /// </summary>
    [HttpPost]
    public void Post([FromBody] ClientPostDto client)
    {
        _rentalServiceRepository.Clients.Add(_mapper.Map<Client>(client));
    }

    /// <summary>
    ///     Put method for changing data in the client table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] ClientPostDto clientToPut)
    {
        Client? client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation("Not found client: {id}", id);
            return NotFound();
        }

        _mapper.Map(clientToPut, client);

        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a client
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Client? client = _rentalServiceRepository.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            _logger.LogInformation($"Not found client: {id}");
            return NotFound();
        }

        _rentalServiceRepository.Clients.Remove(client);
        return Ok();
    }
}