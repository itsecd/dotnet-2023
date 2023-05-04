using Microsoft.AspNetCore.Mvc;
using CarSharingDomain;
using CarSharingServer.Dto;
using AutoMapper;
using CarSharingServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarSharingServer.Controllers;
/// <summary>
/// Client controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IDbContextFactory<CarSharingDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for ClientController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    public ClientController(IDbContextFactory<CarSharingDbContext> contextFactory, ILogger<ClientController> logger,  IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get info about all clients
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<ClientGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get the clients");
        var clients = await ctx.Clients.ToArrayAsync();
        return _mapper.Map<IEnumerable<ClientGetDto>>(clients);
    }
    /// <summary>
    /// Get client info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientGetDto>> Get(uint id)
    {
        if (_contextFactory == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Get the client with id {id} ", id);
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClientGetDto>(client);
    }
   
    /// <summary>
    /// Post a new client
    /// </summary>
    /// <param name="client"></param>
    [HttpPost]
    public async Task Post([FromBody] ClientPostDto client)
    {
        _logger.LogInformation("Post a new client");
        var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Clients.AddAsync(_mapper.Map<Client>(client));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Put a client
    /// </summary>
    /// <param name="id"></param>
    /// <param name="clientToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(uint id, [FromBody] ClientPostDto clientToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.FindAsync(id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updating a client with id {id}", id);
            _mapper.Map(clientToPut, client);
            ctx.Update(_mapper.Map<Client>(client));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete a client
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(uint id)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var client = await ctx.Clients.FindAsync(id);
        if (client == null)
        {
            _logger.LogInformation("Not found client with id {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a client - success");
            ctx.Clients.Remove(client);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
