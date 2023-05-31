using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realtor;
using AutoMapper;
using RealtorServer.Dto;

namespace RealtorServer.Controllers;
/// <summary>
/// Client controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly RealtorDbContext _context;
    private readonly ILogger<ClientsController> _logger;
    private readonly IMapper _mapper;
    /// <summary>
    ///     Constructor for ClientsController
    /// </summary>
    public ClientsController(RealtorDbContext context, IMapper mapper, ILogger<ClientsController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    ///     Get method for clients table
    /// </summary>
    /// <returns>
    ///     Return clients list
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetClients()
    {
      if (_context.Clients == null)
      {
          return NotFound();
      }
        _logger.LogInformation("Get clients");
        return await _mapper.ProjectTo<ClientGetDto>(_context.Clients).ToListAsync();
    }
    /// <summary>
    /// Get client info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Client</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientGetDto>> GetClient(int id)
    {
        _logger.LogInformation("Get client with id {id}", id);
        if (_context.Clients == null)
        {
          return NotFound();
        }
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        return _mapper.Map<ClientGetDto>(client);
    }
    /// <summary>
    /// Change client info
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="client">Changing client</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, ClientPostDto client)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }
        var clientToPut = await _context.Clients.FindAsync(id);
        if (clientToPut == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        _mapper.Map(client, clientToPut);
        _logger.LogInformation("Updated");
        await _context.SaveChangesAsync();
        return NoContent();
    }
    /// <summary>
    ///     Post method for clients table
    /// </summary>
    /// <param name="client"> client</param>
    /// <returns>
    ///     Create client
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<ClientGetDto>> PostClient(ClientPostDto client)
    {
      if (_context.Clients == null)
      {
          return Problem("Entity set 'RealtorDbContext.Clients'  is null.");
      }
        var newClient = _mapper.Map<Client>(client);
        _context.Clients.Add(newClient);
        _logger.LogInformation("Added");
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetClient", new { id = newClient.Id }, _mapper.Map<ClientGetDto>(newClient));
    }
    /// <summary>
    ///     Delete method 
    /// </summary>
    /// <param name="id"> An id of client which would be deleted </param>
    /// <returns>
    ///     Action Result
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        _context.Clients.Remove(client);
        _logger.LogInformation("Deleted");
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
