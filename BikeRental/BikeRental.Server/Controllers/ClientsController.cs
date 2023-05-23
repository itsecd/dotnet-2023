using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Domain;
using AutoMapper;
using BikeRental.Server.Dto;

namespace BikeRental.Server.Controllers;

/// <summary>
/// Clients
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly BikeRentalDbContext _context;

    private readonly IMapper _mapper;

    public ClientsController(BikeRentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// View all clients
    /// </summary>
    /// <returns>Client list</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> GetClients()
    {
      if (_context.Clients == null)
      {
          return NotFound();
      }
        return await _mapper.ProjectTo<ClientGetDto>(_context.Clients).ToListAsync();
    }

    /// <summary>
    /// View client by id
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>Client</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientGetDto>> GetClient(int id)
    {
      if (_context.Clients == null)
      {
          return NotFound();
      }
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return _mapper.Map<ClientGetDto>(client);
    }

    /// <summary>
    /// Change client info
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="client">Changing client</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, ClientSetDto client)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }
        var clientToModify = await _context.Clients.FindAsync(id);
        if (clientToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(client, clientToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adding new client
    /// </summary>
    /// <param name="client">Client</param>
    /// <returns>Added client</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ClientGetDto>> PostClient(ClientSetDto client)
    {
      if (_context.Clients == null)
      {
          return Problem("Entity set 'BikeRentalDbContext.Clients'  is null.");
      }
        var mappedClient = _mapper.Map<Client>(client);

        _context.Clients.Add(mappedClient);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostClient", new { id = mappedClient.Id }, _mapper.Map<ClientGetDto>(mappedClient));
    }

    /// <summary>
    /// Deleting a client
    /// </summary>
    /// <param name="id">Deleted client id</param>
    /// <returns>Action result</returns>
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
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
