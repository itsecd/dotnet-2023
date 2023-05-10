using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for client table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly RentalServiceDbContext _context;
    private readonly IMapper _mapper;

    public ClientController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all clients
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> Get()
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }

        return await _mapper.ProjectTo<ClientGetDto>(_context.Clients).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns clients by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientGetDto>> Get(ulong id)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }

        Client? client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ClientGetDto>(client));
    }

    /// <summary>
    ///     Post method which add new client
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ClientGetDto>> Post(ClientPostDto client)
    {
        if (_context.Clients == null)
        {
            return Problem("Entity set 'DataBaseContext.Clients'  is null.");
        }

        Client? mappedClient = _mapper.Map<Client>(client);

        _context.Clients.Add(mappedClient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedClient.Id }, _mapper.Map<ClientGetDto>(mappedClient));
    }

    /// <summary>
    ///     Put method for changing data in the client table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] ClientPostDto clientToPut)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }

        Client? clientToModify = await _context.Clients.FindAsync(id);

        if (clientToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(clientToPut, clientToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a client
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        if (_context.Clients == null)
        {
            return NotFound();
        }

        Client? client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}